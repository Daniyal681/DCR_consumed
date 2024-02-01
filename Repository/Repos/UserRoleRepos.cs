using DAL.EntityModels;
using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.EntityFrameworkCore;



namespace Repository.Repos
{
    public class UserRoleRepos : IUserRolesRepos
    {
        private readonly EMS_ITCContext _context;

        public UserRoleRepos(EMS_ITCContext context)
        {
            _context = context;
        }

        public async Task<UserRoleViewModel> AddUserRole(UserRoleViewModel model)
        {
            try
            {

                if (model.RoleId != null && model.UserId != null)
                {
                    var userrole = await _context.UserRoles.FirstOrDefaultAsync(b => b.RoleId == model.RoleId && b.UserId == model.UserId);
                    // Create a corresponding warehouse record

                    var userRole = new UserRole
                    {
                        RoleId = model.RoleId,
                        UserId = model.UserId,
                        // Map other properties as needed
                    };
                    if (model.RoleId == userRole.RoleId && model.UserId == userRole.UserId)
                    {
                        // Create a new User entity
                        var NewuserRole = new UserRole
                        {
                            RoleId = model.RoleId,
                            UserId = model.UserId,
                           
                        };

                        _context.UserRoles.Add(NewuserRole);
                        await _context.SaveChangesAsync();
                    }
                }
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<object> DeleteUserRole(int UserRoleId)
        {
            var result = await _context.UserRoles.Where(a => a.UserRoleId == UserRoleId).FirstOrDefaultAsync();
            if (result != null)
            {
                //result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetUserRole(int UserRoleId)
        {
            return await _context.UserRoles.FirstOrDefaultAsync(a => a.UserRoleId == UserRoleId);
        }

        public async Task<IEnumerable<object>> GetUserRoles()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRoleViewModel> UpdateUserRole(int UserRoleId, UserRoleViewModel model)
        {
            var result = await _context.UserRoles.FirstOrDefaultAsync(a => a.UserRoleId == UserRoleId);
            if (result != null)
            {

                result.UserId = model.UserId;
                result.RoleId = model.RoleId;
              

                //result.UpdatedOn = DateTime.Now; // Set the appropriate value
                // Save changes to the database
                await _context.SaveChangesAsync();

                return model;

            }
            else
            {
                //  not found
                return null;
            }
        }
    }
}
