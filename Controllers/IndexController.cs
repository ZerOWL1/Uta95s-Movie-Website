using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Controllers
{
    public class IndexController : Controller
    {
        private readonly ILogger<IndexController> _logger;
        private MoviesDAO mDAO = new MoviesDAO();

        public IndexController(ILogger<IndexController> logger)
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
            return View("Index");
        }

        private ArrayList Images()
        {
            DataTable mvTable = mDAO.GetALLMovies();
            ArrayList listImg = new ArrayList();

            int count = 0;

            foreach (var item in mvTable.Rows)
            {
                byte[] bytesImg = (byte[])mvTable.Rows[count]["Movie_IMG"];
                string base64img = Convert.ToBase64String(bytesImg, 0, bytesImg.Length);
                listImg.Add(base64img);
                count++;
            }
            return listImg;

        }

        private ArrayList RandomImages()
        {
            DataTable mvTable = mDAO.GetRandomMovies();
            ArrayList listRandom = new ArrayList();

            int count = 0;

            foreach (var item in mvTable.Rows)
            {
                byte[] bytesImg = (byte[])mvTable.Rows[count]["Movie_IMG"];
                string base64img = Convert.ToBase64String(bytesImg, 0, bytesImg.Length);
                listRandom.Add(base64img);
                count++;
            }
            return listRandom;

        }

        [Route("", Name = "default")]
        public IActionResult Index()
        {
            ArrayList listImg = Images();
            ViewBag.Base64Image = listImg;

            ArrayList listRandom = RandomImages();
            ViewBag.Base64Image2 = listRandom;
            return View();
        }

        
    }
}
