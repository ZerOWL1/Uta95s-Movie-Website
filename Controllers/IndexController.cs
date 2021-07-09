using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Uta95s_Movie_Web___BETA_0._1.Controllers
{
    public class IndexController : Controller
    {
        [Route("", Name = "default")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
