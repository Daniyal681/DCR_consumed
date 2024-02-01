using DCR.ViewModel.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IReceiveRepos
    {
        Task<IEnumerable<object>> GetReceives();
        Task<object> GetReceive(int ReceiveId);
        Task<ReceiveViewModel> AddReceive(ReceiveViewModel model);
        Task<ReceiveViewModel> UpdateReceive(int ReceiveId, ReceiveViewModel model);
        Task<object> DeleteReceive(int ReceiveId);

    }
}
