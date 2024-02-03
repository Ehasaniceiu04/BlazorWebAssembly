using Blazor.Wasm.UI.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace Blazor.Wasm.UI.Pages
{
    public partial class DisplayCustomer
    {
        [Parameter]
        public EventCallback<int> OnDelete { get; set; }
        [Parameter]
        public CustomerModel customer { get;set; } = new CustomerModel();

        [Inject]
        IMatToaster Toaster { get; set; }

        [Inject]
        HttpClient Http { get; set; }

        [Inject]

        IMatDialogService MatDialogService { get; set; }

        public async Task OnHandleDelete(CustomerModel customer)
        {
            if (!customer.HasOrder)
            {
                await Http.DeleteAsync($"api/Customer/{customer.Id}");
                Toaster.Add($"Customer  deleted", MatToastType.Success);
                await OnDelete.InvokeAsync(customer.Id);
            }
            else
            {
                await MatDialogService.AlertAsync($"Customer has orders and cannot be deleted");
                //  Toaster.Add($"Customer has orders and cannot be deleted", MatToastType.Warning);
            }
            
        }
    }
}
