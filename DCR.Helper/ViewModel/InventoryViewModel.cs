using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.ViewModel.ViewModel
{
    public class InventoryViewModel
    {
        public int ProductId { get; set; }
        public int TotalInventory { get; set; }
        public int ActiveInventory { get; set; }
        public int InActiveInventory { get; set; }
        public int InventoryDuration { get; set; }
    }
}
