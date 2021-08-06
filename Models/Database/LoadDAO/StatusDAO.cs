using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO
{
    public class StatusDAO
    {
        public ArrayList GetAllStatus()
        {
            string sql = "SELECT * FROM STATUS";
            DataTable data = DBContext.GetDataBySQL(sql);
            ArrayList list = new ArrayList();
            foreach (DataRow item in data.Rows)
            {
                Status s = new Status();
                s.Sid = Convert.ToInt32(item["SID"].ToString());
                s.Sname = item["SaName"].ToString();
                list.Add(s);
            }
            return list;
        }
    }
}
