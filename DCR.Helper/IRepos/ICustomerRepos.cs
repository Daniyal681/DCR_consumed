using DCR.Helper.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface ICustomerRepos
    {
        Task<object> GetCustomers();
        Task<object> GetCustomer(int CustomerId);
        Task<CustomerViewModel> AddCustomer(CustomerViewModel model);
        Task<CustomerViewModel> UpdateCustomer(int CustomerId, CustomerViewModel model);
        Task<object> DeleteCustomer(int CustomerId);





    }
}
