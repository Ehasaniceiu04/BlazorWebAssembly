using Blazor.Wasm.UI.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;


namespace Blazor.Wasm.UI.Pages
{
    public partial class Customer : ComponentBase
    {

        List<CustomerModel> customers = new List<CustomerModel>();

        [Inject]
        private HttpClient Http { get; set; }
        public Customer()
        {

        }
        protected override async Task OnInitializedAsync()
        {
            this.customers = await Http.GetFromJsonAsync<List<CustomerModel>>("api/Customer");
        }

        private async Task Reload(int customerId)
        {
            this.customers =customers.Where(x => x.Id != customerId).ToList();
        }

        private CustomerEditDialog customerDialog;
        private void HandleCustomerCreate()
        {
            customerDialog.OpenDialog(new CustomerModel());
        }
        private async Task HandleCustomerUpdated()
        {
            this.customers = await Http.GetFromJsonAsync<List<CustomerModel>>("api/Customer");
        }
        private void OnHandleEdit(CustomerModel customer) {
            customerDialog.OpenDialog(customer);
        }




    }
}
