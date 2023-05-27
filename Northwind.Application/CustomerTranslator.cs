using Northwind.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Northwind.Application
{
    public class CustomerTranslator : IEntityTranslator<Customer, CustomerService.Customer>
    {
        internal static IEntityTranslator<Customer, CustomerService.Customer> _instance;

        public static IEntityTranslator<Customer, CustomerService.Customer> Instance
        {
            get => _instance ?? (_instance = new CustomerTranslator());
            set => _instance = value;
        }

        public Customer CreateModel(CustomerService.Customer dto)
        {
            return UpdateModel(new Customer(), dto);
        }

        public Customer UpdateModel(Customer model, CustomerService.Customer dto)
        {
            if (model.CustomerId != dto.CustomerId)
                model.CustomerId = dto.CustomerId;
            if (model.CompanyName != dto.CompanyName)
                model.CompanyName = dto.CompanyName;
            if (model.ContactName != dto.ContactName)
                model.ContactName = dto.ContactName;
            if (model.Address != dto.Address)
                model.Address = dto.Address;
            if (model.City != dto.City)
                model.City = dto.City;
            if (model.Country != dto.Country)
                model.Country = dto.Country;
            if (model.Phone != dto.Phone)
                model.Phone = dto.Phone;
            if (model.PostalCode != dto.PostalCode)
                model.PostalCode = dto.PostalCode;
            if (model.Region != dto.Region)
                model.Region = dto.Region;

            if (dto.Orders != null)
            {
                model.Orders = GetOrdersFromDto(dto);
            }

            return model;
        }

        private ObservableCollection<Order> GetOrdersFromDto(CustomerService.Customer dto)
        {
            IEnumerable<Order> orders = dto.Orders.Select(
                o => new Order
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    OrderDetails = GetOrderDetailsFromDto(o),
                    Freight = o.Freight,
                    ShippedDate = o.ShippedDate,
                }).ToList();

            return new ObservableCollection<Order>(orders);
        }

        private IEnumerable<OrderDetail> GetOrderDetailsFromDto(CustomerService.Order order)
        {
            return order.OrderDetails.Select(
                od => new OrderDetail
                {
                    Product = GetProductFromDto(od),
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice,
                });
        }

        private Product GetProductFromDto(CustomerService.OrderDetail od)
        {
            return new Product
            {
                ProductId = od.Product.ProductId,
                ProductName = od.Product.ProductName,
            };
        }

        public CustomerService.Customer CreateDto(Customer model)
        {
            return UpdateDto(new CustomerService.Customer(), model);
        }

        public CustomerService.Customer UpdateDto(CustomerService.Customer dto, Customer model)
        {
            if (dto.CustomerId != model.CustomerId)
                dto.CustomerId = model.CustomerId;
            if (dto.CompanyName != model.CompanyName)
                dto.CompanyName = model.CompanyName;
            if (dto.ContactName != model.ContactName)
                dto.ContactName = model.ContactName;
            if (dto.Address != model.Address)
                dto.Address = model.Address;
            if (dto.Region != model.Region)
                dto.Region = model.Region;
            if (dto.Country != model.Country)
                dto.Country = model.Country;
            if (dto.PostalCode != model.PostalCode)
                dto.PostalCode = model.PostalCode;
            return dto;
        }
    }
}