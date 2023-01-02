using Microsoft.AspNetCore.Components;
using MudBlazor;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.RootComponents.Dialogs
{
    public partial class SelectIntroMethodDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        private IntroMethodResponse? SelectedItem { get; set; }
        public IEnumerable<IntroMethodResponse> IntroMethodCollection { get; set; } = new HashSet<IntroMethodResponse>();
        public IntroMethodResponse SelectedIntroMethod { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            var introMethodResponse = await _introMethodDataService.GetIntroMethodsAsync();
            if (introMethodResponse?.Succeeded==true)
            {
                IntroMethodCollection = new HashSet<IntroMethodResponse>(introMethodResponse.Data);

            }
            else
            {
                foreach (var message in introMethodResponse?.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }

            IsLoading = false;

        }
        public async Task<bool> OnExpanding(IntroMethodResponse context)
        {
            context.IsExpanded = !context.IsExpanded;
            return context.IsExpanded;
        }

        private async void OnItemClicked(IntroMethodResponse context)
        {
            if (context != null && context.Type == TreeTypeEnum.Leaf)
            {
                MudDialog.Close(DialogResult.Ok(context));
            }
        }
    }
}