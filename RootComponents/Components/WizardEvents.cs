namespace WRMC.RootComponents.Components
{
    public class WizardEvents<T> where T : class
    {

        public event EventHandler<StepChangedEventArgs> StepChanged;
        public event EventHandler<OnStepChangeEventArgs> OnStepChange;

        public class StepChangedEventArgs : EventArgs
        {
            public StepChangedEventArgs(WizardStep previousStep, WizardStep currentStep)
                : base()
            {
                PreviousStep = previousStep;
                CurrentStep = currentStep;
            }

            public WizardStep PreviousStep { get; set; }
            public WizardStep CurrentStep { get; set; }
        }



        public class OnStepChangeEventArgs : EventArgs
        {
            public OnStepChangeEventArgs(WizardStep currentStep, bool isCancel)
                : base()
            {
                CurrentStep = currentStep;
                IsCancel = isCancel;
            }

            public WizardStep CurrentStep { get; set; }
            public bool IsCancel { get; set; }
        }

    }

}
