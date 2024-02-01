using DCR.Helper.ViewModel;

namespace DCR.ViewModel.IRepos
{
    public interface IBranchRepos
    {
        Task<string> GetBranches();
        Task<string> GetBranch(int BranchId);
        Task<bool> DeleteBranch(int BranchId);
        Task<BranchViewModel> AddBranch(BranchViewModel model);
        Task<BranchViewModel> UpdateBranch(int BranchId , BranchViewModel model);
    }
}
