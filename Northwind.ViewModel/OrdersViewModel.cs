using GalaSoft.MvvmLight;
using Northwind.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace Northwind.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }

        public OrdersViewModel(Customer model, IOrderViewModelFactory orderViewModelFactory)
        {
            Orders = new ObservableCollection<OrderViewModel>(model.Orders.Select(o => orderViewModelFactory.CreateInstance(o, model)));
        }
    }
}
