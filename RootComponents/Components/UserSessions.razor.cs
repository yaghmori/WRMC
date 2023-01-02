using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Shared;

namespace WRMC.RootComponents.Components
{
    public partial class UserSessions
    {
        [Parameter] public string UserId { get; set; } = string.Empty;
        [CascadingParameter] private HubConnection hubConnection { get; set; }

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
                { "ButtonText", _viewResources[ViewResources.Terminate] },
                { "ContentText", _messageResources[MessageResources.AreYouSureYouWantToTerminateThisSession] },
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
                    //SignalR

                    var users = new List<string> { UserId };
                    if (hubConnection is not null)
                    {
                        await hubConnection.SendAsync(EndPoints.Hub.SendTerminateSession, users);
                    }
                    _snackbar.Add(_messageResources[MessageResources.SessionSuccessfullyTerminated], Severity.Success);
                    await LoadData();
                }
                else
                {
                    _snackbar.Add(_messageResources[MessageResources.TerminatingSessionFailed], Severity.Error);
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            _appState.AppTitle = _viewResources[ViewResources.UserSessions];
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
            await LoadData();
        }
    }
}