using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.JsonPatch;
using MudBlazor;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Enums;

namespace WRMC.RootComponents.Components
{
    public partial class DemographicIntake
    {
        [Parameter] public string TaskId { get; set; } = string.Empty;
        private WizardOrientationEnum orientation { get; set; } = WizardOrientationEnum.horizontal;
        private bool useTimeLine { get; set; } = false;
        public DemographicIntakeResponse DemographicResponse { get; set; } = new();
        public EditContext EditContext { get; set; }
        public DemographicIntakeRequest DemographicRequest { get; set; } = new();
        private Wizard? _wizard { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            IsLoading = true;
            DemographicResponse = new DemographicIntakeResponse();
            //TODO : Optimize code
            var demographicResponse = await _demographicIntakesDataService.GetDemographicIntakeByTaskIdAsync(TaskId);
            if (demographicResponse?.Succeeded == true)
            {
                if (demographicResponse?.Data != null) //Get previous demographic Id 
                {
                    DemographicResponse = demographicResponse.Data;
                    DemographicRequest = _autoMapper.Map<DemographicIntakeRequest>(demographicResponse.Data);
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

                        var result = await _demographicIntakesDataService.CreateNewDemographicIntakeAsync(request);
                        if (result?.Succeeded == true)
                        {
                            
                            DemographicResponse.Id = result.Data;
                            DemographicRequest = new DemographicIntakeRequest();
                            DemographicRequest.VisitId= visitResponse.Data.Id;
                            DemographicRequest.TaskId = TaskId;
                        }
                    }
                }
            }
            IsLoading = false;
            StateHasChanged();

        }
        private async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            var patchDoc = new JsonPatchDocument<DemographicIntakeRequest>();
            //Financial
            patchDoc.Replace(e => e.FinancialIntake.Income, DemographicRequest.FinancialIntake.Income);
            patchDoc.Replace(e => e.FinancialIntake.Occupation, DemographicRequest.FinancialIntake.Occupation);
            patchDoc.Replace(e => e.FinancialIntake.CombinedIncome, DemographicRequest.FinancialIntake.CombinedIncome);
            patchDoc.Replace(e => e.FinancialIntake.Employer, DemographicRequest.FinancialIntake.Employer);
            patchDoc.Replace(e => e.FinancialIntake.Employment, DemographicRequest.FinancialIntake.Employment);
            patchDoc.Replace(e => e.FinancialIntake.FinancialSupport, DemographicRequest.FinancialIntake.FinancialSupport);
            patchDoc.Replace(e => e.FinancialIntake.NumberOfTaxReturn, DemographicRequest.FinancialIntake.NumberOfTaxReturn);

            //Residential
            patchDoc.Replace(e => e.ResidentialIntake.RegionId, DemographicRequest.ResidentialIntake.RegionId);
            patchDoc.Replace(e => e.ResidentialIntake.InSchool, DemographicRequest.ResidentialIntake.InSchool);
            patchDoc.Replace(e => e.ResidentialIntake.NeedInsurance, DemographicRequest.ResidentialIntake.NeedInsurance);
            patchDoc.Replace(e => e.ResidentialIntake.SchoolName, DemographicRequest.ResidentialIntake.SchoolName);
            patchDoc.Replace(e => e.ResidentialIntake.HaveInsurance, DemographicRequest.ResidentialIntake.HaveInsurance);
            patchDoc.Replace(e => e.ResidentialIntake.InsuranceName, DemographicRequest.ResidentialIntake.InsuranceName);
            patchDoc.Replace(e => e.ResidentialIntake.IsUSCitizen, DemographicRequest.ResidentialIntake.IsUSCitizen);
            patchDoc.Replace(e => e.ResidentialIntake.ImmigrationStatus, DemographicRequest.ResidentialIntake.ImmigrationStatus);
            patchDoc.Replace(e => e.ResidentialIntake.LastGrade, DemographicRequest.ResidentialIntake.LastGrade);
            patchDoc.Replace(e => e.ResidentialIntake.LivingArrangement, DemographicRequest.ResidentialIntake.LivingArrangement);
            patchDoc.Replace(e => e.ResidentialIntake.MaritalStatus, DemographicRequest.ResidentialIntake.MaritalStatus);
            patchDoc.Replace(e => e.ResidentialIntake.MedicaidNo, DemographicRequest.ResidentialIntake.MedicaidNo);
            patchDoc.Replace(e => e.ResidentialIntake.NumberOfHousehold, DemographicRequest.ResidentialIntake.NumberOfHousehold);

            //OtherField
            patchDoc.Replace(e => e.OtherDemographicIntake.HidePregnancy, DemographicRequest.OtherDemographicIntake.HidePregnancy);
            patchDoc.Replace(e => e.OtherDemographicIntake.ConduciveRaising, DemographicRequest.OtherDemographicIntake.ConduciveRaising);
            patchDoc.Replace(e => e.OtherDemographicIntake.AffordPrenatal, DemographicRequest.OtherDemographicIntake.AffordPrenatal);
            patchDoc.Replace(e => e.OtherDemographicIntake.Disabled, DemographicRequest.OtherDemographicIntake.Disabled);
            patchDoc.Replace(e => e.OtherDemographicIntake.UndueBurden, DemographicRequest.OtherDemographicIntake.UndueBurden);

            var result = await _demographicIntakesDataService.UpdateDemographicIntakeAsync(DemographicResponse.Id, patchDoc);
            if (result?.Succeeded == true)
            {
                _snackbar.Add(_messageResources[MessageResources.DemographicIntakeSuccessfullyCompleted], Severity.Success);
            }
            else
            {
                foreach (var message in result?.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }


            IsBusy = false;
            StateHasChanged();
        }

    }
}