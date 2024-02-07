using Blazor.Wasm.UI.Models;
using Blazor.Wasm.UI.Pages.Shared;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace Blazor.Wasm.UI.Pages
{
    public partial class DisplayCustomer
    {
        [Parameter]
        public EventCallback<int> OnDelete { get; set; }
        [Parameter]
        public CustomerModel customer { get; set; } = new CustomerModel();

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
                MatDialogOptions options = new MatDialogOptions();
                options.Attributes=new Dictionary<string, object>
                {
                    { "Title", "Delete Action?" },
                    { "Message", "Are you sure you want to delete this customer?" },
                    { "OkText", "Yes, Delete" },
                    { "CancelText", "No, Thanks" }
                };
                var isConfirmed = await MatDialogService.OpenAsync(typeof(ConfirmationDialog),options);
                if ((bool)isConfirmed)
                {
                    await Http.DeleteAsync($"api/Customer/{customer.Id}");
                    Toaster.Add($"Customer  deleted", MatToastType.Success);
                    await OnDelete.InvokeAsync(customer.Id);
                }  

            }
            else
            {
                MatDialogOptions options = new MatDialogOptions()
                {
                    Attributes = new Dictionary<string, object> {
                        { "Message", "Customer has orders and cannot be deleted" },
                        { "Title", "Delete Action" },
                        { "OkText", "Acknowledge" }
                    },
                };
                await MatDialogService.OpenAsync(typeof(AlertDialog), options);
            }

        }
    }
}
