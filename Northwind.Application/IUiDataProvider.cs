using System.Collections.Generic;
using System.ServiceModel;
using Northwind.Model;

namespace Northwind.Application
{
    [ServiceContract]
    public interface IUiDataProvider
    {
        [OperationContract]
        IList<Customer> GetCustomers();

        [OperationContract]
        Customer GetCustomer(string customerId);

        [OperationContract]
        void Update(Customer customer);
    }
}
