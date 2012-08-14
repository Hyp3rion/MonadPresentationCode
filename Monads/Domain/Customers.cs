using Monads.Extensions;

namespace Monads.Domain
{
    public class Customers
    {
        readonly Repository _repository;

        public Customers(Repository repository)
        {
            _repository = repository;
        }

        public string GetPostcodeOfCustomerAndValidateAddress(int customerId)
        {
            string postcode = _repository
                .GuardWith(new RepositoryNotInitializedException())
                .GetCustomer(123)
                .IfNotNull(x => x.Address)
                .Do(ValidateAddress)
                .IfNotNull(x => x.PostCode)
                .Return(x => x.ToString(), "unknown");

            return postcode;
        }

        void ValidateAddress(Address address)
        {
            if (address.PostCode != null && !string.IsNullOrEmpty(address.CountryId))
            {
                CheckIfZipCodeMatchesCountry(address.PostCode, address.CountryId);
            }
        }

        void CheckIfZipCodeMatchesCountry(PostCode postCode, string countryId)
        {
            /* validates zip code */
        }
    }
}