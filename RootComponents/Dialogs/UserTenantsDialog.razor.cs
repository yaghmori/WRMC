using Microsoft.AspNetCore.Components;
using MudBlazor;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Dialogs
{
    public partial class UserTenantsDialog
    {
        [Parameter]
        public string UserId { get; set; } = string.Empty;
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        private IEnumerable<string> SelectedTenants { get; set; } = new List<string>();
        public List<TenantResponse> TenantCollection { get; set; } = new();
        private bool InProcess = false;
        //private bool CanAddUser { get => User != null && !Users.Any(x => x.Id == User.Id); }
        private void Cancel()
        {
            MudDialog.Cancel();
        }

        async void SaveChanges()
        {
            InProcess = true;
            var result = await _userDataService.UpdateUserTenantsAsync(UserId, SelectedTenants.ToList());
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
            SelectedTenants = SelectedTenants.ToList();
            return _messageResources[MessageResources.TenantSelected, selectedValues.Count];
        }

        public void RemoveClient(MudChip chip)
        {
            SelectedTenants = SelectedTenants.Where(x => x !=chip.Value.ToString()).ToList();
        }

        protected override async Task OnInitializedAsync()
        {
            var clients = await _TenantDataService.GetTenantsAsync();
            if (clients.Succeeded)
                TenantCollection = clients.Data;

            var selectedClients = await _userDataService.GetUserTenantsAsync(UserId.ToString());
            if(selectedClients.Succeeded)
                SelectedTenants = selectedClients.Data.Select(x => x.Id).ToList();

        }
    }
}