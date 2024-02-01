using DCR.ViewModel.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IProductWarehouseRepos
    {
        Task<IEnumerable<object>> GetProductWarehouses();
        Task<object> GetProductWarehouse(int ProductWarehouseId);
        Task<ProductWarehouseViewModel> AddProductWarehouse(ProductWarehouseViewModel model);
        Task<ProductWarehouseViewModel> UpdateProductWarehouse(int ProductWarehouseId, ProductWarehouseViewModel model);
        Task<object> DeleteProductWarehouse(int ProductWarehouseId);
    }
}
