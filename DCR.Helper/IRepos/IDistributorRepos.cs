using DCR.Helper.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IDistributorRepos
    {
        Task<object> GetDistributors();
        Task<object> GetDistributor(int DistributorId);
        Task<DistributorViewModel> AddDistributor(DistributorViewModel model);
        Task<DistributorViewModel> UpdateDistributor(int DistributorId, DistributorViewModel model);
        Task<object> DeleteDistributor(int DistributorId);

    }
}
