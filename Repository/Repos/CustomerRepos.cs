using DAL.EntityModels;
using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repos
{
    public class CustomerRepos : ICustomerRepos
    {
        private readonly EMS_ITCContext _context;


        public CustomerRepos(EMS_ITCContext context)
        {
            _context = context;
        }

        public async Task<CustomerViewModel> AddCustomer(CustomerViewModel model)
        {
            try
            {
                var newCustomer = new Customer
                {
                    CustomerName = model.CustomerName,
                    //CustomerType = model.CustomerType,
                    CustomerEmail = model.CustomerEmail,
                    CustomerPhone = model.CustomerPhone,
                    CustomerCountry = model.CustomerCountry,
                    CustomerAddress = model.CustomerAddress,
                    CustomerCity = model.CustomerCity,
                    CustomerState = model.CustomerState,
                    CustomerPostalCode = model.CustomerPostalCode,
                    CreatedBy = "Admin"
                };
                _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();

                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<object> DeleteCustomer(int CustomerId)
        {

            var result = await _context.Customers.Where(a => a.CustomerId == CustomerId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<object> GetCustomers()
        {
            return await _context.Customers.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<object> GetCustomer(int CustomerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(a => a.CustomerId == CustomerId && a.IsActive == true);
        }

        public async Task<CustomerViewModel> UpdateCustomer(int CustomerId, CustomerViewModel model)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(a => a.CustomerId == CustomerId);
            if (result != null)
            {

                result.CustomerName = model.CustomerName;
                //result.CustomerType = model.CustomerType;
                result.CustomerEmail = model.CustomerEmail;
                result.CustomerPhone = model.CustomerPhone;
                result.CustomerCountry = model.CustomerCountry;
                result.CustomerAddress = model.CustomerAddress;
                result.CustomerCity = model.CustomerCity;
                result.CustomerState = model.CustomerState;
                result.CustomerPostalCode = model.CustomerPostalCode;


                // Update other fields if needed, e.g., UpdatedBy and UpdatedOn
                result.UpdatedBy = model.CustomerName; // Set the appropriate value
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
