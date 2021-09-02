using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Learning_Management_System.Models.Custom
{
    public class Actions
    {
        public static int Insert
        {
            get
            {
                return 1;
            }
            set { }
        }
        public static int Update
        {
            get
            {
                return 2;
            }
        }
        public static int Delete
        {
            get
            {
                return 3;
            }
        }
        public static int Select
        {
            get
            {
                return 4;
            }
        }
    }
}