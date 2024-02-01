using DCR.ViewModel.ViewModel;

namespace DCR.ViewModel.IRepos
{
    public interface IPurchaseOrderDetailRepos
    {
        Task<IEnumerable<object>> GetPurchaseOrderDetails();
        Task<object> GetPurchaseOrderDetail(int PurchaseOrderDetailId);
        Task<PurchaseOrderDetailViewModel> AddPurchaseOrderDetail(PurchaseOrderDetailViewModel model);
        Task<PurchaseOrderDetailViewModel> UpdatePurchaseOrderDetail(int PurchaseOrderDetailId, PurchaseOrderDetailViewModel model);
        Task<object> DeletePurchaseOrderDetail(int PurchaseOrderDetailId);
    }
}
