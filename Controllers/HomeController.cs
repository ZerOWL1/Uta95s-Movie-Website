using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;

namespace Uta95s_Movie_Web___BETA_0._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ActorDAO actDAO = new ActorDAO();
        private MoviesDAO mDAO = new MoviesDAO();
        private GenreDAO gDAO = new GenreDAO();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> FormTask(MBinary movie, IFormFile Img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                await Img.CopyToAsync(ms);
                movie.MIMGByte = ms.ToArray();
            }
            ArrayList mvList = new ArrayList();
            mvList.Add(movie);
            return View("Home");
        }


        private ArrayList MoviesRandom6()
        {
            DataTable mvTable = mDAO.GetRandom6Movies();
            ArrayList listMoviesRandom6 = new ArrayList();

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
                //m.Img = base64img;

                //Background image
                byte[] bytesBGImg = (byte[])mvTable.Rows[count]["BG_IMG"];
                string base64BGimg = Convert.ToBase64String(bytesBGImg, 0, bytesBGImg.Length);


                string trailer = mvTable.Rows[count]["Trailer"].ToString();
                int length = int.Parse(mvTable.Rows[count]["Lenght"].ToString());
                int view = int.Parse(mvTable.Rows[count]["View"].ToString());
                DateTime date = DateTime.Parse(mvTable.Rows[count]["DateADD"].ToString());

                MBase64 m = new MBase64(id, title, des, totalEsp, national, language, release,
                    trailer, length, view, date, base64img, base64BGimg);
                listMoviesRandom6.Add(m);
                count++;
            }
            return listMoviesRandom6;

        }

        private ArrayList MoviesLatestUpdate()
        {
            DataTable mvTable = mDAO.Get7MoviesLatest();
            ArrayList listMoviesLatestUpdate = new ArrayList();

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
                //m.Img = base64img; 

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
            return listMoviesLatestUpdate;

        }

        private ArrayList DramaMovies()
        {
            DataTable mvTable = mDAO.GetDramaMovies();
            ArrayList listDramaMovies = new ArrayList();

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
                //m.Img = base64img; 

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

            return listDramaMovies;

        }

        private MBase64 GetTop1()
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
                //m.Img = base64img; 

                //Background image
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

        private ArrayList Genre()
        {
            DataTable mvTable = gDAO.GetALLGenre();
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



        [Route("/home", Name = "home")]
        public IActionResult Home()
        {
            
            //List<Actor> list = actDAO.GetDirectors();

            ArrayList listMoviesRandom6 = MoviesRandom6();
            ViewBag.Movies6 = listMoviesRandom6;

            ArrayList listMoviesLatestUpdate = MoviesLatestUpdate();
            ViewBag.MoviesLatestUpdate = listMoviesLatestUpdate;

            ArrayList listDramaMovies = DramaMovies();
            ViewBag.MoviesDramaMovies = listDramaMovies;

            ArrayList listGenre = Genre();
            ViewBag.Genre = listGenre;

            MBase64 m64 = GetTop1();
            ViewBag.m64 = m64;
            return View(m64);
        }

        [Route("/mail", Name = "mail")]
        public IActionResult Mail()
        {
            return View();
        }

        [Route("/code", Name = "code")]
        public IActionResult RandomCode()
        {
            return View();
        }


        [Route("/details", Name = "details")]
        public IActionResult Details()
        {
            return View();
        }

    }
}
