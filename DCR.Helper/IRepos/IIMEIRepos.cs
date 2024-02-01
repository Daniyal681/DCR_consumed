
using DCR.Helper.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IIMEIRepos
    {
        Task<IEnumerable<object>> GetIMEIs();
        Task<object> GetIMEI(int IMEIId);
        Task<IMEIViewModel> AddIMEI(IMEIViewModel model);
        Task<IMEIViewModel> UpdateIMEI(IMEIViewModel model);
        Task<object> DeleteIMEI(int IMEIId);
    }
}
