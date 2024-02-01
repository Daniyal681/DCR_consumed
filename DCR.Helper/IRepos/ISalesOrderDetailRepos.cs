using DCR.ViewModel.ViewModel;

namespace DCR.ViewModel.IRepos
{
    public interface ISalesOrderDetail
    {
        Task<IEnumerable<object>> GetSalesOrderDetails();
        Task<object> GetSalesOrderDetail(int SaleseOrderDetailId);
        Task<SalesOrderDetailViewModel> AddSalesOrderDetail(SalesOrderDetailViewModel model);
        Task<SalesOrderDetailViewModel> UpdateSalesOrderDetail(int SalesOrderDetailId, SalesOrderDetailViewModel model);
        Task<object> DeleteSalesOrderDetail(int SalesOrderDetailId);
    }
}
