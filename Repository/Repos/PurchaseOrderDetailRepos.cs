using DAL.EntityModels;
using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repos
{
    public class PurchaseOrderDetailRepos : IPurchaseOrderDetailRepos
    {

        private readonly EMS_ITCContext _context;

        public async Task<PurchaseOrderDetailViewModel> AddPurchaseOrderDetail(PurchaseOrderDetailViewModel model)
        {
            try
            {

                if (model.PurchaseId != null)
                {
                    var result = await _context.PurchaseOrderDetails.FirstOrDefaultAsync(b => b.ProductId == model.ProductId);
                    // Create a corresponding warehouse record

                    var Purcahseid = new PurchaseOrderDetail
                    {
                        ProductId = result.ProductId,
                        // Map other properties as needed
                    };


                    if (model.ProductId == Purcahseid.ProductId)
                    {

                        var newPurchaseOrderDetail = new PurchaseOrderDetail
                        {
                            ProductId = model.ProductId,
                            Quantity = model.Quantity,
                            UnitPrice = model.UnitPrice,
                             Total = model.Total,
                        };

                        _context.PurchaseOrderDetails.Add(newPurchaseOrderDetail);
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

        public async Task<object> DeletePurchaseOrderDetail(int PurchaseOrderDetailId)
        {
            var result = await _context.PurchaseOrderDetails.Where(a => a.PurchaseOrderDetailId == PurchaseOrderDetailId).FirstOrDefaultAsync();
            if (result != null)
            {
                //result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetPurchaseOrderDetail(int PurchaseOrderDetailId)
        {
            return await _context.PurchaseOrderDetails.FirstOrDefaultAsync(a => a.PurchaseOrderDetailId == PurchaseOrderDetailId);
        }

        public async Task<IEnumerable<object>> GetPurchaseOrderDetails()
        {
            return await _context.PurchaseOrderDetails.ToListAsync();
        }

        public async Task<PurchaseOrderDetailViewModel> UpdatePurchaseOrderDetail(int PurchaseOrderDetailId, PurchaseOrderDetailViewModel model)
        {
            var result = await _context.PurchaseOrderDetails.FirstOrDefaultAsync(a => a.PurchaseOrderDetailId == PurchaseOrderDetailId);
            if (result != null)
            {

                result.Quantity = model.Quantity;
                result.UnitPrice = model.UnitPrice;
                result.Total = model.Total;

                // Update other fields if needed, e.g., UpdatedBy and UpdatedOn
                //result.UpdatedBy = model.CustomerName; // Set the appropriate value
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
