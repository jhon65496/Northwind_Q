using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Application.CustomerService;
using Customer = Northwind.Model.Customer;

namespace Northwind.Application
{
    public class UiDataProvider : IUiDataProvider
    {
        private readonly ICustomerService _customerServiceClient;
        private IList<Customer> _customers;

        public UiDataProvider(ICustomerService customerServiceClient)
        {
            _customerServiceClient = customerServiceClient;
        }

        public IList<Customer> GetCustomers()
        {
            try
            {
                return _customers ??
                       (_customers = _customerServiceClient.GetCustomers()
                           .Select(c => CustomerTranslator.Instance.CreateModel(c)).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Customer GetCustomer(string customerId)
        {
            try
            {
                return CustomerTranslator.Instance.UpdateModel(
                    _customers
                        .FirstOrDefault(c => c.CustomerId.Equals(customerId)),
                    _customerServiceClient.GetCustomer(customerId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Customer customer)
        {
            _customerServiceClient.Update(CustomerTranslator.Instance.CreateDto(customer));
        }
    }

    internal static class CustomerExtensions
    {
        public static Customer Update(this Customer customer, Customer existingCustomer)
        {
            customer.ContactName = existingCustomer.ContactName;
            customer.Address = existingCustomer.Address;
            customer.City = existingCustomer.City;
            customer.Region = existingCustomer.Region;
            customer.Country = existingCustomer.Country;
            customer.Phone = existingCustomer.Phone;
            
            return customer;
        }
    }
}
