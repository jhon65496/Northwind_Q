using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Application.CustomerService;
using Rhino.Mocks;
using Service = Northwind.Application.CustomerService;

namespace Northwind.Application.Tests
{
    [TestClass()]
    public class UiDataProviderTests
    {
        /// <summary>
        /// A test for GetCustomers.
        /// </summary>
        [TestMethod]
        public void GetCustomers_Always_CallsGetCustomers()
        {
            // arrange
            ICustomerService customerServiceStub = MockRepository.GenerateMock<ICustomerService>();
            UiDataProvider target = new UiDataProvider(customerServiceStub);
            var customerDtos = new Service.Customer[] {new Service.Customer()};
            customerServiceStub.Stub(c => c.GetCustomers()).Return(customerDtos);

            // act
            target.GetCustomers();

            // assert
            customerServiceStub.AssertWasCalled(c => c.GetCustomers());
        }

        /// <summary>
        /// A test for GetCustomer.
        /// </summary>
        [TestMethod()]
        public void GetCustomers_ServiceReturnsDto_DtoPassedToTranslator()
        {
            // Arrange
            ICustomerService customerServiceStub =  MockRepository.GenerateStub<ICustomerService>();
            CustomerTranslator.Instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Service.Customer>>();
            UiDataProvider target = new UiDataProvider(customerServiceStub);
            var expected = new Service.Customer();
            var customerDtos = new Service.Customer[] { expected };
            customerServiceStub.Stub(c => c.GetCustomers()).Return(customerDtos);

            // Act
            target.GetCustomers();

            // Assert
            CustomerTranslator.Instance.AssertWasCalled(c => c.CreateModel(expected));
        }

        /// <summary>
        /// A test for GetCustomer.
        /// </summary>
        [TestMethod()]
        public void GetCustomers_ServiceReturnsDto_ModelReturnedFromTranslator()
        {
            // Arrange
            ICustomerService customerServiceStub = MockRepository.GenerateStub<ICustomerService>();
            CustomerTranslator.Instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Service.Customer>>();
            UiDataProvider target = new UiDataProvider(customerServiceStub);
            var dto = new Service.Customer();
            var expected = new Model.Customer();
            var customerDtos = new Service.Customer[] { dto };
            customerServiceStub.Stub(c => c.GetCustomers()).Return(customerDtos);
            CustomerTranslator.Instance.Stub(c => c.CreateModel(dto)).Return(expected);

            // Act
            var actual = target.GetCustomers();

            // Assert
           Assert.AreSame(expected, actual[0]);
        }

        /// <summary>
        /// A test for GetCustomer.
        /// </summary>
        [TestMethod]
        public void GetCustomer_Always_CallsGetCustomer()
        {
            // arrange
            const string expectedId = "expectedId";
            ICustomerService customerServiceStub = MockRepository.GenerateMock<ICustomerService>();
            CustomerTranslator.Instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Service.Customer>>();
            UiDataProvider target = new UiDataProvider(customerServiceStub);
            var dto = new Service.Customer(){CustomerId = expectedId};
            var model = new Model.Customer() { CustomerId = expectedId };
            var customerDtos = new Service.Customer[] { dto };
            customerServiceStub.Stub(c => c.GetCustomers()).Return(customerDtos);
            CustomerTranslator.Instance.Stub(c => c.CreateModel(dto)).Return(model);
            target.GetCustomers();

            // act
            target.GetCustomer(expectedId);

            // assert
            customerServiceStub.AssertWasCalled(c => c.GetCustomer(expectedId));
        }
    }
}
