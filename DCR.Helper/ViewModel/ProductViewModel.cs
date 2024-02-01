using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.Helper.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string? ProductType { get; set; }
        public int? MaterialId { get; set; }
        public int? ProductQuantity { get; set; }
        public double? ProductPrice { get; set; }
        public string? ProductSku { get; set; }
        public string? ProductCode { get; set; }
        public string? MarketName { get; set; }
        public string? Brand { get; set; }
        public string? Memory { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public string? Series { get; set; }
    }
}
