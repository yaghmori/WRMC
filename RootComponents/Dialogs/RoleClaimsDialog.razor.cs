using Microsoft.AspNetCore.Components;
using MudBlazor;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;

namespace WRMC.RootComponents.Dialogs
{
    public partial class RoleClaimsDialog
    {
        [Parameter]
        public string RoleId { get; set; } = string.Empty;
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        private MudDataGrid<ClaimRequest>? _mudDataGrid = new();

        private HashSet<string> SelectedClaims { get; set; } = new HashSet<string>();
        public IEnumerable<string> ClaimCollection { get; set; } = new List<string>();
        private string Query { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            ClaimCollection = new List<string>();
            SelectedClaims = new HashSet<string>();

            ClaimCollection = new HashSet<string>(AppPermissions.GetPermissions());

            var claimResult = await _roleDataService.GetRoleClaimsAsync(RoleId);
            if (claimResult.Succeeded)
            {
                SelectedClaims = new HashSet<string>(
                    claimResult.Data.Where(x => x.ClaimType.Equals(AppClaimTypes.Permission)).Select(x => x.ClaimValue));
            }

        }
        private void Cancel()
        {
            MudDialog.Cancel();
        }

        private async void SaveChanges()
        {
            IsBusy = true;
            var result = await _roleDataService.UpdateRoleClaimsAsync(RoleId, SelectedClaims.Select(s => new ClaimResponse
            {
                ClaimType = AppClaimTypes.Permission,
                ClaimValue = s
            }).ToList());

            if (!result.Succeeded)
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Success);
                }
            }
            IsBusy = false;
            MudDialog.Close(DialogResult.Ok(result.Succeeded));
        }


        private bool FilterFunc(string item)
        {
            if (string.IsNullOrWhiteSpace(Query))
                return true;
            if (item.Contains(Query, StringComparison.InvariantCultureIgnoreCase))
                return true;
            return false;
        }


    }
}