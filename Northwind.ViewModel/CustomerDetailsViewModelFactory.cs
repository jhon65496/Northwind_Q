using StructureMap;

namespace Northwind.ViewModel
{
    public class CustomerDetailsViewModelFactory : ICustomerDetailsViewModelFactory
    {
        private readonly IContainer _container;

        public CustomerDetailsViewModelFactory(IContainer container)
        {
            _container = container;
        }

        public CustomerDetailsViewModel CreateInstance(string customerId)
        {
            return _container.With("customerId").EqualTo(customerId).GetInstance<CustomerDetailsViewModel>();
        }
    }
}