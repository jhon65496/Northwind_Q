using Northwind.Data;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly NorthwindEntities _northwindEntities = new NorthwindEntities();

        public IList<Customer> GetCustomers()
        {
            return _northwindEntities.Customers
                .Select(
                    c => new Customer
                    {
                        CustomerId = c.CustomerID,
                        CompanyName = c.CompanyName
                    }).ToList();
        }

        public Customer GetCustomer(string customerId)
        {
            Data.Customer customer = _northwindEntities.Customers
                .Single(c => c.CustomerID.Equals(customerId));

            return new Customer
            {
                CustomerId = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                Address = customer.Address,
                City = customer.City,
                Country = customer.Country,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Phone = customer.Phone,
                Orders = GetOrders(customer.Orders),
            };
        }

        private IEnumerable<Order> GetOrders(ICollection<Data.Order> orders)
        {
            return orders.Select(o => new Order
            {
                OrderId = o.OrderID,
                OrderDate = o.OrderDate,
                OrderDetails = GetDetails(o),
                Freight = o.Freight,
                ShippedDate = o.ShippedDate,
            }).ToList();
        }

        private IEnumerable<OrderDetail> GetDetails(Data.Order order)
        {
            return order.Order_Details.Select(
                o => new OrderDetail
                {
                    Product = new Product
                    {
                        ProductId = o.Product.ProductID,
                        ProductName = o.Product.ProductName,
                    },
                    Quantity = o.Quantity,
                    UnitPrice = o.UnitPrice,
                }).ToList();
        }

        public void Update(Customer customer)
        {
            Data.Customer customerEntity = _northwindEntities.Customers.Single(
                c => c.CustomerID.Equals(customer.CustomerId));

            customerEntity.CompanyName = customer.CompanyName;
            customerEntity.ContactName = customer.ContactName;
            customerEntity.Address = customer.Address;
            customerEntity.City = customer.City;
            customerEntity.Country = customer.Country;
            customerEntity.Region = customer.Region;
            customerEntity.PostalCode = customer.PostalCode;
            customerEntity.Phone = customer.Phone;
        }
    }
}