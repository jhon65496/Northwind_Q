using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using Northwind.Application;
using Northwind.Model;

namespace Northwind.ViewModel
{
    public class CustomerDetailsViewModel : ToolViewModel
    {
        private readonly IUiDataProvider _dataProvider;
        private readonly IOrdersViewModelFactory _ordersViewModelFactory;
        private bool _isDirty;

        public Customer Customer { get; set; }

        private OrdersViewModel _orders;
        public OrdersViewModel Orders
        {
            get
            {
                if (Customer == null)
                    return null;

                return _orders ?? (_orders = _ordersViewModelFactory.CreateInstance(Customer));
            }
        }

        private RelayCommand _updateCommand;
        public RelayCommand UpdateCommand =>  _updateCommand ?? (_updateCommand = new RelayCommand(UpdateCustomer, CanUpdateCustomer));

        public CustomerDetailsViewModel(IUiDataProvider uiDataProvider, string customerId, IOrdersViewModelFactory ordersViewModelFactory, 
            IToolManager toolManager = null) : base(toolManager)
        {
            _dataProvider = uiDataProvider;
            _ordersViewModelFactory = ordersViewModelFactory;
            Customer = _dataProvider.GetCustomer(customerId);
            DisplayName = Customer.CompanyName;
            Customer.PropertyChanged += CustomerOnPropertyChanged;
        }

        public bool CanUpdateCustomer()
        {
            return _isDirty;
        }

        private void UpdateCustomer()
        {
            _dataProvider.Update(Customer);
            _isDirty = false;
            UpdateCommand.RaiseCanExecuteChanged();
        }

        private void CustomerOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _isDirty = true;
            UpdateCommand.RaiseCanExecuteChanged();
        }
    }
}