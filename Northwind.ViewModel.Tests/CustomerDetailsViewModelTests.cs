using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Application;
using Northwind.Model;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace Northwind.ViewModel.Tests
{
    [TestClass]
    public class CustomerDetailsViewModelTests
    {
        [TestMethod]
        public void Ctor_Always_CallsGetCustomer()
        {
            // Arrange
            IUiDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            const string expectedId = "EXPECTEDID";
            uiDataProviderMock.Expect(c => c.GetCustomer(expectedId)).Return(new Customer());
            
            // Act
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderMock, expectedId);

            // Assert
            uiDataProviderMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void Customer_Always_ReturnsCustomerFromGetCustomer()
        {
            // Arrange
            IUiDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            const string expectedId = "EXPECTEDID";
            Customer expectedCustomer = new Customer
            {
                CustomerId = expectedId
            };

            uiDataProviderMock.Stub(c => c.GetCustomer(expectedId)).Return(expectedCustomer);
            
            // Act
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderMock, expectedId);
            
            // Assert
            Assert.AreSame(expectedCustomer, target.Customer);
        }

        [TestMethod]
        public void DisplayName_Always_ReturnsCompanyName()
        {
            // Arrange
            IUiDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            const string expectedId = "EXPECTEDID";
            const string expectedCompanyName = "EXPECTEDNAME";

            Customer expectedCustomer = new Customer
            {
                CustomerId = expectedId,
                CompanyName = expectedCompanyName,
            };

            uiDataProviderMock.Stub(c => c.GetCustomer(expectedId)).Return(expectedCustomer);

            // Act
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderMock, expectedId);

            // Assert
            Assert.AreSame(expectedCompanyName, target.DisplayName);
        }

        [TestMethod]
        public void UpdateCustomer_Always_CallsUpdateWithCustomer()
        {
            // Arrange
            IUiDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            Customer expectedCustomer = new Customer();
            uiDataProviderMock.Stub(u => u.GetCustomer(Arg<string>.Is.Anything)).Return(expectedCustomer);
            CustomerDetailsViewModel viewModel = new CustomerDetailsViewModel(uiDataProviderMock, string.Empty);
            RelayCommand target = viewModel.UpdateCommand;

            // act
            target.Execute(null);

            // assert
            uiDataProviderMock.AssertWasCalled(u => u.Update(expectedCustomer));
        }

        [TestMethod]
        public void UpdateCustomer_NotDirty_ReturnsFalse()
        {
            // Arrange
            IUiDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            Customer expectedCustomer = new Customer();
            uiDataProviderMock.Stub(u => u.GetCustomer(Arg<string>.Is.Anything)).Return(expectedCustomer);
            CustomerDetailsViewModel viewModel = new CustomerDetailsViewModel(uiDataProviderMock, string.Empty);
            RelayCommand target = viewModel.UpdateCommand;

            // act
            bool actual = target.CanExecute(null);

            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void UpdateCustomer_IsDirty_ReturnsTrue()
        {
            // Arrange
            IUiDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            Customer expectedCustomer = new Customer();
            uiDataProviderMock.Stub(u => u.GetCustomer(Arg<string>.Is.Anything)).Return(expectedCustomer);
            CustomerDetailsViewModel viewModel = new CustomerDetailsViewModel(uiDataProviderMock, string.Empty);
            RelayCommand target = viewModel.UpdateCommand;
            expectedCustomer.RaisePropertyChanged("CompanyName");

            // act
            bool actual = target.CanExecute(null);

            // assert
            Assert.IsTrue(actual);
        }
    }
}
