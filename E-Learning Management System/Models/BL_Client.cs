using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Learning_Management_System.Models
{
    public class BL_Client
    {
    }
    public class Client
    {

        public int? ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientContact { get; set; }
        public string ClientAddress { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPassword { get; set; }
        public string ClientImage { get; set; }
        public int Status { get; set; }
    }
}