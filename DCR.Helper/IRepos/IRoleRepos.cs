using DCR.Helper.ViewModel;


namespace Repository.IRepos
{
    public interface IRoleRepos
    {
        Task<IEnumerable<object>> GetRoles();
        Task<object> GetRole(int RoleId);
        Task<RoleViewModel> AddRole(RoleViewModel model);
        Task<RoleViewModel> UpdateRole(int RoleId, RoleViewModel model);
        Task<object> DeleteRole(int RoleId);

    }
}
