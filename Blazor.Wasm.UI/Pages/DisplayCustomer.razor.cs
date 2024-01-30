using Blazor.Wasm.UI.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace Blazor.Wasm.UI.Pages
{
    public partial class DisplayCustomer
    {

        [Parameter]
        public CustomerModel customer { get;set; } = new CustomerModel();

        [Inject]
        IMatToaster Toaster { get; set; }

        [Inject]
        HttpClient Http { get; set; }

        public async Task OnHandleDelete(int customerId)
        {
            await Http.DeleteAsync($"api/Customer/{customerId}");
            Toaster.Add($"Customer  deleted", MatToastType.Success);
        }
    }
}
