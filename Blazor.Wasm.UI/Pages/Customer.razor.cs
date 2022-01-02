using Blazor.Wasm.UI.Models;

namespace Blazor.Wasm.UI.Pages
{
    public partial class Customer
    {
        CustomerModel model = new CustomerModel();

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
    }
}
