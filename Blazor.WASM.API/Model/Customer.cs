namespace Blazor.WASM.API.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int GenderId { get; set; }

        public int CountryId { get; set; }
        public string? MailingAddress { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
    }
}
