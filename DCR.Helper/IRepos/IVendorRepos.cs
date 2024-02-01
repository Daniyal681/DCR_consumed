using DCR.Helper.ViewModel;


namespace DCR.ViewModel.IRepos
{
    public interface IVendorRepos
    {
        Task<IEnumerable<object>> GetVendors();
        Task<object> GetVendor(int VendorId);
        Task<VendorViewModel> AddVendor(VendorViewModel model);
        Task<VendorViewModel> UpdateVendor(int VendorId, VendorViewModel model);
        Task<object> DeleteVendor(int VendorId);
    }
}
