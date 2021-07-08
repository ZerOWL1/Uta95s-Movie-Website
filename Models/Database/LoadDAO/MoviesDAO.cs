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

        public List<Movie> GetMovies()
        {
            List<Movie> listMovies = new List<Movie>();
            try
            {
                con.ConnectionString = db.ConnectionString();
                con.Open();
                cmd.Connection = con;
                string sql = "SELECT * FROM MOVIES";
                cmd.CommandText = sql;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listMovies.Add(new Movie()
                    {
                         
                        //Title = dr.GetString(1),
                        //Description = dr.GetString(2),
                        //Total_Episode = dr.GetInt32(3),
                        //National = dr.GetString(4),
                        //Language = dr.GetString(5),
                        //Release = dr.GetString(6),
                        //Img =dr.GetByte(7)
                        //Trailer = dr.GetString(8),
                        //Length = dr.GetInt32(9),
                        //View = dr.GetInt32(10),
                        //DateAdd = dr.GetDateTime(11)

                    });
                }
                cmd.Clone();
            }
            catch (Exception e)
            {
                status = "Error while at GetActors Func " + e.Message;
                throw;
            }


            return listMovies;

        }

        public DataTable GetALLMovies()
        {
            string sql = "SELECT * FROM MOVIES ORDER BY DateADD DESC";
            return DBContext.GetDataBySQL(sql);
        }

        public DataTable Get7MoviesLatest()
        {
            string sql = "SELECT TOP 7 * FROM MOVIES ORDER BY DateADD DESC";
            return DBContext.GetDataBySQL(sql);
        }

        public DataTable GetTop1()
        {
            string sql = "SELECT TOP 1 * FROM MOVIES ORDER BY DateADD DESC";
            return DBContext.GetDataBySQL(sql);
        }

        public DataTable GetRandomMovies()
        {
            string sql = "SELECT TOP 6 * FROM MOVIES ORDER BY NEWID()";
            return DBContext.GetDataBySQL(sql);
        }

        public DataTable GetRandom6Movies()
        {
            string sql = "SELECT TOP 6 * FROM MOVIES ORDER BY NEWID()";
            return DBContext.GetDataBySQL(sql);
        }

        

        public DataTable GetDramaMovies()
        {
            string sql = "SELECT TOP 7 * FROM MOVIES M JOIN MOVIE_GENRE MG "
                 + "ON M.MID=MG.MID JOIN GENRE G ON MG.GID = G.GID WHERE G.GID = 2";
            return DBContext.GetDataBySQL(sql);
        }
    }
}
