using DCR.ViewModel.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IMenuPermissionsAsignRepos
    {
        Task<List<MenuListViewModel>> GetMenuPermissions(int RoleID);
        Task<MenuPermissionAssignViewModel> GetMenuPermission(int MenuAssignId);
        Task<bool> AddMenuPermission(MenuPermissionAssignViewModel Model);
        Task<bool> UpdateMenuPermission(MenuPermissionAssignViewModel Model);
        Task<bool> DeleteMenuPermission(int MenuAssignId);
    }
}
