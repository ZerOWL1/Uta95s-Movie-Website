using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO
{
    public class MoviesDAO
    {
        public SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        private SqlDataAdapter da = new SqlDataAdapter();
        private DBContext db = new DBContext();
        private SqlDataReader dr;
        private SqlConnection con = new SqlConnection();
        private string status = String.Empty;


        public DataTable GetALLMovies()
        {
            string sql = "SELECT * FROM MOVIES ORDER BY DateADD DESC";
            return DBContext.GetDataBySQL(sql);
        }

        public DataTable Get7MoviesLatest()
        {
            string sql = "SELECT * FROM MOVIES INNER JOIN dbo.STATUS ON STATUS.SID = MOVIES.SID";
            return DBContext.GetDataBySQL(sql);
        }

        public DataTable GetRandomTop1()
        {
            string sql = "SELECT TOP 1 * FROM MOVIES ORDER BY NEWID()";
            return DBContext.GetDataBySQL(sql);
        }

        public DataTable GetRandom6Movies()
        {
            string sql = "SELECT TOP 6 * FROM MOVIES INNER JOIN dbo.STATUS ON STATUS.SID = MOVIES.SID ORDER BY NEWID()";
            return DBContext.GetDataBySQL(sql);
        }

        public DataTable GetDramaMovies()
        {
            string sql = "SELECT TOP 7 * FROM MOVIES"+
                         " INNER JOIN dbo.STATUS ON STATUS.SID = MOVIES.SID"+
                         " INNER JOIN dbo.MOVIE_GENRE ON MOVIE_GENRE.MID = MOVIES.MID"+
                         " INNER JOIN dbo.GENRE ON GENRE.GID = MOVIE_GENRE.GID WHERE GENRE.GID = '2'"+
                         " ORDER BY DATEADD DESC";
            return DBContext.GetDataBySQL(sql);
        }
    }
}
