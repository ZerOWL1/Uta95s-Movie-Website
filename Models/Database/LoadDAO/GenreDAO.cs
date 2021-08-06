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
    public class GenreDAO
    {
        //get all genre return data table
        public DataTable GetAllGenre()
        {
            string sql = "SELECT * FROM GENRE";
            return DBContext.GetDataBySQL(sql);
        }

        //get movie by genre ID
        public DataTable GetMovieByGenre(int gid, int currentPage)
        {
            string sql = "SELECT * FROM STATUS INNER JOIN MOVIES ON STATUS.SID = MOVIES.SID"
                         + " INNER JOIN MOVIE_GENRE ON MOVIES.MID = MOVIE_GENRE.MID"
                         + " INNER JOIN GENRE ON MOVIE_GENRE.GID = GENRE.GID"
                         + " WHERE GENRE.GID = " + gid
                         + " ORDER BY GENRE.GID OFFSET " + (currentPage - 1) * 12 + " ROWS FETCH NEXT 12 ROWS ONLY";
            return DBContext.GetDataBySQL(sql);
        }

        //get dataTable genre Name
        public DataTable GetNameGenre(int gid)
        {
            string sql = "SELECT * FROM STATUS INNER JOIN MOVIES ON STATUS.SID = MOVIES.SID"
                         + " INNER JOIN MOVIE_GENRE ON MOVIES.MID = MOVIE_GENRE.MID"
                         + " INNER JOIN GENRE ON MOVIE_GENRE.GID = GENRE.GID"
                         + " WHERE GENRE.GID = " + gid;
            return DBContext.GetDataBySQL(sql);
        }

        //search movie by text input
        public DataTable GetMovieBySearch(string text, int currentPage)
        {
            string sql = "SELECT DISTINCT * FROM ACTOR INNER JOIN MOVIE_ACTOR ON ACTOR.AID = MOVIE_ACTOR.AID"
                         + " INNER JOIN MOVIES ON MOVIE_ACTOR.MID = MOVIES.MID"
                         + " INNER JOIN MOVIE_DIRECTOR ON MOVIES.MID = MOVIE_DIRECTOR.MID"
                         + " INNER JOIN DIRECTOR ON MOVIE_DIRECTOR.DID = DIRECTOR.DID"
                         + " WHERE MOVIES.Title LIKE '%" + text + "%' OR ACTOR.AcName LIKE '%" + text + "%' OR DIRECTOR.DiName LIKE '%" + text + "%'"
                         + " ORDER BY MOVIES.MID OFFSET " + (currentPage - 1) * 12 + " ROWS FETCH NEXT 12 ROWS ONLY";
            return DBContext.GetDataBySQL(sql);
        }

        //get movie by title, actor name, director,
        public DataTable GetNumberSearch(string text)
        {
            string sql = "SELECT DISTINCT * FROM ACTOR INNER JOIN MOVIE_ACTOR ON ACTOR.AID = MOVIE_ACTOR.AID"
                         + " INNER JOIN MOVIES ON MOVIE_ACTOR.MID = MOVIES.MID"
                         + " INNER JOIN MOVIE_DIRECTOR ON MOVIES.MID = MOVIE_DIRECTOR.MID"
                         + " INNER JOIN DIRECTOR ON MOVIE_DIRECTOR.DID = DIRECTOR.DID"
                         + " WHERE MOVIES.Title LIKE '%" + text + "%' OR ACTOR.AcName LIKE '%" + text + "%' OR DIRECTOR.DiName LIKE '%" + text + "%'";
            return DBContext.GetDataBySQL(sql);
        }

        //get list genre
        public List<Genre> GetAllGenres()
        {
            List<Genre> listG = new List<Genre>();
            string sql = "SELECT * FROM GENRE";
            DataTable data = DBContext.GetDataBySQL(sql);
            foreach (DataRow row in data.Rows)
            {
                int gid = Convert.ToInt32(row["GID"]);
                string gname = row["GName"].ToString();
                Genre genre = new Genre(gid, gname);
                listG.Add(genre);
            }
            return listG;
        }

        //add genre
        public int AddGenre(string gname)
        {
            string sql = "Insert into [GENRE] Values (@gname)";
            SqlParameter sqlParameters = new SqlParameter("@gname", SqlDbType.NVarChar);
            sqlParameters.Value = gname;

            return DBContext.ExecuteSQL(sql, sqlParameters);

        }

        //update genre
        public int UpdateGenre(ArrayList arrayList)
        {
            string sql = "UPDATE [GENRE] SET [GName] = @gname WHERE GID = @gid";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@gname", SqlDbType.NVarChar),
                new SqlParameter("@gid", SqlDbType.Int),
            };
            for (int i = 0; i < arrayList.Count; i++)
            {
                sqlParameters[i].Value = arrayList[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);

        }

        //delete genre
        public int DeleteGenre(int gid)
        {
            string sql = "DELETE FROM [GENRE] WHERE GID = @gid";

            SqlParameter sqlParameters = new SqlParameter("@gid", SqlDbType.Int);
            sqlParameters.Value = gid;

            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        //check genre
        public bool CheckGenreAlreadyExisted(string genre)
        {
            string sql = "select * from GENRE where GName = '" + genre + "'";
            DataTable data = DBContext.GetDataBySQL(sql);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //get genre by ID
        public Genre GetGenreByID(int gid)
        {
            string sql = "select * from GENRE where GID = " + gid;
            DataTable data = DBContext.GetDataBySQL(sql);
            DataRow row = data.Rows[0];
            string gname = row["GName"].ToString();
            Genre genre = new Genre(gid, gname);
            return genre;
        }

        //check movie genre exist
        public bool CheckMovieGenreAlreadyExisted(int mid, int gid)
        {
            string sql = "select * from [MOVIE_GENRE] where MID = " + mid + " and GID = " + gid;
            DataTable data = DBContext.GetDataBySQL(sql);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //add movie genre by movie id, genre id
        public int AddMovieGenre(int mid, int gid)
        {
            string sql = "Insert into [MOVIE_GENRE] Values  (@gid,@mid)";
            ArrayList ma = new ArrayList() { gid, mid };
            SqlParameter[] sqlParameters = new SqlParameter[]{
                new SqlParameter("@gid", SqlDbType.Int),
                new SqlParameter("@mid", SqlDbType.Int),
            };
            for (int i = 0; i < ma.Count; i++)
            {
                sqlParameters[i].Value = ma[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);
        }
    }
}
