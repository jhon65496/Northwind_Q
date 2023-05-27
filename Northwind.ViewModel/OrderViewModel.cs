using GalaSoft.MvvmLight;
using Northwind.Model;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Northwind.ViewModel
{
    public class OrderViewModel : ViewModelBase
    {
        private readonly IToolManager _toolManager;
        public Customer Customer { get; set; }

        public const string ModelPropertyName = "Model";
        private Order _model;
        public Order Model
        {
            get => _model;
            set
            {
                if (_model == value)
                    return;

                _model = value;
                RaisePropertyChanged(ModelPropertyName);
                RaisePropertyChanged(TotalPropertyName);
            }
        }

        public const string TotalPropertyName = "Total";
        public decimal Total
        {
            get
            {
                return _model.OrderDetails.Sum(o => o.Quantity + o.UnitPrice);
            }
        }

        public ICommand ShowOrderDetailsCommand
        {
            get
            {
                return new RelayCommand(() => _toolManager.OpenOrderDetails(this));
            }
        }

        public OrderViewModel(Order model, Customer customer, IToolManager toolManager)
        {
            _model = model;
            Customer = customer;
            _toolManager = toolManager;
            SubscribeToOrderDetailsChanges(_model);
        }

        private void SubscribeToOrderDetailsChanges(Order order)
        {
            order.PropertyChanged += OnOrderPropertyChanged;
            foreach (var orderDetail in order.OrderDetails)
            {
                orderDetail.PropertyChanged += OnOrderPropertyChanged;
            }
        }

        private void UnSubscribeToOrderDetailsChanges(Order order)
        {
            order.PropertyChanged -= OnOrderPropertyChanged;
            foreach (var orderDetail in order.OrderDetails)
            {
                orderDetail.PropertyChanged -= OnOrderPropertyChanged;
            }
        }

        private void OnOrderPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case Order.FreightPropertyName:
                case OrderDetail.QuantityPropertyName:
                case OrderDetail.UnitPricePropertyName:
                    RaisePropertyChanged(TotalPropertyName);
                    break;
            }
        }

        public override void Cleanup()
        {
            UnSubscribeToOrderDetailsChanges(Model);
            base.Cleanup();
        }
    }
}
