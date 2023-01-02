using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.RootComponents.Dialogs
{
    public partial class SelectServiceDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; }
        [CascadingParameter] public HubConnection hubConnection { get; set; }
        [Parameter] public string UserId { get; set; } = string.Empty;
        public List<SectionResponse> AvailableSections { get; set; } = new();
        [Required]
        public SectionResponse SelectedSection { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            await LoadAvailableServicesAsync();

            //SignalR
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
        }

        private async Task LoadAvailableServicesAsync()
        {
            IsLoading = true;
            var result = await _sectionDataService.GetSectionsAsync();
            if (result?.Succeeded == true)
            {
                AvailableSections = result.Data;
            }
            else
            {
                foreach (var message in result?.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
            IsLoading = false;
        }

        private async void SubmitAsync()
        {
            if (SelectedSection != null)
            {
                var caseRequest = new CaseRequest
                {
                    CaseNo = "1",
                    StartDate = DateTime.UtcNow,
                    Status = CaseStatusEnum.InProgress,
                    UserId = UserId,
                };
                //TODO : Check Other Case
                var caseResponse = await _caseDataService.CreateNewCaseAsync(caseRequest);
                if (caseResponse?.Succeeded == true)
                {
                    var caseId = caseResponse.Data;

                    var visitRequest = new VisitRequest
                    {
                        CaseId = caseId,
                        Status = VisitStatusEnum.InProgress,
                    };
                    //TODO : Check Other Visits
                    var visitResponse = await _visitDataService.CreateNewVisitAsync(visitRequest);
                    if (visitResponse?.Succeeded == true)
                    {
                        var visitId = visitResponse.Data;
                        var visitSectionResponse = await _visitDataService.AddTasksAsync(visitId, SelectedSection?.Id);
                        if (visitSectionResponse?.Succeeded == true)
                        {
                            MudDialog.Close(DialogResult.Ok(true));
                        }
                        else
                        {
                            //Error Handling for visitSections
                            foreach (var message in visitSectionResponse?.Messages)
                            {
                                _snackbar.Add(message, Severity.Error);
                            }
                        }
                    }
                    else
                    {
                        //Error Handling visit
                        foreach (var message in visitResponse?.Messages)
                        {
                            _snackbar.Add(message, Severity.Error);
                        }
                    }
                }
                else
                {
                    //Error Handling case
                    //TODO : Make sure visit and case deleted.
                    foreach (var message in caseResponse?.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }

        }
        private void Cancel()
        {
            MudDialog.Cancel();
        }

    }
}