using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.Helper.ViewModel
{
    public class CustomerInventoryViewModel
    {
        public int CustomerId{ get; set; }
        public string CustomerName{ get; set; }
        public string CustomerType { get; set; }

        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }

        public string MarketName { get; set; }

        public string Brand { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public string Memory { get; set; }
        public string Color { get; set; }

        public int TotalInventory{ get; set; }
        public int TotalActivatedInventory { get; set; }
        public int TotalInActivatedInventory { get; set; }

        public string DeviceType { get; set; }




    }
}
