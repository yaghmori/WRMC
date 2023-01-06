using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using WRMC.RootComponents.Enums;

namespace WRMC.RootComponents.Components
{
    public partial class Wizard
    {
        private string wizardOrientationClass => Orientation == WizardOrientationEnum.horizontal ? "flex-column" : "flex-column flex-md-row";
        private string stepsOrientationClass => Orientation == WizardOrientationEnum.horizontal ? "flex-column flex-md-row mt-10" : "flex-column col-md-4 col-lg-3 ml-10";
        private string stepsOrientationStyle => Orientation == WizardOrientationEnum.horizontal ? "" : "width:300px;";

        [Parameter, EditorRequired] public RenderFragment<WizardStep> ChildContent { get; set; }
        [Parameter] public EventCallback OnValidSubmit { get; set; }
        [Parameter] public EventCallback<WizardStep> OnStepChanged { get; set; }
        [Parameter] public WizardOrientationEnum Orientation { get; set; } = WizardOrientationEnum.horizontal;
        [Parameter] public string Class { get; set; }
        [Parameter] public string Style { get; set; }
        [Parameter] public bool Liner { get; set; } = false;
        public WizardStep ActiveStep { get; set; }
        [Parameter] public bool IsNextSubmit { get; set; } = false;
        [Parameter] public bool AllowSubmit { get; set; } = false;
        public bool IsValid { get; set; }
        public bool IsModified { get; set; }
        public List<WizardStep> Steps { get; set; } = new List<WizardStep>();

        internal void AddStep(WizardStep step)
        {
            step.Order = Steps.Count + 1;
            Steps.Add(step);
            if (Steps.Count == 1)
                ActiveStep = step;
            StateHasChanged();
        }
        public async Task SetActivateStep(WizardStep step)
        {

            ActiveStep = step;
            if (IsNextSubmit)
            {
                OnValidSubmit.InvokeAsync();
            }
            await OnStepChanged.InvokeAsync(step);
        }
        public virtual async void OnValidationChanged(bool isValid)
        {
            ActiveStep.IsValid = isValid;
            IsModified = true;
        }
        protected virtual async void OnValidSubmitAsync()
        {
            var nextStep = Steps.Where(x => x.Order == ActiveStep?.Order + 1).FirstOrDefault();
            if (nextStep != null)
            {
                await SetActivateStep(nextStep);
            }
            await OnValidSubmit.InvokeAsync();
        }

    }
}