using DAL.EntityModels;
using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repos
{
    public class SalesOrderDetailRepos : ISalesOrderDetail
    {
        private readonly EMS_ITCContext _context;

        public SalesOrderDetailRepos(EMS_ITCContext context)
        {
            _context = context;
        }
        public async Task<SalesOrderDetailViewModel> AddSalesOrderDetail(SalesOrderDetailViewModel model)
        {
            try
            {

                if (model.ProductId != null && model.SalesOrderId != null)
                {
                    var result = await _context.SalesOrderDetails.FirstOrDefaultAsync(b => b.ProductId == model.ProductId && b.SalesOrderId == model.SalesOrderId);
                    // Create a corresponding warehouse record

                    var product = new Product
                    {
                        ProductId = result.ProductId.Value,
                   
                        // Map other properties as needed
                    };
                    var salesOrder  = new SalesOrder
                    {
                        SalesOrderId = result.SalesOrderId.Value,

                        // Map other properties as needed
                    };


                    if (model.ProductId == product.ProductId && model.SalesOrderId == salesOrder.SalesOrderId)
                    {

                        var newSalesOrderDetail = new SalesOrderDetail
                        {

                            Quantity = model.Quantity,
                            UnitPrice = model.UnitPrice,
                            SubTotal = model.SubTotal
                        };

                        _context.SalesOrderDetails.Add(newSalesOrderDetail);
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

        public async Task<object> DeleteSalesOrderDetail(int SalesOrderDetailId)
        {
            var result = await _context.SalesOrderDetails.Where(a => a.SalesOrderId == SalesOrderDetailId).FirstOrDefaultAsync();
            if (result != null)
            {
                //result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetSalesOrderDetail(int SaleseOrderDetailId)
        {
            return await _context.SalesOrderDetails.FirstOrDefaultAsync(a => a.SalesOrderId == SaleseOrderDetailId && a.IsActive == true);
        }

        public async Task<IEnumerable<object>> GetSalesOrderDetails()
        {
            return await _context.SalesOrderDetails.ToListAsync();
        }

        public async Task<SalesOrderDetailViewModel> UpdateSalesOrderDetail(int SalesOrderDetailId, SalesOrderDetailViewModel model)
        {
            var result = await _context.SalesOrderDetails.FirstOrDefaultAsync(a => a.SalesOrderId == SalesOrderDetailId);
            if (result != null)
            {

                result.Quantity = model.Quantity;
                result.UnitPrice = model.UnitPrice;
                result.SubTotal = model.SubTotal;

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
