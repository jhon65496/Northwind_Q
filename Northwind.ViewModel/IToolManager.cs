using System.Collections.ObjectModel;

namespace Northwind.ViewModel
{
    public interface IToolManager
    {
        ObservableCollection<ToolViewModel> Tools { get; set; }
        void OpenCustomerDetails(string customerId);
        void OpenOrderDetails(OrderViewModel order);
        void CloseTool(ToolViewModel tool);
    }
}