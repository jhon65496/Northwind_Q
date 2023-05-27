namespace Northwind.ViewModel
{
    public interface ICustomerDetailsViewModelFactory
    {
        CustomerDetailsViewModel CreateInstance(string customerId);
    }
}
