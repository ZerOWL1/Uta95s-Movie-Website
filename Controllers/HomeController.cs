using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private IndexController indexControl;
        private UserDAO userDAO;

        private string status = string.Empty;
        public HomeController(ILogger<HomeController> logger)
        {
            userDAO = new UserDAO();
            indexControl = new IndexController();
            _logger = logger;
        }


        [Route("/home", Name = "home")]
        public IActionResult Home()
        {
            User user = new User();

            try
            {
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }

                MovieControl movieControl = new MovieControl();
                ArrayList listMoviesRandom6 = movieControl.MoviesRandom6();
                ViewBag.Movies6 = listMoviesRandom6;

                ArrayList listMoviesLatestUpdate = movieControl.MoviesLatestUpdate();
                ViewBag.MoviesLatestUpdate = listMoviesLatestUpdate;

                ArrayList listDramaMovies = movieControl.DramaMovies();
                ViewBag.MoviesDramaMovies = listDramaMovies;

                ArrayList listGenre = GenreControl.Genre();
                ViewBag.Genre = listGenre;

                MBase64 m64 = movieControl.GetRandom1Movie();
                return View(m64);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Your password not match!!");
                return RedirectToAction("Index", "Index");
            }
        }

        [Route("/mail", Name = "mail")]
        public IActionResult Mail()
        {
            return View();
        }

        [Route("/code", Name = "code")]
        public IActionResult RandomCode(Mail mail)
        {
            return View(mail);
        }

        [Route("/verifyCode", Name = "verifyCode")]
        public IActionResult VerifyCode()
        {
            Mail mail = new Mail();
            User user = new User();

            try
            {
                string inputCode = Request.Form["randomCode"].ToString();
                if (HttpContext.Session.GetString("signup") != null)
                {
                    //get session
                    mail = JsonConvert.DeserializeObject<Mail>(HttpContext.Session.GetString("signup"));
                    if (inputCode == mail.ReCode)
                    {
                        userDAO.SignUp(mail.Name, mail.ToMail, mail.Pass);
                        ModelState.AddModelError("", "Sign-up Success!!");
                        return RedirectToAction("Index", "Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Code Input!!");
                        return RedirectToAction("Index", "Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Session Error!!");
                    return RedirectToAction("Index", "Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToAction("Index", "Index");
            }
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


        [Route("/profiles", Name = "profile")]
        public IActionResult Profile()
        {
            return View();
        }

        [Route("/logout", Name = "logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Index");
        }
    }
}
