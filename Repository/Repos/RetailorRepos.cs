using DAL.EntityModels;
using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repos
{
    public class RetailorRepos : IRetailorRepos
    {
        private readonly EMS_ITCContext _context;

        public RetailorRepos(EMS_ITCContext context)
        {
            _context = context;
        }




        public async Task<RetailerViewModel> AddRetailer(RetailerViewModel model)
        {
            try
            {
                // Create a new User entity
                var newRetailer = new Retailer
                {
                    RetailerName = model.RetailerName,
                    Address = model.RetailerAddress,
                    PhoneNumber = model.RetailerPhone,
                    Country = model.RetailerCountry,
                    City = model.RetailerCity,
                    State = model.RetailerState,
                    SalesRegion = model.RetailerSaleRegion,
                    PostalCode = model.PostalCode,
                    CreatedBy = "Admin"

                };

                _context.Retailers.Add(newRetailer);
                await _context.SaveChangesAsync();

                return model;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<object> DeleteRetailer(int RetailerId)
        {
            var result = await _context.Retailers.Where(a => a.RetailerId == RetailerId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetRetailer(int RetailerId)
        {
            return await _context.Retailers.FirstOrDefaultAsync(a => a.RetailerId == RetailerId && a.IsActive == true);
        }

        public async Task<IEnumerable<object>> GetRetailers()
        {
            return await _context.Retailers.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<RetailerViewModel> UpdateRetailer(int RetailerId, RetailerViewModel model)
        {
            var result = await _context.Retailers.FirstOrDefaultAsync(a => a.RetailerId == RetailerId);
            if (result != null)
            {

                result.RetailerName = model.RetailerName;
                result.Address = model.RetailerAddress;
                result.City = model.RetailerCity;
                result.State = model.RetailerState;
                result.Country = model.RetailerCountry;
                result.PhoneNumber = model.RetailerPhone;
                result.SalesRegion = model.RetailerSaleRegion;
                result.PostalCode = model.PostalCode;


                // Update other fields if needed, e.g., UpdatedBy and UpdatedOn
                result.UpdatedBy = model.RetailerName; // Set the appropriate value
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
