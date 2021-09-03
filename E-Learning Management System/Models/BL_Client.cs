using E_Learning_Management_System.Models.Custom;
using E_Learning_Management_System.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Learning_Management_System.Models
{
    public class BL_Client
    {
        public static void Save(Client client, bool IsNew = true)
        {

            SqlParameter[] prm = new SqlParameter[]
            {
                new SqlParameter("ClientID",client.ClientID),
                new SqlParameter("ClientName",client.ClientName),
                new SqlParameter("ClientAddress",client.ClientAddress),
                new SqlParameter("ClientContact",client.ClientContact),
                new SqlParameter("ClientEmail",client.ClientEmail),
                new SqlParameter("ClientPassword",client.ClientPassword),
                new SqlParameter("ClientImage",client.ClientImage),
                new SqlParameter("Status",client.Status),
                new SqlParameter("type",IsNew==true?Actions.Insert:Actions.Update),
            };
            Helper.sp_Execute("sp_School", prm);
        }
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