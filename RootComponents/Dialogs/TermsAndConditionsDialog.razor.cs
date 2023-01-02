using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace WRMC.RootComponents.Dialogs
{
    public partial class TermsAndConditionsDialog
    {

        [CascadingParameter] public MudDialogInstance MudDialog { get; set; }

        public bool IsAccepted { get; set; } = false;
        public void OnSubmit()
        {
            MudDialog.Close(DialogResult.Ok(IsAccepted));
        }
        private void Cancel()
        {
            MudDialog.Cancel();
        }

    }
}