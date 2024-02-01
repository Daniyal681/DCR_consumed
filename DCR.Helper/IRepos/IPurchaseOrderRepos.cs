using DCR.Helper.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IPurchaseOrderRepos
    {
        Task<IEnumerable<object>> GetPurchaseOrders();
        Task<object> GetPurchaseOrder(int PurchaseId);
        Task<PurchaseOrderViewModel> AddPurchaseOrder(PurchaseOrderViewModel model);
        Task<PurchaseOrderViewModel> UpdatePurchaseOrder(int PurchaseId, PurchaseOrderViewModel model);
        Task<object> DeletePurchaseOrder(int PurchaseId);
    }
}
