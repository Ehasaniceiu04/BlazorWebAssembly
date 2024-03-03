using Blazor.Wasm.UI.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;





namespace Blazor.Wasm.UI.Pages
{
    public partial class CustomerEditDialog
    {
        [CascadingParameter]
        public ThemeInfo ThemeInfo { get; set; }


        [Inject]
        private HttpClient Http { get; set; }
        [Inject]
        IMatToaster Toaster { get; set; }

        [Parameter]
        public  string Title { get; set; }

        [Parameter]
        public CustomerModel customerModel { get; set; }=new CustomerModel();

        [CascadingParameter]
        public MatDialogReference DialogReference { get; set; }

        

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
                if (customerModel.Id > 0)
                {
                    await Http.PutAsJsonAsync<CustomerModel>("api/customer", customerModel);
                    this.Toaster.Add("customer updated successfully", MatToastType.Success, "Customer Update");
                }
                else
                {
                    await Http.PostAsJsonAsync<CustomerModel>("api/customer", customerModel);
                    this.Toaster.Add("customer created successfully", MatToastType.Success, "Customer Creation");
                }
               this.DialogReference.Close(true);

            }
            catch (Exception ex)
            {
                this.Toaster.Add(ex.Message, MatToastType.Danger, "Customer Creation");
            }
            ;
        }

        public void OnHandleClose() {
            this.DialogReference.Close(false);
        }

    }
}
