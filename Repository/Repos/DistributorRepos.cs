using DAL.EntityModels;
using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repos
{
    public class DistributorRepos : IDistributorRepos
    {
        private readonly EMS_ITCContext _context;

        public DistributorRepos(EMS_ITCContext context)
        {
            _context = context;
        }
        public async Task<DistributorViewModel> AddDistributor(DistributorViewModel model)
        {
            try
            {

                if (model.ContactpersonId != null)
                {
                    var Contactperson = await _context.ContactPeople.FirstOrDefaultAsync(b => b.ContactPersonId == model.ContactpersonId && b.IsActive == true);
                    // Create a corresponding warehouse record

                    var Distributor = new Distributor
                    {
                        ContactPersonId = Contactperson.ContactPersonId,
                        // Map other properties as needed
                    };
                    if (model.ContactpersonId == Distributor.ContactPersonId)
                    {
                        // Create a new User entity
                        var NewDistributor = new Distributor
                        {
                            ContactPersonId = model.ContactpersonId,
                            DistributorName = model.DistributorName,
                            DistributorType = model.DistributorType,
                            DistributorEmail = model.DistributorEmail,
                            DistributorPhone = model.DistributorPhone,
                            DistributorAddress = model.DistributorAddress,
                            CreatedBy = "Admin"
                        };

                        _context.Distributors.Add(NewDistributor);
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

        public async Task<object> DeleteDistributor(int DistributorId)
        {
            var result = await _context.Distributors.Where(a => a.DistributorId == DistributorId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetDistributor(int DistributorId)
        {
            return await _context.Distributors.FirstOrDefaultAsync(a => a.DistributorId == DistributorId && a.IsActive == true);
        }

        public async Task<object> GetDistributors()
        {
            return await _context.Distributors.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<DistributorViewModel> UpdateDistributor(int DistributorId, DistributorViewModel model)
        {
            var result = await _context.Distributors.FirstOrDefaultAsync(a => a.DistributorId == DistributorId);
            if (result != null)
            {

                result.DistributorName = model.DistributorName;
                result.DistributorType = model.DistributorType;
                result.DistributorEmail = model.DistributorEmail;
                result.DistributorPhone = model.DistributorPhone;
                result.DistributorAddress = model.DistributorAddress;


                // Update other fields if needed, e.g., UpdatedBy and UpdatedOn
                result.UpdatedBy = model.DistributorName; // Set the appropriate value
                result.UpdatedOn = DateTime.Now; // Set the appropriate value
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
