using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Control
{
    public class MovieControl
    {
        private static MoviesDAO mDAO = new MoviesDAO();
        private string status = string.Empty;

        //Random 6 to slider
        public ArrayList MoviesRandom6()
        {
            ArrayList listMoviesRandom6 = new ArrayList();
            try
            {
                DataTable mvTable = mDAO.GetRandom6Movies();
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

                    MBase64 m = new MBase64(id, title, des, totalEsp, national, language, release, trailer, length, view,
                        date, base64img, base64BGIMG);

                    listMoviesRandom6.Add(m);
                    count++;
                }
            }
            catch (Exception e)
            {
                status = "Error at function MoviesRandom6 " + e.Message;
            }
            return listMoviesRandom6;
        }

        //Lastest 7 to slider
        public ArrayList MoviesLatestUpdate()
        {
            ArrayList listMoviesLatestUpdate = new ArrayList();

            try
            {
                DataTable mvTable = mDAO.Get7MoviesLatest();
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

                    //Background image
                    byte[] bytesBGImg = (byte[])mvTable.Rows[count]["BG_IMG"];
                    string base64BGimg = Convert.ToBase64String(bytesBGImg, 0, bytesBGImg.Length);

                    string trailer = mvTable.Rows[count]["Trailer"].ToString();
                    int length = int.Parse(mvTable.Rows[count]["Lenght"].ToString());
                    int view = int.Parse(mvTable.Rows[count]["View"].ToString());
                    DateTime date = DateTime.Parse(mvTable.Rows[count]["DateADD"].ToString());

                    MBase64 m = new MBase64(id, title, des, totalEsp, national, language, release,
                        trailer, length, view, date, base64img, base64BGimg);
                    listMoviesLatestUpdate.Add(m);

                    count++;
                }
            }
            catch (Exception e)
            {
                status = "Error at function MoviesLatestUpdate " + e.Message;
            }
            return listMoviesLatestUpdate;
        }

        //Get Drama Movie
        public ArrayList DramaMovies()
        {
            ArrayList listDramaMovies = new ArrayList();
            try
            {
                DataTable mvTable = mDAO.GetDramaMovies();
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

                    //Background image
                    byte[] bytesBGImg = (byte[])mvTable.Rows[count]["BG_IMG"];
                    string base64BGimg = Convert.ToBase64String(bytesBGImg, 0, bytesBGImg.Length);

                    string trailer = mvTable.Rows[count]["Trailer"].ToString();
                    int length = int.Parse(mvTable.Rows[count]["Lenght"].ToString());
                    int view = int.Parse(mvTable.Rows[count]["View"].ToString());
                    DateTime date = DateTime.Parse(mvTable.Rows[count]["DateADD"].ToString());

                    MBase64 m = new MBase64(id, title, des, totalEsp, national, language, release,
                        trailer, length, view, date, base64img, base64BGimg);
                    listDramaMovies.Add(m);

                    count++;
                }
            }
            catch (Exception e)
            {
                status = "Error at function DramaMovies " + e.Message;
            }
            return listDramaMovies;

        }

        //Get Top1 to BigIMG
        public MBase64 GetTop1()
        {
            try
            {
                MBase64 m = new MBase64();
                DataTable GetTop1 = mDAO.GetTop1();
                int count = 0;

                int id = int.Parse(GetTop1.Rows[count]["MID"].ToString());
                string title = GetTop1.Rows[count]["Title"].ToString();
                string des = GetTop1.Rows[count]["Description"].ToString();
                int totalEsp = int.Parse(GetTop1.Rows[count]["Total_Episode"].ToString());
                string national = GetTop1.Rows[count]["Nationality"].ToString();
                string language = GetTop1.Rows[count]["Languages"].ToString();
                string release = GetTop1.Rows[count]["Release"].ToString();

                //img
                byte[] bytesImg = (byte[])GetTop1.Rows[count]["Movie_IMG"];
                string base64img = Convert.ToBase64String(bytesImg, 0, bytesImg.Length);

                //background image
                byte[] bytesBGImg = (byte[])GetTop1.Rows[count]["BG_IMG"];
                string base64BGimg = Convert.ToBase64String(bytesBGImg, 0, bytesBGImg.Length);

                string trailer = GetTop1.Rows[count]["Trailer"].ToString();
                int length = int.Parse(GetTop1.Rows[count]["Lenght"].ToString());
                int view = int.Parse(GetTop1.Rows[count]["View"].ToString());
                DateTime date = DateTime.Parse(GetTop1.Rows[count]["DateADD"].ToString());

                m = new MBase64(id, title, des, totalEsp, national, language, release,
                    trailer, length, view, date, base64img, base64BGimg);
                return m;
            }
            catch (Exception e)
            {
                status = "Error at function GetTop1 " + e.Message;
                return null;
            }
        }
    }
}
