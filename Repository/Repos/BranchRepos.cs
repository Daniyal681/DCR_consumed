using DAL.EntityModels;
using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repository.Repos
{
    public class BranchRepos : IBranchRepos
    {
        private readonly EMS_ITCContext _context;

        public BranchRepos(EMS_ITCContext context)
        {
            _context = context;
        }
        public async Task<BranchViewModel> AddBranch(BranchViewModel model)
        {
            try
            {
                // Create a new User entity
                var newBranch = new Branch
                {
                    BranchName = model.Name,
                    BranchPerson = model.Person,
                    BranchEmail = model.Email,
                    BranchPhone = model.Phone,
                    BranchAddress = model.Address,
                    Country = model.Country,
                    BranchCity = model.City,
                    BranchState = model.State,
                    BranchPostalCode = model.PostalCode,
                    CreatedBy = "Admin"
                };
               
                _context.Branches.Add(newBranch);
                await _context.SaveChangesAsync();

                return model;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> DeleteBranch(int BranchId)
        {
            var result = await _context.Branches.Where(a => a.BranchId == BranchId).FirstOrDefaultAsync();
            if (result != null)
            {
                var branch = result;
                branch.IsActive = false;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<string> GetBranch(int BranchId)
        {
            if (BranchId != null)

            {
                var branch = await _context.Branches.FirstOrDefaultAsync(a => a.BranchId == BranchId && a.IsActive == true);
                return branch != null ? JsonSerializer.Serialize(branch) : null;
            }
            return null; // If BranchId is null or the branch isn't found
        }
        public async Task<string> GetBranches()
        {
            var branchNames = await _context.Branches.Where(x => x.IsActive == true).ToListAsync();

            return string.Join(", ", JsonSerializer.Serialize(branchNames));
        }
        public async Task<BranchViewModel> UpdateBranch(int BranchId, BranchViewModel model)
        {
            var result = await _context.Branches.FirstOrDefaultAsync(a => a.BranchId == BranchId);
            if (result != null)
            {

                result.BranchName = model.Name;
                result.BranchPerson = model.Person;
                result.BranchEmail = model.Email;
                result.BranchPhone = model.Phone;
                result.BranchAddress = model.Address;
                result.Country = model.Country;
                result.BranchCity = model.City;
                result.BranchState = model.State;
                result.BranchPostalCode = model.PostalCode;
                result.UpdatedOn = DateTime.Now; 

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
