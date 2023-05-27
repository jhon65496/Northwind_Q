using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Application;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Rhino.Mocks;
using System.Windows.Data;
using Northwind.Model;

namespace Northwind.ViewModel.Tests
{
    [TestClass]
    public class MainWindowViewModelTest
    {
        private string _expectedCustomerId = "EXPECTEDID";
        private string _expectedCustomerCompanyName = "EXPECTEDCOMPANYNAME";

        [TestMethod]
        public void Customers_Always_CallsGetCustomers()
        {
            // Create Stub
            IUiDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            uiDataProviderMock.Expect(c => c.GetCustomers());
            IToolManager toolManager = MockRepository.GenerateMock<IToolManager>();

            // Inject Stub
            MainWindowViewModel target = new MainWindowViewModel(uiDataProviderMock, toolManager);

            // call the method - Although it doesn't do anything with the list, if this is not called an exception would be called.
            IList<Customer> customers = target.Customers;

            uiDataProviderMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShowCustomerDetails_SelectedCustomerIdIsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            MainWindowViewModel target = new MainWindowViewModel(null, null);

            // Act
            target.ShowCustomerDetails();
        }

        [TestMethod]
        public void ShowCustomerDetails_ToolNotFound_AddNewTool()
        {
            // Arrange
            MainWindowViewModel target = GetShowCustomerDetails(new Customer
            {
                CustomerId = _expectedCustomerId,
                CompanyName =  _expectedCustomerCompanyName
            });

            // Act
            target.ShowCustomerDetails();

            // Assert
            CustomerDetailsViewModel actual = target.Tools.Cast<CustomerDetailsViewModel>()
                .FirstOrDefault(viewModel => viewModel.Customer.CustomerId.Equals(_expectedCustomerId));
            Assert.IsNotNull(actual);
        }


        [TestMethod]
        public void ShowCustomerDetails_Always_ToolIsSetToCurrent()
        {
            // Arrange
            Customer expected = new Customer { CustomerId = _expectedCustomerId};
            MainWindowViewModel target = GetShowCustomerDetails(expected);

            // Act
            target.ShowCustomerDetails();

            // Assert
            CustomerDetailsViewModel actual = CollectionViewSource.GetDefaultView(target.Tools).CurrentItem as CustomerDetailsViewModel;
            Assert.AreSame(expected, actual.Customer);
        }

        private MainWindowViewModel GetShowCustomerDetails(Customer customer)
        {
            IUiDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            IToolManager toolManager = MockRepository.GenerateMock<IToolManager>();
            uiDataProviderMock.Stub(c => c.GetCustomer(customer.CustomerId)).Return(customer);
            toolManager.Stub(c => c.Tools).Return(new ObservableCollection<ToolViewModel>
            {
                new CustomerDetailsViewModel(uiDataProviderMock, customer.CustomerId, toolManager)
            });

            MainWindowViewModel target = new MainWindowViewModel(uiDataProviderMock, toolManager)
            {
                SelectedCustomerId = customer.CustomerId
            };

            return target;
        }
    }
}
