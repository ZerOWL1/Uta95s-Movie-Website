using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Control
{
    public class MovieControl
    {
        private static MoviesDAO mDAO = new MoviesDAO();
        private EpisodeDAO eDAO = new EpisodeDAO();
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
                    string mStatus = mvTable.Rows[count]["saName"].ToString();
                    MStatus m = new MStatus(id, title, des, totalEsp, national, language, release, trailer, length, view,
                        date, base64img, base64BGIMG, mStatus);

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

        //Latest 7 to slider
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
                    string statusMovie = mvTable.Rows[count]["SaName"].ToString();


                    MStatus mStatus = new MStatus(id, title, des, totalEsp, national, language, release, trailer, length, view, date, base64img, base64BGimg, statusMovie);
                    listMoviesLatestUpdate.Add(mStatus);
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
                    string mStatus = mvTable.Rows[count]["SaName"].ToString();
                    MStatus m = new MStatus(id, title, des, totalEsp, national, language, release,
                        trailer, length, view, date, base64img, base64BGimg, mStatus);
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
        public MBase64 GetRandom1Movie()
        {
            try
            {
                MBase64 m = new MBase64();
                DataTable GetTop1 = mDAO.GetRandomTop1();
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

        //index slider img
        public ArrayList IndexSliderImages()
        {
            ArrayList listImg = new ArrayList();
            try
            {
                DataTable mvTable = mDAO.GetALLMovies();

                int count = 0;

                foreach (var item in mvTable.Rows)
                {
                    byte[] bytesImg = (byte[]) mvTable.Rows[count]["Movie_IMG"];
                    string base64img = Convert.ToBase64String(bytesImg, 0, bytesImg.Length);
                    listImg.Add(base64img);
                    count++;
                }
            }
            catch (Exception e)
            {
                status = "Error at function IndexSliderImages " + e.Message;
            }
            return listImg;
        }

        //index slider random img
        public ArrayList IndexSliderRandomImages()
        {
            ArrayList listRandom = new ArrayList();
            try
            {
                DataTable mvTable = mDAO.GetRandom6Movies();

                int count = 0;

                foreach (var item in mvTable.Rows)
                {
                    byte[] bytesImg = (byte[]) mvTable.Rows[count]["Movie_IMG"];
                    string base64img = Convert.ToBase64String(bytesImg, 0, bytesImg.Length);
                    listRandom.Add(base64img);
                    count++;
                }
            }
            catch (Exception e)
            {
                status = "Error at function IndexSliderImages " + e.Message;
            }
            return listRandom;
        }

        //get movie episode by movie id
        public ArrayList GetMovieEpisodeById(int id)
        {
            ArrayList listEpisodeMovie = new ArrayList();
            try
            {
                DataTable EpMovie = eDAO.GetMovieEpisodeById(id);
                int count = 0;
                foreach (var item in EpMovie.Rows)
                {
                    int mid = int.Parse(EpMovie.Rows[count]["MID"].ToString());
                    int episode = int.Parse(EpMovie.Rows[count]["Episode"].ToString());
                    string title = EpMovie.Rows[count]["Title"].ToString();
                    string ep_link = EpMovie.Rows[count]["Episode_Link"].ToString();
                    Episode me = new Episode(mid,episode,title,ep_link);
                    listEpisodeMovie.Add(me);
                    count++;
                }
            }
            catch (Exception e)
            {
                status = "Error at function IndexSliderImages " + e.Message;
            }
            return listEpisodeMovie;
        }

        //get 4 latest movie
        public ArrayList Get4MoviesLatest()
        {
            ArrayList list4LatestUpdate = new ArrayList();

            try
            {
                DataTable mvTable = eDAO.Get4MoviesLatest();
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
                    string statusMovie = mvTable.Rows[count]["SaName"].ToString();


                    MStatus mStatus = new MStatus(id, title, des, totalEsp, national, language, release, trailer, length, view, date, base64img, base64BGimg, statusMovie);
                    list4LatestUpdate.Add(mStatus);
                    count++;
                }
            }
            catch (Exception e)
            {
                status = "Error at function MoviesLatestUpdate " + e.Message;
            }
            return list4LatestUpdate;
        }

        //get episode by movie id and movie episode
        public Episode GetEpisode(int id, int epi)
        {
            try
            {
                DataTable EpMovie = eDAO.GetEpisode(id,epi);
                int count = 0;
                int mid = int.Parse(EpMovie.Rows[count]["MID"].ToString());
                int episode = int.Parse(EpMovie.Rows[count]["Episode"].ToString());
                string title = EpMovie.Rows[count]["Title"].ToString();
                string ep_link = EpMovie.Rows[count]["Episode_Link"].ToString();
                Episode ep = new Episode(mid, episode, title, ep_link);
                return ep;
            }
            catch (Exception e)
            {
                status = "Error at function IndexSliderImages " + e.Message;
                return null;
            }
        }

        //get list movies
        public ArrayList GetAllMovie()
        {
            ArrayList listMovies= new ArrayList();
            try
            {
                DataTable mvTable = mDAO.getMovieInfo();
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
                    MStatus m = new MStatus(id, title, des, totalEsp, national, language, release, trailer, length, view,
                        date, base64img, base64BGIMG, mStatus);

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
    }
}
