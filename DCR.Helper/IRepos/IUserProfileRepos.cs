using DCR.ViewModel.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IUserProfileRepos
    {
        Task<IEnumerable<object>> GetUserprofiles();
        Task<object> GetUserProfile(int UserProfileId);
        Task<UserProfileViewModel> AddUserProfile(UserProfileViewModel model);
        Task<UserProfileViewModel> UpdateUserProfile(int UserProfileId, UserProfileViewModel model);
        Task<object> DeleteUserProfile(int UserProfileId);
    }
}
