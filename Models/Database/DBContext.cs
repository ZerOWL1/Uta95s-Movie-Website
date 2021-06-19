using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL_Database;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database
{
    public class DBContext
    {
        public string GetConnection()
        {
            DBConnection dbCon = new DBConnection();
            var conStr = dbCon.GetConnectionString();
            return conStr;
        } 
    }
}
