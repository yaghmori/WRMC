using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.JsonPatch;
using MudBlazor;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Components
{
    public partial class ResidentialIntake : IDisposable
    {
        [Parameter] public EventCallback<bool> OnValidationChanged { get; set; }
        public List<RegionResponse> Countries { get; set; } = new();
        [Parameter, EditorRequired] public ResidentialIntakeRequest Model { get; set; } = new();
        public EditContext EditContext { get; set; }


        protected async override Task OnInitializedAsync()
        {
            IsLoading = true;

            //Load Countries
            var regionResponse = await _regionDataService.GetRegionsAsync();
            if (regionResponse?.Succeeded == true)
            {
                Countries = regionResponse.Data;
            }

            EditContext = new EditContext(Model);
            await OnValidationChanged.InvokeAsync(EditContext.Validate());
            EditContext.OnFieldChanged += EditContext_OnFieldChanged;
            IsLoading = false;
        }

        private async Task<IEnumerable<RegionResponse>> SearchCountries(string value)
        {
            if (string.IsNullOrEmpty(value))
                return Countries;
            return Countries.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }

        private void EditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            var isValid = EditContext.Validate();
            OnValidationChanged.InvokeAsync(isValid);
        }

        public void Dispose()
        {
            EditContext.OnFieldChanged -= EditContext_OnFieldChanged;
        }
    }
}