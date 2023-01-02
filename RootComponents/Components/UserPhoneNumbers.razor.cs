using Microsoft.AspNetCore.Components;
using MudBlazor;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Dialogs;
using WRMC.RootComponents.Shared;

namespace WRMC.RootComponents.Components
{
    public partial class UserPhoneNumbers
    {
        [Parameter] public string UserId { get; set; }=string.Empty;

        public List<UserPhoneNumberResponse> PhoneNumberCollection = new();

        protected async override Task OnParametersSetAsync()
        {
            await LoadUserPhoneNumbers();
        }
        private async Task LoadUserPhoneNumbers()
        {
            IsLoading = true;

            var response = await _userDataService.GetUserPhoneNumbersAsync(UserId);
            if (response?.Succeeded == true)
            {
                PhoneNumberCollection = response.Data;
            }
            else
            {
                foreach (var message in response?.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
            IsLoading = false;

        }

        private async Task DeletePhoneNumber(UserPhoneNumberResponse item)
        {
            var parameters = new DialogParameters
            {
                { "Title", item.PhoneNumberType?.GetDisplayDescription() },
                { "ButtonText", _viewResources[ViewResources.Delete].Value },
                { "ContentText", _messageResources[MessageResources.DoYouReallyWantToDeletePhoneNumber].Value },
                { "ButtonColor", Color.Error },
                { "ButtonIcon", Icons.Rounded.Delete },
                { "TitleIcon", Icons.Rounded.Delete },
            };
            var options = new DialogOptions()
            {
                CloseButton = true,
                MaxWidth = MaxWidth.ExtraSmall
            };
            var dialog = _dialog.Show<MessageDialog>("", parameters, options);
            var dgResult = await dialog.Result;
            if (!dgResult.Cancelled)
            {
               
                var result = await _userDataService.DeleteUserPhoneNumberAsync(UserId,item.Id);
                if (result.Succeeded)
                {
                    //TODO : Update Using SignalR
                    _snackbar.Add(_messageResources[MessageResources.PhoneNumberSuccessfullyDeleted].Value, Severity.Success);
                    await LoadUserPhoneNumbers();
                }
                else
                {
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }
        }

        private async Task AddOrUpdatePhoneNumber(UserPhoneNumberResponse item)
        {
            var parameters = new DialogParameters();
            parameters.Add("UserId", UserId);
            if (item != null)
                parameters.Add("UserPhoneNumberId", item.Id);
            var options = new DialogOptions{CloseButton = true, DisableBackdropClick = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall};
            var title = item == null ? _viewResources[ViewResources.AddNewPhoneNumber].Value : _viewResources[ViewResources.UpdatePhoneNumber].Value;
            var dialog = _dialog.Show<AddOrUpdatePhoneNumberDialog>(title, parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await LoadUserPhoneNumbers();
            }
        }
    }
}