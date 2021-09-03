using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace E_Learning_Management_System.Models.DataAccessLayer
{
    public class Helper
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        public static void sp_Execute(string sp,SqlParameter[] prm)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sp,con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(prm);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

                con.Close();
            }
        }

        public static DataTable sp_GetTable(string sp, SqlParameter[] prm)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sp,con);
                cmd.Parameters.Add(prm);
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(dt);
            }
            catch (Exception)
            {

            }
            return dt;
        }
    }
}