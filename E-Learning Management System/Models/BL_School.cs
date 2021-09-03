using E_Learning_Management_System.Models.Custom;
using E_Learning_Management_System.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Learning_Management_System.Models
{
    public class BL_School
    {
        public static void Save(School school, bool IsNew = true)
        {

            SqlParameter[] prm = new SqlParameter[]
            {
                new SqlParameter("SchoolID",school.SchoolID),
                new SqlParameter("SchoolName",school.SchoolName),
                new SqlParameter("SchoolAddress",school.SchoolAddress),
                new SqlParameter("Contact",school.Contact),
                new SqlParameter("Image",school.Image),
                new SqlParameter("Status",school.Status),
                new SqlParameter("type",IsNew==true?Actions.Insert:Actions.Update),
            };
            Helper.sp_Execute("sp_School", prm);
        }
        public static List<School> GetSchools(School schools=null)
        {
            if (schools == null)
            {
                schools = new School();
            }
            SqlParameter[] prm = new SqlParameter[]
            {
                new SqlParameter("SchoolID",schools.SchoolID),
                new SqlParameter("SchoolName",schools.SchoolName),
                new SqlParameter("SchoolAddress",schools.SchoolAddress),
                new SqlParameter("Contact",schools.Contact),
                new SqlParameter("Status",schools.Status),
                new SqlParameter("type",Actions.Select),
            };
            List<School> Schools = new List<School>();
            DataTable dt = Helper.sp_GetTable("", prm);
            foreach (DataRow dr in dt.Rows)
            {
                School school = new School();
                school.SchoolID = Convert.ToInt32(dr["SchoolID"]);
                school.SchoolName = Convert.ToString(dr["SchoolName"]);
                school.SchoolAddress = Convert.ToString(dr["SchoolAddress"]);
                school.Contact = Convert.ToString(dr["Contact"]);
                school.Status = Convert.ToInt32(dr["Status"]);
                Schools.Add(school);
            }
            return Schools;
        }

        internal static void Delete(int ID)
        {
            SqlParameter[] prm = new SqlParameter[]
            {
                new SqlParameter("SchoolID",ID),
                new SqlParameter("type",Actions.Delete),
            };
            Helper.sp_Execute("sp_School",prm);
        }
    }
    public class School
    {
        public int? SchoolID { get; set; }
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public string SchoolAddress { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public HttpPostedFileBase UploadFile { get; set; }
    }
}