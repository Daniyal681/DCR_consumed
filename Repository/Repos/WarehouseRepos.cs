using DAL.EntityModels;
using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using DCR.ViewModel.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class WarehouseRepos : IWarehouseRepos
    {

        private readonly EMS_ITCContext _context;

        public WarehouseRepos(EMS_ITCContext context)
        {
            _context = context;
        }

        public async Task<bool> AddWarehouse(WarehouseViewModel model)
        {
            try
            {
                var NewWarehouse = new Warehouse
                {
                    BranchId = model.WarehouseId,
                    WarehouseName = model.WarehouseName,
                    WarehouseDescription = model.WarehouseDescription,
                    WarehouseType = model.WarehouseType,
                };

                _context.Warehouses.Add(NewWarehouse);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteWarehouse(int WarehouseId)
        {
            try
            {
                var Result = await _context.Warehouses.Where(a => a.WarehouseId == WarehouseId).FirstOrDefaultAsync();
                if (Result != null)
                {
                    Result.IsActive = false; 
                    await _context.SaveChangesAsync();
                }
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<WarehouseViewModel> GetWarehouse(int WarehouseId)
        {
            var Result = await _context.Warehouses.FirstOrDefaultAsync(a => a.WarehouseId == WarehouseId && a.IsActive == true);

            if (Result != null)
            {
                var Model = new WarehouseViewModel
                {
                    WarehouseName = Result.WarehouseName,
                    WarehouseDescription = Result.WarehouseDescription,
                    WarehouseType = Result.WarehouseType
                };

                return Model;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<WarehouseViewModel>> GetWarehouses()
        {
            try
            {
                WarehouseViewModel Model = new WarehouseViewModel();
                IEnumerable<WarehouseViewModel> WareHouses = _context.Warehouses
                      .Where(x => x.IsActive == true)
                      .Select(x => new WarehouseViewModel
                      {
                          WarehouseName = x.WarehouseName,
                          WarehouseDescription = x.WarehouseDescription,
                          WarehouseType = x.WarehouseType
                      });

                return WareHouses.ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> UpdateWarehouse(WarehouseViewModel model)
        {
            var Result = await _context.Warehouses.FirstOrDefaultAsync(a => a.WarehouseId == model.WarehouseId);
            if (Result != null)
            {

                Result.WarehouseName = model.WarehouseName;
                Result.WarehouseDescription = model.WarehouseDescription;
                Result.WarehouseType = model.WarehouseType;

                Result.UpdatedOn = DateTime.Now; 
                                                 
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
