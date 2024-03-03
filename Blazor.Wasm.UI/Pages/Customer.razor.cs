using Blazor.Wasm.UI.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;


namespace Blazor.Wasm.UI.Pages
{
    public partial class Customer : ComponentBase
    {
        [CascadingParameter]
        public ThemeInfo ThemeInfo { get; set; }
        [Inject]
        private IMatDialogService MatDialogService { get; set; }
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
            this.customers = customers.Where(x => x.Id != customerId).ToList();
        }


        private async Task HandleCustomerCreate()
        {
            MatDialogOptions options = new MatDialogOptions();
            options.Attributes=new Dictionary<string, object>() { 
                { "Title", "Create Customer" },
                { "customerModel", new CustomerModel() }
            };
            var isCreated = await this.MatDialogService.OpenAsync(typeof(CustomerEditDialog), options);
            if ((bool)isCreated)
            {
                this.customers = await Http.GetFromJsonAsync<List<CustomerModel>>("api/Customer");
            }
        }
        private async Task HandleCustomerUpdated()
        {
            this.customers = await Http.GetFromJsonAsync<List<CustomerModel>>("api/Customer");
        }
        private void OnHandleEdit(CustomerModel customer)
        {

        }




    }
}
