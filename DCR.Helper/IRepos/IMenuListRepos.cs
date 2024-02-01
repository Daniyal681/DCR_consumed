using DCR.ViewModel.ViewModel;

namespace DCR.ViewModel.IRepos
{
    public interface IMenuListRepos
    {
        Task<IEnumerable<object>> GetMenuLists();
        Task<object> GetMenuList(int MenuId);
        Task<MenuListViewModel> AddMenu(MenuListViewModel model);
        Task<MenuListViewModel> UpdateMenu(int MenuId, MenuListViewModel model);
        Task<object> DeleteMenu(int MenuId);
    }
}
