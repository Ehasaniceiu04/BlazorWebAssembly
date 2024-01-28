using Blazor.Wasm.UI.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Wasm.UI.Pages
{
    public partial class DisplayCustomer
    {

        [Parameter]
        public CustomerModel customer { get;set; } = new CustomerModel();
    }
}
