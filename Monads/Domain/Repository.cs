namespace Monads.Domain
{
    public class Repository
    {
        readonly Customer _customer;

        public Repository(Customer customer)
        {
            _customer = customer;
        }

        public Customer GetCustomer(int id)
        {
            return _customer;
        }
    }
}