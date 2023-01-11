using Microsoft.AspNetCore.Components;
using MudBlazor;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Dialogs;

namespace WRMC.RootComponents.Pages
{
    public partial class Visits
    {
        [CascadingParameter]
        public UserResponse User { get; set; } = new();
        public List<VisitResponse> VisitResponses { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadVisitsAsync();
        }
        public async Task MakeAnAppointmentAsync()
        {
            var parameters = new DialogParameters { { "UserId", User.Id } };
            var options = new DialogOptions()
            {
                CloseButton = true,
                DisableBackdropClick = true,
                FullWidth = true,
                MaxWidth = MaxWidth.ExtraSmall
            };
            var dialog = _dialog.Show<SelectServiceDialog>(_viewLocalizer[ViewResources.MakeAnAppointment], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                //TODO : using SignalR
                await LoadVisitsAsync();
            }

        }
        public void OnCommandSubmit(string visitId, string uri)
        {
            _navigationManager.NavigateTo(uri + "/" + visitId);

        }
        public async Task LoadVisitsAsync()
        {
            var response = await _visitDataService.GetVisitsAsync();
            if (response?.Succeeded == true)
            {
                VisitResponses = response.Data;
            }
            else
            {
                foreach (var message in response?.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
        }
    }
}