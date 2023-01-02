using Microsoft.AspNetCore.Components;

namespace WRMC.RootComponents.Components
{
    public partial class WizardStep
    {
        [CascadingParameter]
        public Wizard Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback OnNextButtonCommand { get; set; }

        [Parameter]
        public EventCallback<bool> OnValidation { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? Description { get; set; }

        [Parameter]
        public int Order { get; set; }

        [Parameter]
        public bool IsDone { get; set; } = false;
        [Parameter]
        public bool ShowSubmit { get; set; } = false;

        [Parameter]
        public bool IsValid { get; set; } = false;
        [Parameter]
        public string? Icon { get; set; }

        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public string? Style { get; set; }

        protected override void OnInitialized()
        {
            Parent.AddStep(this);
            if (Parent == null)
                throw new ArgumentNullException(nameof(Parent), "WizardStep must exist within a Wizard");
            base.OnInitialized();
        }

        public async void OnValidationChangedAsync(bool isValid)
        {
            IsValid = isValid;
            await OnValidation.InvokeAsync(isValid);
        }

        public async void NextButtonCommand()
        {
            await OnNextButtonCommand.InvokeAsync();
        }
    }
}