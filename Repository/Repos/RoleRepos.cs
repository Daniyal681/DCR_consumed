using DAL.EntityModels;
using DCR.Helper.ViewModel;
using Microsoft.EntityFrameworkCore;
using Repository.IRepos;


namespace Repository.Repos
{
    public class RoleRepos : IRoleRepos
    {
        private readonly EMS_ITCContext _context;

        public RoleRepos(EMS_ITCContext context)
        {

            _context = context;

        }




        public async Task<RoleViewModel> AddRole(RoleViewModel model)
        {
            try
            {
                // Create a new User entity
                var newRole = new Role
                {
                    RoleName = model.RoleName,
                    RoleDescription = model.RoleDescription,
                    CreatedBy = "Admin"

                };

                _context.Roles.Add(newRole);
                await _context.SaveChangesAsync();


                return model;
            }
            catch (Exception)
            {

                return null;
            }
        }



        public async Task<object> DeleteRole(int RoleId)
        {
            var result = await _context.Roles.Where(a => a.RoleId == RoleId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetRole(int RoleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(a => a.RoleId == RoleId && a.IsActive == true);
        }

        public async Task<IEnumerable<object>> GetRoles()
        {
            return await _context.Roles.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<RoleViewModel> UpdateRole(int RoleId, RoleViewModel model)
        {
            var result = await _context.Roles.FirstOrDefaultAsync(a => a.RoleId == RoleId);
            if (result != null)
            {

                result.RoleName = model.RoleName;
                result.RoleDescription = model.RoleDescription;
               


                // Update other fields if needed, e.g., UpdatedBy and UpdatedOn
                result.UpdatedBy = model.RoleName; // Set the appropriate value
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
