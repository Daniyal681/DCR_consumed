using DAL.EntityModels;
using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repos
{
    public class ProductWarehouseRepos : IProductWarehouseRepos
    {
        private readonly EMS_ITCContext _context;

        public ProductWarehouseRepos(EMS_ITCContext context)
        {
            _context = context;
        }

        public async Task<ProductWarehouseViewModel> AddProductWarehouse(ProductWarehouseViewModel model)
        {
            try
            {

                if (model.ProductId != null && model.WarehouseId != null)
                {
                    var productWarehouse = await _context.ProductWarehouses.FirstOrDefaultAsync(b => b.ProductId == model.ProductId && b.WarehouseId == model.WarehouseId);
                    // Create a corresponding warehouse record

                    var productwarehouse = new ProductWarehouse
                    {
                        ProductId = model.ProductId,
                        WarehouseId = model.WarehouseId,
                        // Map other properties as needed
                    };
                    if (model.ProductId == productWarehouse.ProductId && model.WarehouseId == productWarehouse.WarehouseId)
                    {
                        // Create a new User entity
                        var Newproductwarehouse = new ProductWarehouse
                        {
                            ProductId = model.ProductId,
                            WarehouseId = model.WarehouseId

                        };

                        _context.ProductWarehouses.Add(Newproductwarehouse);
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

        public async Task<object> DeleteProductWarehouse(int ProductWarehouseId)
        {
            var result = await _context.ProductWarehouses.Where(a => a.ProductWarehouseId == ProductWarehouseId).FirstOrDefaultAsync();
            if (result != null)
            {
                //result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetProductWarehouse(int ProductWarehouseId)
        {
            return await _context.ProductWarehouses.FirstOrDefaultAsync(a => a.ProductWarehouseId == ProductWarehouseId);
        }

        public async Task<IEnumerable<object>> GetProductWarehouses()
        {
            return await _context.ProductWarehouses.ToListAsync();
        }

        public async Task<ProductWarehouseViewModel> UpdateProductWarehouse(int ProductWarehouseId, ProductWarehouseViewModel model)
        {
            var result = await _context.ProductWarehouses.FirstOrDefaultAsync(a => a.ProductWarehouseId == ProductWarehouseId);
            if (result != null)
            {

                result.ProductId = model.ProductId;
                result.WarehouseId = model.WarehouseId;


                //result.UpdatedOn = DateTime.Now; // Set the appropriate value
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
