using Microsoft.AspNetCore.Components;
using MudBlazor;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Requests;

namespace WRMC.RootComponents.Dialogs
{
    public partial class UserClaimsDialog
    {
        [Parameter]
        public string UserId { get; set; } = string.Empty;
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        private MudDataGrid<UserClaimRequest>? _mudDataGrid = new();

        private HashSet<string> SelectedClaims { get; set; } = new HashSet<string>();
        public IEnumerable<string> ClaimCollection { get; set; } = new List<string>();
        private string Query { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            ClaimCollection = new List<string>();
            SelectedClaims = new HashSet<string>();

            ClaimCollection = new HashSet<string>(ApplicationPermissions.GetPermissions());

            var claimResult = await _userDataService.GetUserClaimsAsync(UserId);
            if (claimResult.Succeeded)
            {
                SelectedClaims = new HashSet<string>(
                    claimResult.Data.Where(x => x.ClaimType.Equals(ApplicationClaimTypes.Permission)).Select(x => x.ClaimValue));

            }

        }

        private async void SaveChanges()
        {
            IsBusy = true;
            var result = await _userDataService.UpdateUserClaimsAsync(UserId, SelectedClaims.Select(s => new UserClaimRequest
            {
                ClaimType = ApplicationClaimTypes.Permission,
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

        private void OnSearchData(string query)
        {
            Query = query;
            _mudDataGrid.ReloadServerData();
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }

    }
}