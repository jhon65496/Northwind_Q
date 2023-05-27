using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ServiceModel;

namespace Northwind.Service
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        IList<Customer> GetCustomers();

        [OperationContract]
        Customer GetCustomer(string customerId);

        [OperationContract]
        void Update(Customer customer);
    }
}
