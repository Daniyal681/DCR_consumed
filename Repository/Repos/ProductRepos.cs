using DAL.EntityModels;
using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repos
{
    public class ProductRepos : IProductRepos
    {

        private readonly EMS_ITCContext _context;

        public ProductRepos(EMS_ITCContext context)
        {
            _context = context;
        }


        public async Task<ProductViewModel> AddProduct(ProductViewModel model)
        {
            try
            {
                // Create a new User entity
                var NewProduct = new Product
                {
                    ProductType = model.ProductType,
                    ProductQuantity = model.ProductQuantity,
                    ProductPrice = model.ProductPrice,
                    ProductSku = model.ProductSku,
                    MaterialId = model.MaterialId,
                    ProductCode = model.ProductCode,
                    MarketName = model.MarketName,
                    Brand = model.Brand,
                    Memory = model.Memory,
                    Model = model.Model,
                    Color = model.Color,
                    Series = model.Series

                };
                NewProduct.CreatedBy = "Admin";

                _context.Products.Add(NewProduct);
                await _context.SaveChangesAsync();




                return model;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<object> DeleteProduct(int ProductId)
        {
            var result = await _context.Products.Where(a => a.ProductId == ProductId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetProduct(int ProductId)
        {
            return await _context.Products.FirstOrDefaultAsync(a => a.ProductId == ProductId && a.IsActive == true);
        }

        public async Task<IEnumerable<object>> GetProducts()
        {
            return await _context.Products.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel model)
        {
            var result = await _context.Products.FirstOrDefaultAsync(a => a.ProductId == model.ProductId);
            if (result != null)
            {

                result.ProductType = model.ProductType;
                result.ProductQuantity = model.ProductQuantity;
                result.ProductPrice = model.ProductPrice;
                result.MaterialId = model.MaterialId;
                result.ProductSku = model.ProductSku;
                result.ProductCode = model.ProductCode;
                result.MarketName = model.MarketName;
                result.Brand = model.Brand;
                result.Memory = model.Memory;
                result.Model = model.Model;
                result.Color = model.Color;
                result.Series = model.Series;


                // Update other fields if needed, e.g., UpdatedBy and UpdatedOn
                //result.UpdatedBy = model.Name; // Set the appropriate value

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
