using Blazor.Wasm.UI.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Wasm.UI.Pages
{
    public partial class ChildCounter
    {
        private int currentCount = 0;

        public void IncrementCount()
        {
            currentCount++;
            StateHasChanged();
        }
    }
}
