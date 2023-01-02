using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.JsonPatch;
using MudBlazor;
using WRMC.Core.Shared.Requests;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Components
{
    public partial class OtherDmographicIntake : IDisposable
    {
        [Parameter] public EventCallback<bool> OnValidationChanged { get; set; }
        [Parameter, EditorRequired] public OtherDemographicIntakeRequest Model { get; set; } = new();
        public EditContext EditContext { get; set; }


        protected async override Task OnInitializedAsync()
        {
            IsLoading = true;
            EditContext = new EditContext(Model);
            await OnValidationChanged.InvokeAsync(EditContext.Validate());

            EditContext.OnFieldChanged += EditContext_OnFieldChanged;
            IsLoading = false;
        }



        private void EditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            var isValid = EditContext.Validate();
            OnValidationChanged.InvokeAsync(isValid);
            EditContext.NotifyValidationStateChanged();
        }

        public void Dispose()
        {
            EditContext.OnFieldChanged -= EditContext_OnFieldChanged;
        }

    }
}