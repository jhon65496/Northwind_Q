using StructureMap;

namespace Northwind.ViewModel
{
    public class OrderDetailsViewModelFactory : IOrderDetailsViewModelFactory
    {
        private readonly IContainer _container;

        public OrderDetailsViewModelFactory(IContainer container)
        {
            _container = container;
        }

        public OrderDetailsViewModel CreateInstance(OrderViewModel order)
        {
            return _container.With("order").EqualTo(order).GetInstance<OrderDetailsViewModel>();
        }
    }
}