using System.ComponentModel.DataAnnotations;

namespace Blazor.Wasm.UI.Models
{
    public class CustomerModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        [StringLength(50,ErrorMessage ="First Name is too Long")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(50, ErrorMessage = "Last Name is too Long")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Email name is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Range(1,100,ErrorMessage = "Gender is not valid")]
        public int GenderId { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Range(1, 100, ErrorMessage = "Country is invalid")]
        public int CountryId { get; set; }
        public string MailingAddress { get; set; }

        [Required(ErrorMessage = "IsSubscribedToNewsLetter is required")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "From submission disallows for false")]
        public bool IsSubscribedToNewsLetter { get; set; }


    }
}
