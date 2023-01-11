using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Shared;

namespace WRMC.RootComponents.Components
{
    public partial class UserSessions
    {
        [Parameter] public string UserId { get; set; } = string.Empty;

        private List<UserSessionResponse> SessionCollection = new List<UserSessionResponse>();


        private async Task LoadData()
        {
            IsLoading = true;
            var result = await _userDataService.GetUserSessionsAsync(UserId);
            if (result.Succeeded)
            {
                SessionCollection = result.Data;
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
            IsLoading = false;
        }

        private async Task TerminateSession(UserSessionResponse session)
        {
            var parameters = new DialogParameters
            {
                { "Title", session.Name },
                { "ButtonText", _viewLocalizer[ViewResources.Terminate] },
                { "ContentText", _messageLocalizer[MessageResources.AreYouSureYouWantToTerminateThisSession] },
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
                //WebApi Call
                var result = await _userDataService.TerminateSessionAsync(session.Id);
                if (result.Succeeded)
                {
                    _snackbar.Add(_messageLocalizer[MessageResources.SessionSuccessfullyTerminated], Severity.Success);
                    await LoadData();
                }
                else
                {
                    _snackbar.Add(_messageLocalizer[MessageResources.TerminatingSessionFailed], Severity.Error);
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            _appState.AppTitle = _viewLocalizer[ViewResources.UserSessions];
            await LoadData();
        }
    }
}