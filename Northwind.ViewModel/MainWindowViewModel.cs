using GalaSoft.MvvmLight.Command;
using Northwind.Application;
using Northwind.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Northwind.ViewModel
{
    public class MainWindowViewModel
    {
        private readonly IUiDataProvider _dataProvider;
        private readonly IToolManager _toolManager;
        public ObservableCollection<ToolViewModel> Tools => _toolManager.Tools;

        public string Name => "Northwind";
        public string ControlPanelName => "Control Panel";
        
        private IList<Customer> _customers;
        public IList<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    GetCustomers();
                }

                return _customers; 
            }
        }

        private RelayCommand _showDetailsCommand;
        public RelayCommand ShowDetailsCommand
        {
            get
            {
                return _showDetailsCommand ??
                       (_showDetailsCommand =
                           new RelayCommand(
                               ShowCustomerDetails,
                               IsCustomerSelected));
            }
        }

        private string _selectedCustomerId;
        public string SelectedCustomerId
        {
            get => _selectedCustomerId;
            set
            {
                _selectedCustomerId = value;
                ShowDetailsCommand.RaiseCanExecuteChanged();
            }
        }


        public MainWindowViewModel(IUiDataProvider uiDataProvider, IToolManager toolManager)
        {
            _dataProvider = uiDataProvider;
            _toolManager = toolManager;
        }
        
        private void GetCustomers()
        {
            _customers = _dataProvider.GetCustomers();
        }

        public void ShowCustomerDetails()
        {
            if(!IsCustomerSelected())
                throw new InvalidOperationException("Unable to show customer because no customer is selected.");

            _toolManager.OpenCustomerDetails(SelectedCustomerId);
        }

        public bool IsCustomerSelected()
        {
            return !string.IsNullOrEmpty(SelectedCustomerId);
        }
    }
}
