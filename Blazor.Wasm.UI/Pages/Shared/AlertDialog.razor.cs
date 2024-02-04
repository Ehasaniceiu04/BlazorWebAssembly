using MatBlazor;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace Blazor.Wasm.UI.Pages.Shared
{
    public partial class AlertDialog
    {
        [Parameter]
        public string Title { get; set; } = "Alert";
        [Parameter]
        public string Message { get; set; }

        [Parameter]
        public string OkText { get; set; } = "OK";

        [CascadingParameter]
        public MatDialogReference MatDialogReference { get; set; }

        public void OnClose()
        {
            MatDialogReference.Close(false);
        }
    }
}
