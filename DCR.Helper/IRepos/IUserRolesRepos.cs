using DCR.ViewModel.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IUserRolesRepos
    {
        Task<IEnumerable<object>> GetUserRoles();
        Task<object> GetUserRole(int UserRoleId);
        Task<UserRoleViewModel> AddUserRole(UserRoleViewModel model);
        Task<UserRoleViewModel> UpdateUserRole(int UserRoleId, UserRoleViewModel model);
        Task<object> DeleteUserRole(int UserRoleId);

    }
}
