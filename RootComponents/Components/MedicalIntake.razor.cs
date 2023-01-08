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
    public partial class MedicalIntake : IDisposable
    {
        [Parameter] public EventCallback<bool> OnValidationChanged { get; set; }
        [Parameter, EditorRequired] public MedicalIntakeRequest Model { get; set; } = new();
         public MedicalIntakeResponse ResponseModel { get; set; } = new();
         public string MedicalId { get; set; } 
        [Parameter, EditorRequired] public string TaskId { get; set; } = string.Empty;
        public EditContext EditContext { get; set; }


        protected async override Task OnInitializedAsync()
        {
            IsLoading = true;
            EditContext = new EditContext(Model);


            var medicalResponse = await _medicalIntakesDataService.GetMedicalIntakeByTaskIdAsync(TaskId);
            if (medicalResponse?.Succeeded == true)
            {
                if (medicalResponse?.Data != null) //Get previous medical form 
                {
                    ResponseModel = medicalResponse.Data;
                    MedicalId =  medicalResponse.Data.Id;
                    Model = _autoMapper.Map<MedicalIntakeRequest>(medicalResponse.Data);
                }
                else //if null create a new instance
                {

                    var visitResponse = await _visitDataService.GetVisitByTaskIdAsync(TaskId);
                    if (visitResponse?.Succeeded == true)
                    {
                        var request = new IntakeBaseRequest
                        {
                            TaskId = TaskId,
                            VisitId = visitResponse.Data.Id,
                            IsComplete = false
                        };

                        var result = await _medicalIntakesDataService.CreateNewMedicalIntakeAsync(request);
                        if (result?.Succeeded == true)
                        {
                            MedicalId =  result.Data;
                            ResponseModel.Id = result.Data;
                            Model = new();
                            Model.VisitId = visitResponse.Data.Id;
                            Model.TaskId = TaskId;
                        }
                    }
                }
            }

            await OnValidationChanged.InvokeAsync(EditContext.Validate());
            EditContext.OnFieldChanged += EditContext_OnFieldChanged;
            IsLoading = false;
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
        private async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            var patchDoc = new JsonPatchDocument<MedicalIntakeRequest>();

            patchDoc.Replace(e => e.AbortionDate,Model.AbortionDate);
          

            var result = await _medicalIntakesDataService.UpdateMedicalIntakeAsync(MedicalId, patchDoc); //api call
            if (result?.Succeeded == true)
            {
                _snackbar.Add("Medical intake successfully completed.", Severity.Success); //TODO : Localization
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