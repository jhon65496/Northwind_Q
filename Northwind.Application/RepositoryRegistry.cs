using Northwind.Application;
using Northwind.Application.CustomerService;
using StructureMap.Configuration.DSL;

namespace Northwind.ViewModel
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IUiDataProvider>().Singleton();
            For<ICustomerService>().Singleton().Use(o => new CustomerServiceClient());
        }
    }
}