using DAL.EntityModels;
using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repos
{
    public class MenuListRepos : IMenuListRepos
    {
        private readonly EMS_ITCContext _context;

        public MenuListRepos(EMS_ITCContext context)
        {
            _context = context;
        }

        public async Task<MenuListViewModel> AddMenu(MenuListViewModel model)
        {
            try
            {

                var newMenuList = new MenuList
                {
                    Title = model.Title,
                    Description = model.Description,
                    ParentId = model.ParentId,
                    HasChildren = model.HasChildren,
                    SortOrder = model.SortOrder,
                    NavigationUrl = model.NavigationUrl,
                    IconClass = model.IconClass,
                    IsActive = true,
                    CreatedBy = "Admin"
                };

                _context.MenuLists.Add(newMenuList);
                await _context.SaveChangesAsync();


                return model;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<object> DeleteMenu(int MenuId)
        {
            var result = await _context.MenuLists.Where(a => a.Id == MenuId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetMenuList(int MenuId)
        {
            return await _context.MenuLists.FirstOrDefaultAsync(a => a.Id == MenuId && a.IsActive == true);
        }

        public async Task<IEnumerable<object>> GetMenuLists()
        {
           return await _context.MenuLists
        .Where(x => x.IsActive == true) 
        .OrderBy(x => x.SortOrder)
        .ToListAsync();
        }

        public async Task<MenuListViewModel> UpdateMenu(int MenuId, MenuListViewModel model)
        {
            var result = await _context.MenuLists.FirstOrDefaultAsync(a => a.Id == MenuId);
            if (result != null)
            {

                result.Title = model.Title;
                result.Description = model.Description;
                result.SortOrder = model.SortOrder;
                result.ParentId = model.ParentId;
                result.HasChildren = model.HasChildren;
                result.NavigationUrl = model.NavigationUrl;
                result.IconClass = model.IconClass;
              



                // Update other fields if needed, e.g., UpdatedBy and UpdatedOn
                //result.UpdatedBy = model.CustomerName; // Set the appropriate value
                result.UpdatedOn = DateTime.Now; // Set the appropriate value
                // Save changes to the database
                await _context.SaveChangesAsync();


                return model;


            }
            else
            {
                // User not found
                return null;
            }
        }
    }
}
