using Blazor.Wasm.UI.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Wasm.UI.Pages
{
    public partial class GrandChild
    {
        [CascadingParameter]
        public string ClassName { get; set; }
    }
}
