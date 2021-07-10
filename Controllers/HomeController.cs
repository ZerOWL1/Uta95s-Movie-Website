using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Uta95s_Movie_Web___BETA_0._1.Models.Control;
using Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/home", Name = "home")]
        public IActionResult Home()
        {
            try
            {
                MovieControl movieControl = new MovieControl();
                ArrayList listMoviesRandom6 = movieControl.MoviesRandom6();
                ViewBag.Movies6 = listMoviesRandom6;

                ArrayList listMoviesLatestUpdate = movieControl.MoviesLatestUpdate();
                ViewBag.MoviesLatestUpdate = listMoviesLatestUpdate;

                ArrayList listDramaMovies = movieControl.DramaMovies();
                ViewBag.MoviesDramaMovies = listDramaMovies;

                ArrayList listGenre = GenreControl.Genre();
                ViewBag.Genre = listGenre;

                MBase64 m64 = movieControl.GetTop1();
                ViewBag.m64 = m64;
            }
            catch (Exception e)
            {
                return RedirectToPage("Home.cshtml");
            }
            return View();
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


        [Route("/films", Name = "films")]
        public IActionResult Movies()
        {
            return View();
        }
    }
}
