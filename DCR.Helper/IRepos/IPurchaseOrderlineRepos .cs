using DCR.ViewModel.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IPurchaseOrderline
    {
        Task<IEnumerable<object>> GetPurchaseOrderLines();
        Task<object> GetPurchaseOrderLine(int PurchaseOrderLineId);
        Task<PurchaseOrderLineViewModel> AddPurchaseOrderLine(PurchaseOrderLineViewModel model);
        Task<PurchaseOrderLineViewModel> UpdatePurchaseOrderLine(int PurchaseOrderLineId, PurchaseOrderLineViewModel model);
        Task<object> DeletePurchaseOrderLine(int PurchaseOrderLineId);
    }
}
