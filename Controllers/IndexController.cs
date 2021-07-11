using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uta95s_Movie_Web___BETA_0._1.Models.Control;
using Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO;

namespace Uta95s_Movie_Web___BETA_0._1.Controllers
{
    public class IndexController : Controller
    {
        private MovieControl mControl;
        private string status = string.Empty;
        public IndexController()
        {
            mControl = new MovieControl();
        }

        [Route("", Name = "default")]
        public IActionResult Index()
        {
            try
            {
                ArrayList slider = mControl.IndexSliderImages();
                ViewBag.IndexSlider = slider;

                ArrayList randomSlider = mControl.IndexSliderRandomImages();
                ViewBag.IndexRandomSlider = randomSlider;
            }
            catch (Exception e)
            {
                status = "Error";
                throw;
            }
            return View();
        }
    }
}
