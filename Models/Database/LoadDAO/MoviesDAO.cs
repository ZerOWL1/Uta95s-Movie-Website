using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO
{
    public class MoviesDAO
    {
        public SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        private SqlDataAdapter da = new SqlDataAdapter();
        private DBContext db = new DBContext();
        private SqlConnection con = new SqlConnection();
        private string status = String.Empty;
        private EpisodeDAO eDAO = new EpisodeDAO();

        //count movies
        public int CountMovies()
        {
            string sql = "select COUNT(MID) as count from MOVIES";
            DataTable data = DBContext.GetDataBySQL(sql);
            DataRow row = data.Rows[0];
            return Convert.ToInt32(row["count"]);
        }

        public DataTable GetALLMovies()
        {
            string sql = "SELECT * FROM MOVIES ORDER BY DateADD DESC";
            return DBContext.GetDataBySQL(sql);
        }

        public DataTable Get7MoviesLatest()
        {
            string sql = "SELECT TOP 7 * FROM MOVIES INNER JOIN dbo.STATUS ON STATUS.SID = MOVIES.SID ORDER BY DATEADD DESC";
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
            string sql = "SELECT TOP 7 * FROM MOVIES" +
                         " INNER JOIN dbo.STATUS ON STATUS.SID = MOVIES.SID" +
                         " INNER JOIN dbo.MOVIE_GENRE ON MOVIE_GENRE.MID = MOVIES.MID" +
                         " INNER JOIN dbo.GENRE ON GENRE.GID = MOVIE_GENRE.GID WHERE GENRE.GID = '2'" +
                         " ORDER BY DATEADD DESC";
            return DBContext.GetDataBySQL(sql);
        }

        public DataTable GetMoviesById(int id)
        {
            string sql = "SELECT * FROM ACTOR INNER JOIN MOVIE_ACTOR ON ACTOR.AID = MOVIE_ACTOR.AID"
                         + " INNER JOIN MOVIES ON MOVIE_ACTOR.MID = MOVIES.MID"
                         + " INNER JOIN MOVIE_DIRECTOR ON MOVIES.MID = MOVIE_DIRECTOR.MID"
                         + " INNER JOIN DIRECTOR ON MOVIE_DIRECTOR.DID = DIRECTOR.DID"
                         + " WHERE MOVIES.MID = " + id;
            return DBContext.GetDataBySQL(sql);
        }

        public DataTable getMovieInfo()
        {
            string sql = "SELECT * FROM MOVIES INNER JOIN dbo.STATUS ON STATUS.SID = MOVIES.SID ORDER BY MID";
            return DBContext.GetDataBySQL(sql);
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> listMovies = new List<Movie>();
            string sql = "select MID, Title from MOVIES";
            DataTable data = DBContext.GetDataBySQL(sql);
            foreach (DataRow row in data.Rows)
            {
                int mid = Convert.ToInt32(row["MID"]);
                string title = row["Title"].ToString();
                Movie m = new Movie(mid, title);
                listMovies.Add(m);
            }
            return listMovies;
        }

        public MSBinary GetAllMovieInforByID(int ID)
        {
            MSBinary mBinary = new MSBinary();
            try
            {
                string sql = $"SELECT * FROM dbo.MOVIES WHERE MID = '{ID}'";
                DataTable data = DBContext.GetDataBySQL(sql);

                foreach (DataRow item in data.Rows)
                {
                    mBinary.MID = Convert.ToInt32(item["MID"].ToString());
                    mBinary.SID = Convert.ToInt32(item["SID"].ToString());
                    mBinary.Title = item["Title"].ToString();
                    mBinary.Desc = item["Description"].ToString();
                    mBinary.TotalEsp = Convert.ToInt32(item["Total_Episode"].ToString());
                    mBinary.Nation = item["Nationality"].ToString();
                    mBinary.Language = item["Languages"].ToString();
                    mBinary.Release = item["Release"].ToString();
                    mBinary.IMG = (byte[])item["Movie_IMG"];
                    mBinary.BigIMG = (byte[])item["BG_IMG"];
                    mBinary.Trailer = item["Trailer"].ToString();
                    mBinary.Length = Convert.ToInt32(item["Lenght"].ToString());
                    mBinary.View = Convert.ToInt32(item["View"].ToString());
                    mBinary.Date = Convert.ToDateTime(item["DateADD"].ToString());
                    mBinary.Download = item["Download"].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return mBinary;
        }

        public async Task<int> AddNewMovie(ArrayList arrayList, IFormFile MIMGByte, IFormFile MBigImgBytes)
        {
            try
            {
                string sql = "INSERT INTO dbo.MOVIES( SID , Title , Description , Total_Episode , Nationality , Languages , Release , Trailer , Lenght , [View] , DateADD ,  Download, Movie_IMG, BG_IMG)"
                            + " VALUES(@status, @title, @des, @totalesp, @nation, @language, @release, @trailer, @length, 0, @date, Null, @mimg, @bigimg)";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@status", SqlDbType.NVarChar),
                 new SqlParameter("@title", SqlDbType.NVarChar),
                 new SqlParameter("@des", SqlDbType.NVarChar),
                 new SqlParameter("@totalesp", SqlDbType.Int),
                 new SqlParameter("@nation", SqlDbType.NVarChar),
                 new SqlParameter("@language", SqlDbType.NVarChar),
                 new SqlParameter("@release", SqlDbType.NVarChar),
                 new SqlParameter("@trailer", SqlDbType.NVarChar),
                 new SqlParameter("@length", SqlDbType.Int),
                 new SqlParameter("@date", SqlDbType.Date),
                 new SqlParameter("@mimg", SqlDbType.VarBinary),
                 new SqlParameter("@bigimg", SqlDbType.VarBinary),
                };
                byte[] mimg;
                byte[] bigmimg;
                using (MemoryStream ms = new MemoryStream())
                {
                    await MIMGByte.CopyToAsync(ms);
                    mimg = ms.ToArray();
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    await MBigImgBytes.CopyToAsync(ms);
                    bigmimg = ms.ToArray();
                }

                for (int i = 0; i < arrayList.Count; i++)
                {
                    sqlParameters[i].Value = arrayList[i];

                }
                sqlParameters[10].Value = mimg;
                sqlParameters[11].Value = bigmimg;
                return DBContext.ExecuteSQL(sql, sqlParameters);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

        }
        public bool checkFavoriteExist(int mid)
        {
            try
            {
                string sql = "select * from FAVORITE_MOVIES where [MID] = " + mid;
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
        public int DeleteMovie_Favorite(int id)
        {
            if (checkFavoriteExist(id))
            {
                string sql = "DELETE [dbo].[FAVORITE_MOVIES] where MID =  @id";
                SqlParameter sqlParameters = new SqlParameter("@id", SqlDbType.Int);
                sqlParameters.Value = id;
                return DBContext.ExecuteSQL(sql, sqlParameters);

            }
            else
            {
                return 1;
            }
        }
        public int DeleteMovie(int id)
        {
            int rs = 0;
            try
            {
                string sql = "DELETE [dbo].[MOVIES] where MID = @id";


                SqlParameter sqlParameters = new SqlParameter("@id", SqlDbType.Int);
                sqlParameters.Value = id;
                rs = DBContext.ExecuteSQL(sql, sqlParameters);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

            return rs;
        }
        public bool checkMovieActorExist(int mid)
        {
            try
            {
                string sql = "SELECT * FROM [UTA95S_MOVIE_WEB].[dbo].[MOVIE_ACTOR] where [MID] = " + mid;
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
        public int DeleteMovie_Actor(int id)
        {
            try
            {
                int rs = 0;
                if (checkMovieActorExist(id))
                {
                    string sql = "DELETE [dbo].[MOVIE_ACTOR] Where MID = @mid";
                    SqlParameter sqlParameters = new SqlParameter("@mid", SqlDbType.Int);
                    sqlParameters.Value = id;
                    rs = DBContext.ExecuteSQL(sql, sqlParameters);
                }
                else
                {
                    rs = 1;
                }
                return rs;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public bool checkMovieGenreExist(int mid)
        {
            try
            {
                string sql = "SELECT * FROM [UTA95S_MOVIE_WEB].[dbo].[MOVIE_GENRE] where [MID] = " + mid;
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
        public int DeleteMovie_Genre(int id)
        {
            try
            {
                int rs = 0;
                if (checkMovieGenreExist(id))
                {
                    string sql = "DELETE [dbo].[MOVIE_GENRE] WHERE MID = @mid";
                    SqlParameter sqlParameters = new SqlParameter("@mid", SqlDbType.Int);
                    sqlParameters.Value = id;
                    rs = DBContext.ExecuteSQL(sql, sqlParameters);
                }
                else
                {
                    rs = 1;
                }
                return rs;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public bool checkMovieEpisodeExist(int mid)
        {
            try
            {
                string sql = "SELECT * FROM [UTA95S_MOVIE_WEB].[dbo].[MOVIE_EPISODE] where [MID] = " + mid;
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
        public int DeleteMovie_Ep(int id)
        {
            try
            {
                int rs = 0;
                if (checkMovieEpisodeExist(id))
                {
                    string sql = "DELETE [dbo].[MOVIE_EPISODE] where MID = @mid";
                    SqlParameter sqlParameters = new SqlParameter("@mid", SqlDbType.Int);
                    sqlParameters.Value = id;
                    rs = DBContext.ExecuteSQL(sql, sqlParameters);
                }
                else
                {
                    rs = 1;
                }
                return rs;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public bool checkMovieDirectorExist(int mid)
        {
            try
            {
                string sql = "SELECT * FROM [UTA95S_MOVIE_WEB].[dbo].[MOVIE_DIRECTOR] where [MID] = " + mid;
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
        public int DeleteMovie_Director(int id)
        {
            try
            {
                int rs = 0;
                if (checkMovieDirectorExist(id))
                {
                    string sql = "DELETE [dbo].[MOVIE_DIRECTOR] where MID = @id";
                    SqlParameter sqlParameters = new SqlParameter("@id", SqlDbType.Int);
                    sqlParameters.Value = id;
                    rs = DBContext.ExecuteSQL(sql, sqlParameters);
                }
                else
                {
                    rs = 1;
                }
                return rs;
            }
            catch (Exception e) { throw; }
        }

        public async Task<bool> EditMovie(int id, ArrayList list, IFormFile img, IFormFile bigImg)
        {
            bool check = false;
            try
            {
                if (img != null && bigImg != null)
                {
                    string sqlFull = "UPDATE dbo.MOVIES SET " +
                                     " SID = @sid, " +
                                     " Title = @title, " +
                                     " Description = @desc, " +
                                     " Total_Episode = @ttEsp, " +
                                     " Nationality = @nation, " +
                                     " Languages = @lang, " +
                                     " Release = @release, " +
                                     " Movie_IMG = @img, " +
                                     " BG_IMG = @bigImg, " +
                                     " Trailer = @trailer, " +
                                     " Lenght = @length, " +
                                     " DateADD = GETDATE() " +
                                     $" WHERE MID = '{id}';";

                    byte[] IMG;
                    byte[] BigIMG;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        await img.CopyToAsync(ms);
                        IMG = ms.ToArray();
                    }
                    using (MemoryStream ms = new MemoryStream())
                    {
                        await bigImg.CopyToAsync(ms);
                        BigIMG = ms.ToArray();
                    }

                    SqlParameter[] parameters1 = new SqlParameter[]
                    {
                    new SqlParameter("@sid", SqlDbType.Int),
                    new SqlParameter("@title", SqlDbType.NVarChar),
                    new SqlParameter("@desc", SqlDbType.NVarChar),
                    new SqlParameter("@ttEsp", SqlDbType.Int),
                    new SqlParameter("@nation", SqlDbType.NVarChar),
                    new SqlParameter("@lang", SqlDbType.NVarChar),
                    new SqlParameter("@release", SqlDbType.Int),
                    new SqlParameter("@trailer", SqlDbType.NVarChar),
                    new SqlParameter("@length", SqlDbType.Int),
                    new SqlParameter("@img", SqlDbType.VarBinary),
                    new SqlParameter("@bigImg", SqlDbType.VarBinary),
                    };
                    for (int i = 0; i < list.Count; i++)
                    {
                        parameters1[i].Value = list[i];
                    }

                    parameters1[9].Value = IMG;
                    parameters1[10].Value = BigIMG;
                    int rs = DBContext.ExecuteSQL(sqlFull, parameters1);
                    if (rs > 0)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }
                }
                if (img == null && bigImg == null)
                {
                    string sqlNoIMG = "UPDATE dbo.MOVIES SET " +
                                      " SID = @sid, " +
                                      " Title = @title, " +
                                      " Description = @desc, " +
                                      " Total_Episode = @ttEsp, " +
                                      " Nationality = @nation, " +
                                      " Languages = @lang, " +
                                      " Release = @release, " +
                                      " Trailer = @trailer, " +
                                      " Lenght = @length, " +
                                      " DateADD = GETDATE() " +
                                      $" WHERE MID = '{id}';"; ;
                    SqlParameter[] parameters2 = new SqlParameter[]
                    {
                    new SqlParameter("@sid", SqlDbType.Int),
                    new SqlParameter("@title", SqlDbType.NVarChar),
                    new SqlParameter("@desc", SqlDbType.NVarChar),
                    new SqlParameter("@ttEsp", SqlDbType.Int),
                    new SqlParameter("@nation", SqlDbType.NVarChar),
                    new SqlParameter("@lang", SqlDbType.NVarChar),
                    new SqlParameter("@release", SqlDbType.Int),
                    new SqlParameter("@trailer", SqlDbType.NVarChar),
                    new SqlParameter("@length", SqlDbType.Int),
                    };
                    for (int i = 0; i < list.Count; i++)
                    {
                        parameters2[i].Value = list[i];
                    }

                    int rs = DBContext.ExecuteSQL(sqlNoIMG, parameters2);
                    if (rs > 0)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }
                }
                if (img != null && bigImg == null)
                {
                    string sql = "UPDATE dbo.MOVIES SET " +
                                    " SID = @sid, " +
                                    " Title = @title, " +
                                    " Description = @desc, " +
                                    " Total_Episode = @ttEsp, " +
                                    " Nationality = @nation, " +
                                    " Languages = @lang, " +
                                    " Release = @release, " +
                                    " Movie_IMG = @img, " +
                                    " Trailer = @trailer, " +
                                    " Lenght = @length, " +
                                    " DateADD = GETDATE() " +
                                    $" WHERE MID = '{id}';";

                    byte[] IMG;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        await img.CopyToAsync(ms);
                        IMG = ms.ToArray();
                    }

                    SqlParameter[] parameters3 = new SqlParameter[]
                    {
                    new SqlParameter("@sid", SqlDbType.Int),
                    new SqlParameter("@title", SqlDbType.NVarChar),
                    new SqlParameter("@desc", SqlDbType.NVarChar),
                    new SqlParameter("@ttEsp", SqlDbType.Int),
                    new SqlParameter("@nation", SqlDbType.NVarChar),
                    new SqlParameter("@lang", SqlDbType.NVarChar),
                    new SqlParameter("@release", SqlDbType.Int),
                    new SqlParameter("@trailer", SqlDbType.NVarChar),
                    new SqlParameter("@length", SqlDbType.Int),
                    new SqlParameter("@img", SqlDbType.VarBinary),
                    };
                    for (int i = 0; i < list.Count; i++)
                    {
                        parameters3[i].Value = list[i];
                    }

                    parameters3[9].Value = IMG;
                    int rs = DBContext.ExecuteSQL(sql, parameters3);
                    if (rs > 0)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }
                }
                if (img == null && bigImg != null)
                {
                    string sql = "UPDATE dbo.MOVIES SET " +
                                     " SID = @sid, " +
                                     " Title = @title, " +
                                     " Description = @desc, " +
                                     " Total_Episode = @ttEsp, " +
                                     " Nationality = @nation, " +
                                     " Languages = @lang, " +
                                     " Release = @release, " +
                                     " Movie_IMG = @img, " +
                                     " BG_IMG = @bigImg, " +
                                     " Trailer = @trailer, " +
                                     " Lenght = @length, " +
                                     " DateADD = GETDATE() " +
                                     $" WHERE MID = '{id}';";

                    byte[] BigIMG;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        await bigImg.CopyToAsync(ms);
                        BigIMG = ms.ToArray();
                    }

                    SqlParameter[] parameters4 = new SqlParameter[]
                    {
                    new SqlParameter("@sid", SqlDbType.Int),
                    new SqlParameter("@title", SqlDbType.NVarChar),
                    new SqlParameter("@desc", SqlDbType.NVarChar),
                    new SqlParameter("@ttEsp", SqlDbType.Int),
                    new SqlParameter("@nation", SqlDbType.NVarChar),
                    new SqlParameter("@lang", SqlDbType.NVarChar),
                    new SqlParameter("@release", SqlDbType.Int),
                    new SqlParameter("@trailer", SqlDbType.NVarChar),
                    new SqlParameter("@length", SqlDbType.Int),
                    new SqlParameter("@img", SqlDbType.VarBinary),
                    };
                    for (int i = 0; i < list.Count; i++)
                    {
                        parameters4[i].Value = list[i];
                    }

                    parameters4[9].Value = BigIMG;
                    int rs = DBContext.ExecuteSQL(sql, parameters4);
                    if (rs > 0)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                check = false;
            }

            return check;
        }

        public int AddMovie_Director(ArrayList arrayList)
        {
            string sql = "Insert into MOVIE_DIRECTOR Values (@mid, @did)";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@mid", SqlDbType.Int),
                new SqlParameter("@did", SqlDbType.Int)
            };
            for (int i = 0; i < arrayList.Count; i++)
            {
                sqlParameters[i].Value = arrayList[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);

        }
        public bool CheckMovie_DirectorAlreadyExisted(int mid, int did)
        {
            string sql = "select * from MOVIE_DIRECTOR where DID = '" + did + "' AND MID = '" + mid + "'";
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
    }
}
