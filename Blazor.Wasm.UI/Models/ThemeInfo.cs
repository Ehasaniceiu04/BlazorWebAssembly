namespace Blazor.Wasm.UI.Models
{
    public class ThemeInfo
    {
        public ThemeInfo(string submitButtonClass, string editButtonClass, string deleteButtonClass)
        {
            SubmitButtonClass = submitButtonClass;
            EditButtonClass = editButtonClass;
            DeleteButtonClass = deleteButtonClass;
        }
        public string SubmitButtonClass { get; private set; }

        public string EditButtonClass { get; private set; }

        public string DeleteButtonClass { get; private set; }
    }
}
