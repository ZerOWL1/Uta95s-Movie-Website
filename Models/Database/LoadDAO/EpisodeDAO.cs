using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO
{
    public class EpisodeDAO
    {
        public SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        private SqlDataAdapter da = new SqlDataAdapter();
        private DBContext db = new DBContext();
        private SqlConnection con = new SqlConnection();
        private string status = String.Empty;


        //get movie episode by id
        public DataTable GetMovieEpisodeById(int id)
        {
            string sql = "SELECT * FROM MOVIE_EPISODE WHERE MID = " + id;
            return DBContext.GetDataBySQL(sql);
        }

        //get episode by id movie, id episode
        public DataTable GetEpisode(int id, int ep)
        {
            string sql = "SELECT * FROM MOVIE_EPISODE WHERE MID = " + id + " AND Episode = " + ep;
            return DBContext.GetDataBySQL(sql);
        }

        //get 4 latest movie
        public DataTable Get4MoviesLatest()
        {
            string sql = "SELECT TOP 4 * FROM MOVIES INNER JOIN dbo.STATUS ON STATUS.SID = MOVIES.SID";
            return DBContext.GetDataBySQL(sql);
        }

        //get all episode return list
        public List<Episode> GetAllEpisode()
        {
            List<Episode> listE = new List<Episode>();
            string sql = "select * from MOVIE_EPISODE";
            DataTable data = DBContext.GetDataBySQL(sql);
            foreach (DataRow row in data.Rows)
            {
                int mid = Convert.ToInt32(row["MID"]);
                int episode = Convert.ToInt32(row["Episode"]);
                string title = row["Title"].ToString();
                string episodelink = row["Episode_link"].ToString();
                Episode e = new Episode(mid, episode, title, episodelink);
                listE.Add(e);
            }
            return listE;
        }

        //add episode
        public int AddEpisode(ArrayList arrayList)
        {
            string sql = "Insert into [MOVIE_EPISODE] Values (@mid, @episode,@title,@e_link)";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@mid", SqlDbType.Int),
                new SqlParameter("@episode", SqlDbType.Int),
                new SqlParameter("@title", SqlDbType.NVarChar),
                new SqlParameter("@e_link", SqlDbType.NVarChar)
            };
            for (int i = 0; i < arrayList.Count; i++)
            {
                sqlParameters[i].Value = arrayList[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        //get episode obj by movie id, episode id
        public Episode GetEpisodeByMID(int MID, int eposide)
        {
            string sql = "select * from MOVIE_EPISODE where MID = " + MID + " and Episode = " + eposide;
            DataTable data = DBContext.GetDataBySQL(sql);
            DataRow dataRow = data.Rows[0];
            int mid = Convert.ToInt32(dataRow["MID"]);
            int episode = Convert.ToInt32(dataRow["Episode"]);
            string title = dataRow["Title"].ToString();
            string episodelink = dataRow["Episode_link"].ToString();
            Episode e = new Episode(mid, episode, title, episodelink);
            return e;
        }

        //update episode
        public int UpdateEpisode(ArrayList arrayList)
        {
            string sql = "UPDATE [MOVIE_EPISODE] SET [MID] = @mid_new,[Episode] = @episode_new, [Title] = @title, [Episode_Link] = @e_link WHERE [MID] = @mid_old and [Episode] = @episode_old";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@mid_new", SqlDbType.Int),
                new SqlParameter("@episode_new", SqlDbType.Int),
                new SqlParameter("@title", SqlDbType.NVarChar),
                new SqlParameter("@e_link", SqlDbType.NVarChar),
                new SqlParameter("@mid_old", SqlDbType.Int),
                new SqlParameter("@episode_old", SqlDbType.Int)

            };
            for (int i = 0; i < arrayList.Count; i++)
            {
                sqlParameters[i].Value = arrayList[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);

        }

        //delete episode
        public int DeleteEpisode(ArrayList arrayList)
        {
            string sql = "DELETE FROM [MOVIE_EPISODE] WHERE [MID] = @mid_old and [Episode] = @episode_old";

            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@mid_old", SqlDbType.Int),
                new SqlParameter("@episode_old", SqlDbType.Int)
            };
            for (int i = 0; i < arrayList.Count; i++)
            {
                sqlParameters[i].Value = arrayList[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);
        }
    }
}
