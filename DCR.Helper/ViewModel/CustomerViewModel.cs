using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.Helper.ViewModel
{
    public class CustomerViewModel
    {

        public string CustomerName { get; set; }
        //public enum CustomerType { Distributor, Retailor, SubDealor, ThirdDealor, Online }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerPostalCode { get; set; }

    }
}
