namespace Northwind.ViewModel
{
    public interface IOrderDetailsViewModelFactory
    {
        OrderDetailsViewModel CreateInstance(OrderViewModel order);
    }
}