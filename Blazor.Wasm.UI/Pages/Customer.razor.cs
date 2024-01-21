using Blazor.Wasm.UI.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;





namespace Blazor.Wasm.UI.Pages
{
    public partial class Customer
    {
        [Inject]
        private HttpClient Http { get; set; }
        [Inject]
        IMatToaster Toaster { get; set; }

        CustomerModel customerModel = new CustomerModel();

        List<GenderModel> genders = new List<GenderModel>() {
            new GenderModel(){Id = 1, Name ="Male"},
             new GenderModel(){Id = 2, Name ="Female"},
              new GenderModel(){Id = 3, Name ="Other"},
        };

        List<CountryModel> countries = new List<CountryModel>() {
            new CountryModel(){Id = 1, Name ="USA" },
            new CountryModel(){Id = 2, Name ="Bangladesh"},
             new CountryModel(){Id = 3, Name ="Nepal"},
             new CountryModel(){Id = 4, Name ="India"}
        };

        async void HandleValidSubmit()
        {
            try
            {
                await Http.PostAsJsonAsync<CustomerModel>("api/customer", customerModel);
                this.Toaster.Add("customer created successfully", MatToastType.Success, "Customer Creation");
            }
            catch (Exception ex)
            {
                this.Toaster.Add(ex.Message, MatToastType.Danger, "Customer Creation");
            }
            ;
        }
    }
}
