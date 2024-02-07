using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace Blazor.Wasm.UI.Pages.Shared
{
    public partial class ConfirmationDialog
    {

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Message { get; set; }

        [Parameter]
        public string OkText { get; set; } = "OK";

        [Parameter]
        public string CancelText { get; set; } = "No, Thanks";

        [CascadingParameter]
        MatDialogReference MatDialogReference { get; set; }
        public void Confirm()
        {
            this.MatDialogReference.Close(true);
        }
        public void Cancel()
        {
            this.MatDialogReference.Close(false);
        }
    }
}
