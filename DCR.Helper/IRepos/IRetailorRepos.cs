using DCR.Helper.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IRetailorRepos
    {
        Task<IEnumerable<object>> GetRetailers();
        Task<object> GetRetailer(int RetailerId);
        Task<RetailerViewModel> AddRetailer(RetailerViewModel model);
        Task<RetailerViewModel> UpdateRetailer(int RetailerId, RetailerViewModel model);
        Task<object> DeleteRetailer(int RetailerId);
    }
}
