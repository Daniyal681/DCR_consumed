
using DCR.ViewModel.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IDistributorIMEIRepos
    {
        Task<object> GetDistributorImeis();
        Task<object> GetDistributorImei(int DistributorImeiId);
        Task<DistibutorIMEIViewModel> AddDistributorImei(DistibutorIMEIViewModel model);
        Task<DistibutorIMEIViewModel> UpdateDistributorImei(int DistributorImeiId, DistibutorIMEIViewModel model);
        Task<object> DeleteDistributorImei(int DistributorImeiId);
    }
}
