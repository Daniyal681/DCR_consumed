using DCR.ViewModel.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IInventoryRepos
    {
        Task<IEnumerable<object>> GetInventories();
        Task<object> GetInventory(int InventoryId);
        Task<InventoryViewModel> AddInventory(InventoryViewModel model);
        Task<InventoryViewModel> UpdateInventory(int InventoryId, InventoryViewModel model);
        Task<object> DeleteInventory(int InventoryId);
    }
}
