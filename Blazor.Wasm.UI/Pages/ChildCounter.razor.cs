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
