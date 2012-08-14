using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monads.Domain;

// ReSharper disable InconsistentNaming
namespace MonadTests
{
    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public void Get_postcode_of_customer_with_postcode_12345_returns_12345()
        {
            var customer = new Customer { Address = new Address { PostCode = new PostCode("12345") } };
            var repo = new Repository(customer);
            var customers = new Customers(repo);

            var postcode = customers.GetPostcodeOfCustomerAndValidateAddress(123);

            Assert.AreEqual(postcode, "12345");

            Console.Out.WriteLine(postcode);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryNotInitializedException))]
        public void Get_postcode_of_customer_with_no_repo_throws_RepositoryNotInitializedException()
        {
            var customers = new Customers(null);

            var postcode = customers.GetPostcodeOfCustomerAndValidateAddress(123);
        }

        [TestMethod]
        public void Get_postcode_of_customer_with_no_address_returns_unknown()
        {
            var customer = new Customer();
            var repo = new Repository(customer);
            var customers = new Customers(repo);

            var postcode = customers.GetPostcodeOfCustomerAndValidateAddress(123);

            Assert.AreEqual(postcode, "unknown");

            Console.Out.WriteLine(postcode);
        }

        [TestMethod]
        public void Get_postcode_of_customer_with_address_and_no_postcode_returns_unknown()
        {
            var customer = new Customer { Address = new Address() };
            var repo = new Repository(customer);
            var customers = new Customers(repo);

            var postcode = customers.GetPostcodeOfCustomerAndValidateAddress(123);

            Assert.AreEqual(postcode, "unknown");

            Console.Out.WriteLine(postcode);
        }
    }
}