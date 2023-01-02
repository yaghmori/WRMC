using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace WRMC.RootComponents.Shared
{
    public partial class MessageDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public string ContentText { get; set; } = "";
        [Parameter]
        public string ButtonText { get; set; } = "OK";
        [Parameter]
        public string ButtonIcon { get; set; } = "";
        [Parameter]
        public string TitleIcon { get; set; } = "";
        [Parameter]
        public string Title { get; set; } = "";

        [Parameter]
        public Color ButtonColor { get; set; } = Color.Primary;
        [Parameter]
        public Variant ButtonVariant { get; set; } = Variant.Filled;
        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();
    }
}