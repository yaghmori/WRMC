using Microsoft.AspNetCore.Components;
using MudBlazor;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.RootComponents.Dialogs
{
    public partial class RegionTreeSelectionDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        private RegionResponse? SelectedItem { get; set; }
        public IEnumerable<RegionResponse> RegionCollection { get; set; } = new HashSet<RegionResponse>();

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            var regionResponse = await _regionDataService.GetRegionsAsync();
            if (regionResponse.Succeeded)
            {
                RegionCollection = new HashSet<RegionResponse>(regionResponse.Data);

            }
            IsLoading = false;

        }
        public async Task<bool> OnExpanding(RegionResponse context)
        {
            context.IsExpanded = !context.IsExpanded;
            return context.IsExpanded;
        }

        private async void OnItemClicked(RegionResponse context)
        {
            if (context != null && context.RegionType == RegionTypeEnum.City)
            {
                MudDialog.Close(DialogResult.Ok(context));
            }
        }
    }
}