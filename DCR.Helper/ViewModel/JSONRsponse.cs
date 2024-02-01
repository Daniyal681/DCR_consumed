using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.ViewModel.ViewModel
{
    public class JSONRsponse
    {
        public bool hasError { get; set; } = false;
        public string erorMessage { get; set; } = string.Empty;
        public dynamic response { get; set; }
    }
}
