using DCR.ViewModel.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface ISaleOrderLineRepos
    {
        Task<IEnumerable<object>> GetSaleOrderLines();
        Task<object> GetSaleOrderLine(int SaleOrderLineId);
        Task<SaleOrderLineViewModel> AddSaleOrderLine(SaleOrderLineViewModel model);
        Task<SaleOrderLineViewModel> UpdateSaleOrderLine(int SaleOrderLineId, SaleOrderLineViewModel model);
        Task<object> DeleteSaleOrderline(int SaleOrderLineId);
    }
}
