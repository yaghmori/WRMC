using Microsoft.AspNetCore.Components;
using MudBlazor;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Dialogs;
using WRMC.RootComponents.Shared;

namespace WRMC.RootComponents.Components
{
    public partial class UserAddresses
    {
        [Parameter] public string UserId { get; set; }=string.Empty;

        public List<UserAddressResponse> AddressCollection = new();

        protected async override Task OnParametersSetAsync()
        {
            //Load UserAddresses
            await LoadUserAddresses();
        }
        private async Task LoadUserAddresses()
        {
            IsLoading = true;

            var response = await _userDataService.GetUserAddressesAsync(UserId);
            if (response?.Succeeded == true)
            {
                AddressCollection = response.Data;
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

        private async Task AddOrUpdateAddress(UserAddressResponse item)
        {
            var parameters = new DialogParameters();
            parameters.Add("UserId", UserId);
            if (item != null)
                parameters.Add("UserAddressId", item.Id);
            var options = new DialogOptions { CloseButton = true, DisableBackdropClick = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            var title = item == null ? _viewResources[ViewResources.AddNewAddress].Value : _viewResources[ViewResources.UpdateAddress].Value;
            var dialog = _dialog.Show<AddOrUpdateAddressDialog>(title, parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await LoadUserAddresses();
            }
        }

        private async Task DeleteAddress(UserAddressResponse item)
        {
            var parameters = new DialogParameters
            {
                { "Title", item.AddressType?.GetDisplayDescription() },
                { "ButtonText", _viewResources[ViewResources.Delete].Value },
                { "ContentText", _messageResources[MessageResources.DoYouReallyWantToDeleteAddress].Value },
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

                var result = await _userDataService.DeleteUserAddressAsync(UserId, item.Id);
                if (result.Succeeded)
                {
                    //TODO : Update Using SignalR
                    _snackbar.Add(_messageResources[MessageResources.AddressSuccessfullyDeleted].Value, Severity.Success);
                    await LoadUserAddresses();
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
    }
}