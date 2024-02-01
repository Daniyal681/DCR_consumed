using DCR.Helper.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IWarehouseRepos
    {
        Task<List<WarehouseViewModel>> GetWarehouses();
        Task<WarehouseViewModel> GetWarehouse(int WarehouseId);
        Task<bool> AddWarehouse(WarehouseViewModel model);
        Task<bool> UpdateWarehouse(WarehouseViewModel model);
        Task<bool> DeleteWarehouse(int WarehouseId);
    }
}
