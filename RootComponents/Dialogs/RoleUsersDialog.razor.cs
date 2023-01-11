using Microsoft.AspNetCore.Components;
using MudBlazor;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Dialogs
{
    public partial class RoleUsersDialog
    {
        [Parameter]
        public string RoleId { get; set; } = string.Empty;
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        private IEnumerable<string> SelectedUsers { get; set; } = new List<string>();
        public List<UserResponse> UserCollection { get; set; } = new();
        private bool InProcess = false;
        //private bool CanAddUser { get => User != null && !Users.Any(x => x.Id == User.Id); }
        private void Cancel()
        {
            MudDialog.Cancel();
        }

        async void SaveChanges()
        {
            InProcess = true;
           var result = await _roleDataService.UpdateUserRolesAsync(RoleId, SelectedUsers.ToList());
            if (result.Succeeded)
            {
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Success);
                }
            }
            InProcess = false;
            MudDialog.Close(DialogResult.Ok(result.Succeeded));

        }

        private string GetMultiSelectionText(List<string> selectedValues)
        {
            SelectedUsers = SelectedUsers.ToList();
            return _viewLocalizer[ViewResources.UserSelected, selectedValues.Count];
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
                SelectedUsers = selectedUsersResult.Data.Select(x => x.Id).ToList(); 
            }
        }
    }
}