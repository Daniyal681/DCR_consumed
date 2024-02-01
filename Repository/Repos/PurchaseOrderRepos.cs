using DAL.EntityModels;
using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repos
{
    public class PurchaseOrderRepos : IPurchaseOrderRepos
    {

        private readonly EMS_ITCContext _context;

        public PurchaseOrderRepos(EMS_ITCContext context)
        {
            _context = context;
        }


        public async Task<PurchaseOrderViewModel> AddPurchaseOrder(PurchaseOrderViewModel model)
        {
            try
            {

                if (model.VendorId != null)
                {
                    var result = await _context.Vendors.FirstOrDefaultAsync(b => b.VendorId == model.VendorId && b.IsActive == true);
                    // Create a corresponding warehouse record

                    var vendorid = new Vendor
                    {
                        VendorId = result.VendorId,
                        // Map other properties as needed
                    };


                    if (model.VendorId == vendorid.VendorId)
                    {

                        var newPurchaseOrder = new PurchaseOrder
                        {
                            VendorId = model.VendorId,
                            PurchaseName = model.PurchaseName,
                            PurchaseQuantity = model.PurchaseQuantity,
                            PurchaseDescription = model.PurchaseDescription,
                            DateOfOrder = model.DateOfOrder,
                            DateOfDelivery = model.DateOfDelivery,
                            Amount = model.Amount,
                            SubTotal = model.SubTotal,
                            Discount = model.Discount,
                            Total = model.Total,
                            CreatedBy = "Admin"
                        };
                        _context.PurchaseOrders.Add(newPurchaseOrder);
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

        public async Task<object> DeletePurchaseOrder(int PurchaseId)
        {
            var result = await _context.PurchaseOrders.Where(a => a.PurchaseId == PurchaseId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetPurchaseOrder(int PurchaseId)
        {
            return await _context.PurchaseOrders.FirstOrDefaultAsync(a => a.PurchaseId == PurchaseId && a.IsActive == true);
        }

        public async Task<IEnumerable<object>> GetPurchaseOrders()
        {
            return await _context.PurchaseOrders.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<PurchaseOrderViewModel> UpdatePurchaseOrder(int PurchaseId, PurchaseOrderViewModel model)
        {
            var result = await _context.PurchaseOrders.FirstOrDefaultAsync(a => a.PurchaseId == PurchaseId);
            if (result != null)
            {

                result.PurchaseName = model.PurchaseName;
                result.PurchaseQuantity = model.PurchaseQuantity;
                result.PurchaseDescription = model.PurchaseDescription;
                result.DateOfOrder = model.DateOfOrder;
                result.DateOfDelivery = model.DateOfDelivery;
                result.Amount = model.Amount;
                result.SubTotal = model.SubTotal;
                result.Discount = model.Discount;
                result.Total = model.Total;



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
