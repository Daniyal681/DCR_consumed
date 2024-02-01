using DAL.EntityModels;
using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository.Repos
{
    public class UserProfileRepos : IUserProfileRepos
    {

        private readonly EMS_ITCContext _context;
        

        public UserProfileRepos(EMS_ITCContext context, IConfiguration configuration)
        {
            _context = context;
        }





        public async Task<UserProfileViewModel> AddUserProfile(UserProfileViewModel model)
        {
            try
            {

                if (model.UserId != null)
                {
                    var result = await _context.Users.FirstOrDefaultAsync(b => b.UserId == model.UserId && b.IsActive == true);
                    // Create a corresponding warehouse record

                    var userid = new User
                    {
                        UserId = result.UserId,
                        // Map other properties as needed
                    };


                    if (model.UserId == userid.UserId)
                    {

                        var newUserProfile = new UserProfile
                        {
                            UserId = model.UserId,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Gender = model.Gender,
                            Phone = model.Phone,
                            Address = model.Address,
                            CreatedBy = "Admin"
                        };

                        _context.UserProfiles.Add(newUserProfile);
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

        public async Task<object> DeleteUserProfile(int UserProfileId)
        {
            var result = await _context.UserProfiles.Where(a => a.UserProfileId == UserProfileId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetUserProfile(int UserProfileId)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(a => a.UserProfileId == UserProfileId && a.IsActive == true);
        }

        public async Task<IEnumerable<object>> GetUserprofiles()
        {
            return await _context.UserProfiles.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<UserProfileViewModel> UpdateUserProfile(int UserProfileId, UserProfileViewModel model)
        {
            var result = await _context.UserProfiles.FirstOrDefaultAsync(a => a.UserProfileId == UserProfileId);
            if (result != null)
            {

                result.FirstName = model.FirstName;
                result.LastName = model.LastName;
                result.Gender = model.Gender;
                result.Phone = model.Phone;
                result.Address = model.Address;



                // Update other fields if needed, e.g., UpdatedBy and UpdatedOn
                //result.UpdatedOn = DateTime.Now; // Set the appropriate value
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
