using DAL.EntityModels;
using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repos
{
    public class MenuPermissionsAsignRepos : IMenuPermissionsAsignRepos
    {
        private readonly EMS_ITCContext _context;

        public MenuPermissionsAsignRepos(EMS_ITCContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMenuPermission(MenuPermissionAssignViewModel Model)
        {
            try
            {
                var NewMenuPermissionAssign = new MenuPermissionAssign
                {
                    RoleId = Model.RoleId,
                    MenuListId = Model.MenuListId,
                    IsActive = true

                };


                _context.MenuPermissionAssigns.Add(NewMenuPermissionAssign);
                await _context.SaveChangesAsync();


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMenuPermission(int MenuAssignId)
        {
            try
            {
                var Result = await _context.MenuPermissionAssigns.Where(mpa => mpa.Id == MenuAssignId).FirstOrDefaultAsync();
                if (Result != null)
                {
                    Result.IsActive = false;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<MenuPermissionAssignViewModel> GetMenuPermission(int MenuAssignId)
        {
            try
            {
                var Result = await _context.MenuPermissionAssigns.FirstOrDefaultAsync(mpa => mpa.Id == MenuAssignId);

                if (Result != null)
                {
                    var Model = new MenuPermissionAssignViewModel
                    {
                        RoleId = Result.RoleId,
                        MenuListId = Result.MenuListId
                    };

                    return Model;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<MenuListViewModel>> GetMenuPermissions(int RoleId)
        {
            try
            {
                var menuPermissionAssignsLists = (from mpa in _context.MenuPermissionAssigns
                                                  join ml in _context.MenuLists on mpa.MenuListId equals ml.Id
                                                  join r in _context.Roles on mpa.RoleId equals r.RoleId
                                                  join ur in _context.UserRoles on r.RoleId equals ur.RoleId
                                                  join u in _context.Users on ur.UserId equals u.UserId
                                                  where mpa.IsActive == true && ml.IsActive == true && r.IsActive == true && u.IsActive == true && ur.RoleId == RoleId
                                                  select new MenuListViewModel
                                                  {
                                                      Id = ml.Id,
                                                      Title = ml.Title,
                                                      Description = ml.Description,
                                                      ParentId = ml.ParentId,
                                                      HasChildren = ml.HasChildren,
                                                      SortOrder = ml.SortOrder,
                                                      NavigationUrl = ml.NavigationUrl,
                                                      IconClass = ml.IconClass,
                                                      ParentName = ml.ParentName
                                                      
                                                  }).Distinct().ToList();

                //var test = (from m in _context.MenuLists
                //            join ml in _context.MenuPermissionAssigns on m.Id equals ml.MenuListId
                //            join ur in _context.UserRoles on ml.RoleId equals ur.RoleId
                //            where m.IsActive=== true && ml.IsActive == true && )


                return menuPermissionAssignsLists;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> UpdateMenuPermission(MenuPermissionAssignViewModel Model)
        {
            try
            {
                var Result = await _context.MenuPermissionAssigns.FirstOrDefaultAsync(mpa => mpa.Id == Model.MenuAssignId);
                if (Result != null)
                {

                    Result.RoleId = Model.RoleId;
                    Result.MenuListId = Model.MenuListId;

                    await _context.SaveChangesAsync();

                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

