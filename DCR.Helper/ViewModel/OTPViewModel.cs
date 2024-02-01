using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.Helper.ViewModel
{
    public class OTPViewModel
    {
        public string To { get; set; }
        public string From { get; set; }
        public string MessageBody { get; set; }
        public string Subject { get; set; }
        public string RandomCode{ get; set; }
        public string Password { get; set; }
        public string OTP { get; set; }

    }
}
