namespace Monads.Domain
{
    public class Address
    {
        public PostCode PostCode { get; set; }
        public string CountryId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}