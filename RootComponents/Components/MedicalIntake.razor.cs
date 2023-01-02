using Microsoft.AspNetCore.Components;
using WRMC.Core.Shared.Requests;
using WRMC.RootComponents.Enums;

namespace WRMC.RootComponents.Components
{
    public partial class MedicalIntake
    {
        [Parameter] public string TaskId { get; set; } = string.Empty;
        private WizardOrientationEnum orientation { get; set; } = WizardOrientationEnum.Vertical;
        private bool useTimeLine { get; set; } = false;
        public string MedicalIntakeId { get; set; } = string.Empty;

        protected async override Task OnInitializedAsync()
        {
            IsLoading = true;

            //TODO : Optimize code

            var medicalIntakeResponse = await _medicalIntakesDataService.GetMedicalIntakeByTaskIdAsync(TaskId);
            if (medicalIntakeResponse?.Succeeded == true)
            {
                if (medicalIntakeResponse?.Data != null) //Get previous medicalIntake Id 
                {
                    MedicalIntakeId = medicalIntakeResponse.Data.Id;
                }
                else //if null create a new instance
                {

                    var visitResponse = await _visitDataService.GetVisitByTaskIdAsync(TaskId);
                    if (visitResponse?.Succeeded == true)
                    {
                        var request = new IntakeRequest
                        {
                            TaskId = TaskId,
                            VisitId = visitResponse.Data.Id,
                            IsComplete = false
                        };

                        var result = await _medicalIntakesDataService.CreateNewMedicalIntakeAsync(request);
                        if (result?.Succeeded == true)
                        {
                            MedicalIntakeId = result.Data;
                        }
                    }
                }
            }

            IsLoading = false;
        }

    }
}