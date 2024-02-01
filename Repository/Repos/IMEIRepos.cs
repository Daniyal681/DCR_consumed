using DAL.EntityModels;
using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.EntityFrameworkCore;



namespace Repository.Repos
{
    public class IMEIRepos : IIMEIRepos
    {

        private readonly EMS_ITCContext _context;

        public IMEIRepos(EMS_ITCContext context)
        {
            _context = context;
        }

        public async Task<IMEIViewModel> AddIMEI(IMEIViewModel model)
        {
            try
            {

                if (model.ProductId != null)
                {
                    var result = await _context.Products.FirstOrDefaultAsync(b => b.ProductId == model.ProductId);
                    // Create a corresponding warehouse record

                    var product = new Product
                    {
                        ProductId = result.ProductId,
                        // Map other properties as needed
                    };
                    if (model.ProductId == product.ProductId)
                    {

                        // Create a new User entity
                        var newIMEI = new Imei
                        {
                            ProductId= model.ProductId,
                            ImeiNumber = model.ImeiNumber,
                            ImeiNumber2 = model.ImeiNumber2,
                            ImeiStatus = model.ImeiStatus,
                            DeviceType = model.DeviceType,
                            ActivationDate = model.ActivationDate,
                            CreatedBy = "Admin",
                        };

                        _context.Imeis.Add(newIMEI);
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

        public async Task<object> DeleteIMEI(int IMEIId)
        {
            var result = await _context.Imeis.Where(a => a.ImeiId == IMEIId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetIMEI(int IMEIId)
        {
            return await _context.Imeis.FirstOrDefaultAsync(a => a.ImeiId == IMEIId && a.IsActive == true);
        }

        public async Task<IEnumerable<object>> GetIMEIs()
        {
            return await _context.Imeis.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<IMEIViewModel> UpdateIMEI(IMEIViewModel model)
        {
            var result = await _context.Imeis.FirstOrDefaultAsync(a => a.ImeiId == model.ImeiId);
            if (result != null)
            {
                result.ProductId = model.ProductId;
                result.ImeiNumber = model.ImeiNumber;
                result.ImeiNumber2 = model.ImeiNumber2;
                result.ImeiStatus = model.ImeiStatus;
                result.ActivationDate = model.ActivationDate;
                result.DeviceType = model.DeviceType;
                

                // Update other fields if needed, e.g., UpdatedBy and UpdatedOn
                //result.UpdatedBy = model.CustomerName; 
                result.UpdatedOn = DateTime.Now; 
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
