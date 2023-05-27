using Northwind.Model;

namespace Northwind.ViewModel
{
    public interface IOrdersViewModelFactory
    {
        OrdersViewModel CreateInstance(Customer customer);
    }
}