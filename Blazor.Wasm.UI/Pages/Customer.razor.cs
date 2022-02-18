using Blazor.Wasm.UI.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace Blazor.Wasm.UI.Pages
{
    public partial class Customer
    {
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
        void HandleInvalidSubmit()
        {
            this.Toaster.Add("Form submitted with invalid fields", MatToastType.Success, "Customer Creation");
        }
        void HandleValidSubmit()
        {
            this.Toaster.Add("Form submitted with valid fields", MatToastType.Success, "Customer Creation");
        }
    }
}
