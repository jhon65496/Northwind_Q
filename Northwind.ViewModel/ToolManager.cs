using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Northwind.ViewModel
{
    public class ToolManager : IToolManager
    {
        private readonly ICustomerDetailsViewModelFactory _customerDetailsFactory;
        private readonly IOrderDetailsViewModelFactory _orderDetailsFactory;
        public readonly ICollectionView _toolCollectionView;

        public ObservableCollection<ToolViewModel> Tools { get; set; }

        public ToolManager(ICustomerDetailsViewModelFactory customerDetailsFactory, IOrderDetailsViewModelFactory orderDetailsFactory)
        {
            _customerDetailsFactory = customerDetailsFactory;
            _orderDetailsFactory = orderDetailsFactory;

            Tools = new ObservableCollection<ToolViewModel>();
            _toolCollectionView = CollectionViewSource.GetDefaultView(Tools);
        }

        public void OpenCustomerDetails(string customerId)
        {
            OpenTool(c => c.Customer.CustomerId == customerId, 
                () => _customerDetailsFactory.CreateInstance(customerId));
        }

        public void OpenOrderDetails(OrderViewModel order)
        {
            OpenTool(o => o.Order.Model.OrderId == order.Model.OrderId, 
                () => _orderDetailsFactory.CreateInstance(order));
        }

        public void CloseTool(ToolViewModel tool)
        {
            Tools.Remove(tool);
        }

        private void OpenTool<T>(Func<T, bool> predicate, Func<T> toolFactory) where T : ToolViewModel
        {
            var tool = Tools.OfType<T>().FirstOrDefault(t => predicate.Invoke((T)t));
            if (tool == null)
            {
                tool = toolFactory.Invoke();
                Tools.Add(tool);
            }

            SetCurrentTool(tool);
        }

        private void SetCurrentTool<T>(T currentTool) where T : ToolViewModel
        {
            if (_toolCollectionView.MoveCurrentTo(currentTool) != true)
            {
                throw new InvalidOperationException("Could not find the current tool.");
            }
        }

    }
}
