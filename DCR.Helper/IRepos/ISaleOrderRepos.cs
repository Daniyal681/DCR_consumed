using DCR.Helper.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface ISaleOrderRepos
    {
        Task<IEnumerable<object>> GetSaleOrders();
        Task<object> GetSaleOrder(int SaleOrderId);
        Task<SaleOrderViewModel> AddSaleOrder(SaleOrderViewModel model);
        Task<SaleOrderViewModel> UpdateSaleOrder(int SaleOrderId, SaleOrderViewModel model);
        Task<object> DeleteSaleOrder(int SaleOrderId);
    }
}
