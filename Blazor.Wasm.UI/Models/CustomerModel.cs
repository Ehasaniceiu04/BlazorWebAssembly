namespace Blazor.Wasm.UI.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int GenderId { get; set; }
        public int CustomerId { get; set; }
        public string MailingAddress { get; set; }

        public bool IsAgreeToGetPromotionalEmail { get; set; }


    }
}
