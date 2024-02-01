using DAL.EntityModels;
using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repos
{
    public class SaleOrderLineRepos : ISaleOrderLineRepos
    {
        private readonly EMS_ITCContext _context;


        public SaleOrderLineRepos(EMS_ITCContext context)
        {
            _context = context;

        }

        public async Task<SaleOrderLineViewModel> AddSaleOrderLine(SaleOrderLineViewModel model)
        {
            try
            {


                if (model.ProductId != null)
                {
                    var resultproduct = await _context.Products.FirstOrDefaultAsync(b => b.ProductId == model.ProductId && b.IsActive == true);
                    // Create a corresponding warehouse record

                    var productid = new Product
                    {
                        ProductId = resultproduct.ProductId,
                        // Map other properties as needed
                    };


                    var resultsaleorder = await _context.SalesOrders.FirstOrDefaultAsync(b => b.SalesOrderId == model.SalesOrderId && b.IsActive == true);
                    // Create a corresponding warehouse record

                    var saleorderid = new SalesOrder
                    {
                        SalesOrderId = resultsaleorder.SalesOrderId,
                        // Map other properties as needed
                    };


                    if (model.ProductId == productid.ProductId && model.SalesOrderId == saleorderid.SalesOrderId)
                    {


                        // Create a new User entity
                        var newSaleOrderLine = new SaleOrderLine
                        {
                            ProductId = model.ProductId,
                            SalesOrderId = model.SalesOrderId,
                            Quantity = model.Quantity,
                            Description = model.Description,
                            UnitPrice = model.UnitPrice,
                            Total = model.Total,
                            CreatedBy = "Admin"

                        };

                        _context.SaleOrderLines.Add(newSaleOrderLine);
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

        public async Task<object> DeleteSaleOrderline(int SaleOrderLineId)
        {

            var result = await _context.SaleOrderLines.Where(a => a.SalesOrderLineId == SaleOrderLineId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetSaleOrderLine(int SaleOrderLineId)
        {
            return await _context.SaleOrderLines.FirstOrDefaultAsync(a => a.SalesOrderLineId == SaleOrderLineId && a.IsActive == true);
        }

        public async Task<IEnumerable<object>> GetSaleOrderLines()
        {
            return await _context.SaleOrderLines.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<SaleOrderLineViewModel> UpdateSaleOrderLine(int SaleOrderLineId, SaleOrderLineViewModel model)
        {
            var result = await _context.SaleOrderLines.FirstOrDefaultAsync(a => a.SalesOrderLineId == SaleOrderLineId);
            if (result != null)
            {

                result.ProductId = model.ProductId;
                result.SalesOrderId = model.SalesOrderId;
                result.Quantity = model.Quantity;
                result.Description = model.Description;
                result.UnitPrice = model.UnitPrice;
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
