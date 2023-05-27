using Northwind.Model;
using StructureMap;

namespace Northwind.ViewModel
{
    public class OrdersViewModelFactory : IOrdersViewModelFactory
    {
        private readonly IContainer _container;

        public OrdersViewModelFactory(IContainer container)
        {
            _container = container;
        }

        public OrdersViewModel CreateInstance(Customer customer)
        {
            return _container.With("model").EqualTo(customer).GetInstance<OrdersViewModel>();
        }
    }
}