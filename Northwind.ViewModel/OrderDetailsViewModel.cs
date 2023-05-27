using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace Northwind.ViewModel
{
    public class OrderDetailsViewModel : ToolViewModel
    {
        private readonly IToolManager _toolManager;
        public OrderViewModel Order { get; set; }

        public ICommand ShowCustomerDetailsCommand
        {
            get
            {
                return new RelayCommand(() => _toolManager.OpenCustomerDetails(Order.Customer.CustomerId));
            }
        }

        public OrderDetailsViewModel(OrderViewModel order, IToolManager toolManager) : base(toolManager)
        {
            _toolManager = toolManager;
            Order = order;
            DisplayName = $"{Order.Customer.CustomerId} : {Order.Model.OrderId}";
        }
    }
}