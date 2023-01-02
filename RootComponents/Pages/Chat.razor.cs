using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Pages
{
    public partial class Chat
    {
        public List<string> Messages { get; } = new List<string>();
        private string? messageInput;

        [Parameter]
        public string RoleId { get; set; } = string.Empty;
        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }
        [CascadingParameter] private HubConnection? _hubConnection { get; set; }
        [CascadingParameter] private UserResponse? User { get; set; }

        private IEnumerable<string> SelectedUsers { get; set; } = new List<string>();
        public List<UserResponse> UserCollection { get; set; } = new();
        //private bool CanAddUser { get => User != null && !Users.Any(x => x.Id == User.Id); }


        private string GetMultiSelectionText(List<string> selectedValues)
        {       
            SelectedUsers = SelectedUsers.ToList();
            return _viewResources[ViewResources.UserSelected, selectedValues.Count];
        }

        public async void RemoveUser(MudChip chip)
        {
            SelectedUsers = SelectedUsers.Where(x => x != chip.Value.ToString()).ToList();
        }

        protected override async Task OnInitializedAsync()
        {
            var userCollectionResult = await _userDataService.GetUsersAsync();
            if (userCollectionResult.Succeeded)
            {
                UserCollection = userCollectionResult.Data;
            }
            var selectedUsersResult = await _roleDataService.GetUserRolesAsync(RoleId);
            if (selectedUsersResult.Succeeded)
            {
                SelectedUsers = selectedUsersResult.Data.Select(x => x.Id).ToList();
            }

            if (_hubConnection != null)
            {
                _hubConnection.On<string, string>(EndPoints.Hub.ReceiveMessage, (sender, message) =>
                {
                    var encodedMsg = $"{sender} : {message}";
                    Messages.Add(encodedMsg);
                    StateHasChanged();
                });

                if (_hubConnection.State == HubConnectionState.Disconnected)
                {
                    await _hubConnection.StartAsync();
                }
            }
        }

        private async Task Send()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.SendAsync(EndPoints.Hub.SendMessage,User?.Email,messageInput, SelectedUsers);
            }
        }

        public bool CanSendMessage => _hubConnection?.State == HubConnectionState.Connected && !string.IsNullOrWhiteSpace(messageInput);
    }
}