using DCR.Helper.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IProductRepos
    {
        Task<IEnumerable<object>> GetProducts();
        Task<object> GetProduct(int ProductId);
        Task<ProductViewModel> AddProduct(ProductViewModel model);
        Task<ProductViewModel> UpdateProduct(ProductViewModel model);
        Task<object> DeleteProduct(int ProductId);
    }
}
