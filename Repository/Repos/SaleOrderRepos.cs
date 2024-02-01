using DAL.EntityModels;
using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repos
{
    public class SaleOrderRepos : ISaleOrderRepos
    {
        private readonly EMS_ITCContext _context;


        public SaleOrderRepos(EMS_ITCContext context)
        {
            _context = context;
        }



        public async Task<SaleOrderViewModel> AddSaleOrder(SaleOrderViewModel model)
        {
            try
            {



                if (model.CustomerId != null)
                {
                    var result = await _context.Customers.FirstOrDefaultAsync(b => b.CustomerId == model.CustomerId && b.IsActive == true);
                    // Create a corresponding warehouse record

                    var customerid = new Customer
                    {
                        CustomerId = result.CustomerId,
                        // Map other properties as needed
                    };


                    if (model.CustomerId == customerid.CustomerId)
                    {


                        // Create a new User entity
                        var newSaleOrder = new SalesOrder
                        {
                            CustomerId = model.CustomerId,
                            CreateDate = model.CreateDate,
                            ShippingDate = model.ShippingDate,
                            Status = model.Status,
                            Total = model.Total,
                            CreatedBy = "Admin"

                        };

                        _context.SalesOrders.Add(newSaleOrder);
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

        public async Task<object> DeleteSaleOrder(int SaleOrderId)
        {

            var result = await _context.SalesOrders.Where(a => a.SalesOrderId == SaleOrderId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetSaleOrder(int SaleOrderId)
        {
            return await _context.SalesOrders.FirstOrDefaultAsync(a => a.SalesOrderId == SaleOrderId && a.IsActive == true);
        }

        public async Task<IEnumerable<object>> GetSaleOrders()
        {
            return await _context.SalesOrders.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<SaleOrderViewModel> UpdateSaleOrder(int SaleOrderId, SaleOrderViewModel model)
        {
            var result = await _context.SalesOrders.FirstOrDefaultAsync(a => a.SalesOrderId == SaleOrderId);
            if (result != null)
            {

                result.CreateDate = model.CreateDate;
                result.ShippingDate = model.ShippingDate;
                result.Status = model.Status;
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
