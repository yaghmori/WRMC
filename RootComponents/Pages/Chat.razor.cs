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
        [CascadingParameter] private UserResponse? User { get; set; }

        private IEnumerable<string> SelectedUsers { get; set; } = new List<string>();
        public List<UserResponse> UserCollection { get; set; } = new();


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
            var selectedUsersResult = await _roleDataService.GetRoleUsersAsync(RoleId);
            if (selectedUsersResult.Succeeded)
            {
                SelectedUsers = selectedUsersResult.Data.Select(x => x.Id.ToLowerInvariant()).ToList();
            }

            _chatSignalRClinet.OnMessageReceived(async (string sender,string message,List<string> recivers) =>
            {
                var encodedMsg = $"{sender} : {message}";
                Messages.Add(encodedMsg);
                StateHasChanged();
            });

            await _chatSignalRClinet.Start();
        }

        private async Task Send()
        {
            var users = SelectedUsers.ToList();
          await  _chatSignalRClinet.SendMessage(User?.Email, messageInput, users);
        }

        public bool CanSendMessage => _chatSignalRClinet.State == HubConnectionState.Connected && !string.IsNullOrWhiteSpace(messageInput);
    }
}