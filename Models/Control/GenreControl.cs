using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Control
{
    public class GenreControl
    {
        private static GenreDAO gDao = new GenreDAO();
        private string status = string.Empty;
        
        //list all genre
        public static ArrayList Genre()
        {
            DataTable mvTable = gDao.GetAllGenre();
            ArrayList listGenre = new ArrayList();

            int count = 0;
            foreach (var item in mvTable.Rows)
            {
                int gid = int.Parse(mvTable.Rows[count]["GID"].ToString());
                string gname = mvTable.Rows[count]["GName"].ToString();
                Genre G = new Genre(gid, gname);
                listGenre.Add(G);
                count++;
            }
            return listGenre;
        }
    }
}
