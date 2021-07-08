using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO
{
    public class GenreDAO
    {
        public DataTable GetALLGenre()
        {
            string sql = "SELECT * FROM GENRE";
            return DBContext.GetDataBySQL(sql);
        }
    }
}
