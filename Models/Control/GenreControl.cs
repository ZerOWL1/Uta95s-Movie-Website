using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Database;
using Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Control
{
    public class GenreControl
    {
        private static GenreDAO gDao = new GenreDAO();
        private static string status = string.Empty;

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

        //get movie by genre id
        public static ArrayList GetMovieByGenre(int genreid, int page)
        {
            ArrayList listMovies = new ArrayList();
            try
            {
                DataTable mvTable = gDao.GetMovieByGenre(genreid, page);
                int count = 0;

                foreach (var item in mvTable.Rows)
                {
                    int id = int.Parse(mvTable.Rows[count]["MID"].ToString());
                    string title = mvTable.Rows[count]["Title"].ToString();
                    string des = mvTable.Rows[count]["Description"].ToString();
                    int totalEsp = int.Parse(mvTable.Rows[count]["Total_Episode"].ToString());
                    string national = mvTable.Rows[count]["Nationality"].ToString();
                    string language = mvTable.Rows[count]["Languages"].ToString();
                    string release = mvTable.Rows[count]["Release"].ToString();

                    //img
                    byte[] bytesImg = (byte[])mvTable.Rows[count]["Movie_IMG"];
                    string base64img = Convert.ToBase64String(bytesImg, 0, bytesImg.Length);

                    //background image
                    byte[] bytesBGImg = (byte[])mvTable.Rows[count]["BG_IMG"];
                    string base64BGIMG = Convert.ToBase64String(bytesBGImg, 0, bytesBGImg.Length);

                    string trailer = mvTable.Rows[count]["Trailer"].ToString();
                    int length = int.Parse(mvTable.Rows[count]["Lenght"].ToString());
                    int view = int.Parse(mvTable.Rows[count]["View"].ToString());
                    DateTime date = DateTime.Parse(mvTable.Rows[count]["DateADD"].ToString());
                    string mStatus = mvTable.Rows[count]["saName"].ToString();
                    int gid = int.Parse(mvTable.Rows[count]["GID"].ToString());
                    string gname = mvTable.Rows[count]["GName"].ToString();
                    MGenre m = new MGenre(id, title, des, totalEsp, national, language, release, trailer, length, view,
                        date, base64img, base64BGIMG, mStatus, gid, gname);

                    listMovies.Add(m);
                    count++;
                }
            }
            catch (Exception e)
            {
                status = "Error at function MoviesRandom6 " + e.Message;
            }
            return listMovies;
        }

        //get name genre
        public static MGenre GetNameGenre(int genreid)
        {
            try
            {
                DataTable mvTable = gDao.GetNameGenre(genreid);
                int count = 0;

                int id = int.Parse(mvTable.Rows[count]["MID"].ToString());
                string title = mvTable.Rows[count]["Title"].ToString();
                string des = mvTable.Rows[count]["Description"].ToString();
                int totalEsp = int.Parse(mvTable.Rows[count]["Total_Episode"].ToString());
                string national = mvTable.Rows[count]["Nationality"].ToString();
                string language = mvTable.Rows[count]["Languages"].ToString();
                string release = mvTable.Rows[count]["Release"].ToString();

                //img
                byte[] bytesImg = (byte[])mvTable.Rows[count]["Movie_IMG"];
                string base64img = Convert.ToBase64String(bytesImg, 0, bytesImg.Length);

                //background image
                byte[] bytesBGImg = (byte[])mvTable.Rows[count]["BG_IMG"];
                string base64BGIMG = Convert.ToBase64String(bytesBGImg, 0, bytesBGImg.Length);

                string trailer = mvTable.Rows[count]["Trailer"].ToString();
                int length = int.Parse(mvTable.Rows[count]["Lenght"].ToString());
                int view = int.Parse(mvTable.Rows[count]["View"].ToString());
                DateTime date = DateTime.Parse(mvTable.Rows[count]["DateADD"].ToString());
                string mStatus = mvTable.Rows[count]["saName"].ToString();
                int gid = int.Parse(mvTable.Rows[count]["GID"].ToString());
                string gname = mvTable.Rows[count]["GName"].ToString();
                MGenre m = new MGenre(id, title, des, totalEsp, national, language, release, trailer, length, view,
                    date, base64img, base64BGIMG, mStatus, gid, gname);
                return m;
            }
            catch (Exception e)
            {
                status = "Error at function MoviesRandom6 " + e.Message;
                return null;
            }

        }

        //get total movie
        public static int GetNumberMovie(int gid)
        {
            try
            {
                string sql = "SELECT * FROM MOVIE_GENRE WHERE GID = " + gid;
                DataTable data = DBContext.GetDataBySQL(sql);
                int total = data.Rows.Count;
                return total;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        //search by text
        public static ArrayList getMovieBySearch(string text, int page)
        {
            ArrayList listMovieSearch = new ArrayList();
            try
            {
                int count = 0;
                DataTable mvTable = gDao.GetMovieBySearch(text, page);
                foreach (var item in mvTable.Rows)
                {

                    int mid = int.Parse(mvTable.Rows[count]["MID"].ToString());
                    string title = mvTable.Rows[count]["Title"].ToString();
                    string des = mvTable.Rows[count]["Description"].ToString();
                    int totalEsp = int.Parse(mvTable.Rows[count]["Total_Episode"].ToString());
                    string national = mvTable.Rows[count]["Nationality"].ToString();
                    string language = mvTable.Rows[count]["Languages"].ToString();
                    string release = mvTable.Rows[count]["Release"].ToString();

                    //img
                    byte[] bytesImg = (byte[])mvTable.Rows[count]["Movie_IMG"];
                    string base64img = Convert.ToBase64String(bytesImg, 0, bytesImg.Length);

                    //background image
                    byte[] bytesBGImg = (byte[])mvTable.Rows[count]["BG_IMG"];
                    string base64BGimg = Convert.ToBase64String(bytesBGImg, 0, bytesBGImg.Length);

                    string trailer = mvTable.Rows[count]["Trailer"].ToString();
                    int length = int.Parse(mvTable.Rows[count]["Lenght"].ToString());
                    int view = int.Parse(mvTable.Rows[count]["View"].ToString());
                    DateTime date = DateTime.Parse(mvTable.Rows[count]["DateADD"].ToString());
                    string download = mvTable.Rows[count]["Download"].ToString();
                    int actorID = int.Parse(mvTable.Rows[count]["AID"].ToString());
                    string actorName = mvTable.Rows[count]["AcName"].ToString();
                    string actorWiki = mvTable.Rows[count]["AcWiki"].ToString();
                    int did = int.Parse(mvTable.Rows[count]["DID"].ToString());
                    string dName = mvTable.Rows[count]["DiName"].ToString();
                    string dNational = mvTable.Rows[count]["DiNationality"].ToString();

                    MBase64_MAD mad = new MBase64_MAD(mid, title, des, totalEsp, national, language, release, trailer,
                         length, view, date, download, actorID, actorName,
                         actorWiki, did, dName, dNational, base64img, base64BGimg);

                    listMovieSearch.Add(mad);
                    count++;
                }
            }
            catch (Exception e)
            {
                status = "Error at function GetMovieById " + e.Message;
            }
            return listMovieSearch;
        }

        //get number search
        public static int GetNumberSearch(string text)
        {
            ArrayList listMovieSearch = new ArrayList();
            try
            {
                int count = 0;
                DataTable mvTable = gDao.GetNumberSearch(text);
                foreach (var item in mvTable.Rows)
                {

                    int mid = int.Parse(mvTable.Rows[count]["MID"].ToString());
                    string title = mvTable.Rows[count]["Title"].ToString();
                    string des = mvTable.Rows[count]["Description"].ToString();
                    int totalEsp = int.Parse(mvTable.Rows[count]["Total_Episode"].ToString());
                    string national = mvTable.Rows[count]["Nationality"].ToString();
                    string language = mvTable.Rows[count]["Languages"].ToString();
                    string release = mvTable.Rows[count]["Release"].ToString();

                    //img
                    byte[] bytesImg = (byte[])mvTable.Rows[count]["Movie_IMG"];
                    string base64img = Convert.ToBase64String(bytesImg, 0, bytesImg.Length);

                    //background image
                    byte[] bytesBGImg = (byte[])mvTable.Rows[count]["BG_IMG"];
                    string base64BGimg = Convert.ToBase64String(bytesBGImg, 0, bytesBGImg.Length);

                    string trailer = mvTable.Rows[count]["Trailer"].ToString();
                    int length = int.Parse(mvTable.Rows[count]["Lenght"].ToString());
                    int view = int.Parse(mvTable.Rows[count]["View"].ToString());
                    DateTime date = DateTime.Parse(mvTable.Rows[count]["DateADD"].ToString());
                    string download = mvTable.Rows[count]["Download"].ToString();
                    int actorID = int.Parse(mvTable.Rows[count]["AID"].ToString());
                    string actorName = mvTable.Rows[count]["AcName"].ToString();
                    string actorWiki = mvTable.Rows[count]["AcWiki"].ToString();
                    int did = int.Parse(mvTable.Rows[count]["DID"].ToString());
                    string dName = mvTable.Rows[count]["DiName"].ToString();
                    string dNational = mvTable.Rows[count]["DiNationality"].ToString();

                    MBase64_MAD mad = new MBase64_MAD(mid, title, des, totalEsp, national, language, release, trailer,
                         length, view, date, download, actorID, actorName,
                         actorWiki, did, dName, dNational, base64img, base64BGimg);

                    listMovieSearch.Add(mad);
                    count++;
                }
            }
            catch (Exception e)
            {
                status = "Error at function GetMovieById " + e.Message;
            }
            return listMovieSearch.Count;

        }
    }
}
