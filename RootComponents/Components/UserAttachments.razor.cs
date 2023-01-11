using Microsoft.AspNetCore.Components;
using MudBlazor;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Shared;

namespace WRMC.RootComponents.Components
{
    public partial class UserAttachments
    {
        [Parameter]
        public string UserId { get; set; }

        private List<UserAttachmentResponse> AttachmentCollection = new();

        protected async override Task OnParametersSetAsync()
        {
            //Load UserAttachment
            await LoadUserAttachments();
        }
        private async Task LoadUserAttachments()
        {
            IsLoading = true;

            var response = await _userDataService.GetUserAttachmentsAsync(UserId);
            if (response?.Succeeded == true)
            {
                AttachmentCollection = response.Data;
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

        private async Task ViewAttachment(UserAttachmentResponse item)
        {
        }

        private async Task AddOrUpdateAttachment(UserAttachmentResponse item)
        {
        }

        private async Task DeleteAttachment(UserAttachmentResponse item)
        {
            var parameters = new DialogParameters
            {
                { "Title", item.Type?.GetDisplayDescription() },
                { "ButtonText", _viewLocalizer[ViewResources.Delete].Value },
                { "ContentText", _messageLocalizer[MessageResources.DoYouReallyWantToDeleteAttachment].Value },
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

                var result = await _userDataService.DeleteUserAttachmentAsync(UserId, item.Id);
                if (result.Succeeded)
                {
                    //TODO : Update Using SignalR
                    _snackbar.Add(_messageLocalizer[MessageResources.AttachmentSuccessfullyDeleted].Value, Severity.Success);
                    await LoadUserAttachments();
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