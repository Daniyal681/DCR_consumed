using DAL.EntityModels;
using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repos
{
    public class PurchaseOrderLineRepos : IPurchaseOrderline
    {
        private readonly EMS_ITCContext _context;

        public PurchaseOrderLineRepos(EMS_ITCContext context)
        {
            _context = context;
        }
        public async Task<PurchaseOrderLineViewModel> AddPurchaseOrderLine(PurchaseOrderLineViewModel model)
        {
            try
            {

                if (model.PurchaseId != null)
                {
                    var result = await _context.PurchaseOrderLines.FirstOrDefaultAsync(b => b.PurchaseId == model.PurchaseId);
                    // Create a corresponding warehouse record

                    var Purcahseid = new PurchaseOrderLine
                    {
                        PurchaseId = result.PurchaseId,
                        // Map other properties as needed
                    };


                    if (model.PurchaseId == Purcahseid.PurchaseId)
                    {

                        var newPurchaseOrderLine = new PurchaseOrderLine
                        {
                            PurchaseId = model.PurchaseId,
                            OrderLineDescription = model.OrderLineDescription,
                            OrderLineQuantity = model.OrderLineQuantity,
                            OrderLineUnitPrice = model.OrderLineUnitPrice,
                            TaxPercentage = model.TaxPercentage,
                            TotalPrice = model.TotalPrice
                        };

                        _context.PurchaseOrderLines.Add(newPurchaseOrderLine);
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

        public async Task<object> DeletePurchaseOrderLine(int PurchaseOrderLineId)
        {
            var result = await _context.PurchaseOrderLines.Where(a => a.OrderLineId == PurchaseOrderLineId).FirstOrDefaultAsync();
            if (result != null)
            {
                //result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<object>> GetPurchaseOrderLines()
        {
            return await _context.PurchaseOrderLines.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<object> GetPurchaseOrderLine(int PurchaseOrderLineId)
        {
            return await _context.PurchaseOrderLines.FirstOrDefaultAsync(a => a.OrderLineId == PurchaseOrderLineId && a.IsActive == true);
        }

        public async Task<PurchaseOrderLineViewModel> UpdatePurchaseOrderLine(int PurchaseOrderLineId, PurchaseOrderLineViewModel model)
        {
            var result = await _context.PurchaseOrderLines.FirstOrDefaultAsync(a => a.OrderLineId == PurchaseOrderLineId);
            if (result != null)
            {

                result.OrderLineDescription = model.OrderLineDescription;
                result.OrderLineQuantity = model.OrderLineQuantity;
                result.OrderLineUnitPrice = model.OrderLineUnitPrice;
                result.TaxPercentage = model.TaxPercentage;
                result.TotalPrice = model.TotalPrice;

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
