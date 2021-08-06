using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Uta95s_Movie_Web___BETA_0._1.Models.Control;
using Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Controllers
{
    public class ManagerController : Controller
    {
        private UserDAO uDAO;
        private MoviesDAO mDAO;
        private EpisodeDAO eDAO;
        private ActorDAO aDAO;
        private DirectorDAO dDAO;
        private GenreDAO gDAO;
        private MovieControl mControl;
        private StatusDAO sDAO;
        private string msg = String.Empty;

        public ManagerController()
        {
            sDAO = new StatusDAO();
            gDAO = new GenreDAO();
            dDAO = new DirectorDAO();
            aDAO = new ActorDAO();
            eDAO = new EpisodeDAO();
            mDAO = new MoviesDAO();
            uDAO = new UserDAO();
            mControl = new MovieControl();
        }

        //manager
        [Route("/manager", Name = "manager")]
        public IActionResult Manager()
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }
                ViewBag.countuser = uDAO.CountUser();
                ViewBag.countmovie = mDAO.CountMovies();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
            return View();
        }

        //user-manager
        [HttpGet]
        [Route("/user-manager", Name = "UManager")]
        public IActionResult UserManage(string msg)
        {

            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }
                ViewBag.mess = msg;
                ViewBag.userM = uDAO.GetAllUser();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
            return View();
        }

        //movie-manager
        [HttpGet]
        [Route("/movie-manager", Name = "MManager")]
        public IActionResult MovieManage(string msg)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
                ArrayList listMovie = mControl.GetAllMovie();
                ViewBag.movie = listMovie;
                ViewBag.mess = msg;
                ViewBag.listStatus = sDAO.GetAllStatus();
            }
            return View("MovieManage");
        }

        //add movie
        [HttpPost]
        [Route("/movie-manager", Name = "MManager")]
        public async Task<IActionResult> MovieManage(int id, IFormFile MIMGByte, IFormFile MBigImgBytes)
        {
            try
            {
                if (MIMGByte != null && MBigImgBytes != null)
                {
                    UProfileBase64 user = new UProfileBase64();
                    if (HttpContext.Session.GetString("user") != null)
                    {
                        user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                        ViewBag.user = user;
                    }
                    int status = Convert.ToInt32(Request.Form["status"]);
                    string title = Request.Form["title"].ToString();
                    string desc = Request.Form["description"].ToString();
                    int totlaesp = Convert.ToInt32(Request.Form["totalEsp"]);
                    string nationality = Request.Form["nationality"].ToString();
                    string language = Request.Form["language"].ToString();
                    string release = Request.Form["release"].ToString();
                    string trailer = Request.Form["trailer"].ToString();
                    int length = Convert.ToInt32(Request.Form["length"]);
                    DateTime date = Convert.ToDateTime(Request.Form["date"]);

                    ArrayList arrayList = new ArrayList();
                    arrayList.Add(status);
                    arrayList.Add(title);
                    arrayList.Add(desc);
                    arrayList.Add(totlaesp);
                    arrayList.Add(nationality);
                    arrayList.Add(language);
                    arrayList.Add(release);
                    arrayList.Add(trailer);
                    arrayList.Add(length);
                    arrayList.Add(date);

                    await mDAO.AddNewMovie(arrayList, MIMGByte, MBigImgBytes);
                }
                else
                {
                    return RedirectToRoute("MManager");
                }
            }
            catch (Exception e)
            {
                return RedirectToRoute("MManager");
            }
            return RedirectToRoute("MManager");
        }

        //episode-manager
        [HttpGet]
        [Route("/episode-manager", Name = "EManager")]
        public IActionResult EpisodeManage(string msg)
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }
                ViewBag.mess = msg;
                ViewBag.listE = eDAO.GetAllEpisode();
                ViewBag.movies = mDAO.GetAllMovies();
            }
            catch (Exception e)
            {
                return View(e.ToString());
            }
            return View();
        }

        //add episode
        [HttpPost]
        [Route("/episode-manager", Name = "EManager")]
        public IActionResult EpisodeManage(int id)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            int mid_new = Convert.ToInt32(Request.Form["mid_new"]);
            int episode = 0;
            try
            {
                episode = Convert.ToInt32(Request.Form["episode"]);
            }
            catch (Exception)
            {
                episode = -1;
            }
            string etitle = Request.Form["title"].ToString();
            string elink = Request.Form["epiLink"].ToString();
            if (episode < 0 || etitle.Equals("") || elink.Equals(""))
            {
                msg = "Invalid Data";
                return EpisodeManage(msg);
            }
            else
            {
                ArrayList arrayList = new ArrayList();
                arrayList.Add(mid_new);
                arrayList.Add(episode);
                arrayList.Add(etitle);
                arrayList.Add(elink);
                eDAO.AddEpisode(arrayList);
                msg = "Add New Episode Success!!";
                return EpisodeManage(msg);
            }
        }

        //actor manager
        [HttpGet]
        [Route("/actor-manager", Name = "AManager")]
        public IActionResult ActorManage(string msg)
        {

            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
                ViewBag.mess = msg;
            }
            ViewBag.listA = aDAO.GetAllActor();
            return View();
        }

        //add actor
        [HttpPost]
        [Route("/actor-manager", Name = "AManager")]
        public IActionResult ActorManage(int id)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            ActorDAO actorDAO = new ActorDAO();
            string actorname = Request.Form["acName"].ToString();
            string acWiki = Request.Form["acWiki"].ToString();
            if (actorname.Equals("") || acWiki.Equals(""))
            {
                msg = "You've enter blank data!!";
                return ActorManage(msg);
            }
            else
            {
                ArrayList arrayList = new ArrayList();
                arrayList.Add(actorname);
                arrayList.Add(acWiki);
                actorDAO.AddActor(arrayList);
                msg = "Add Actor Success!!";
                return ActorManage(msg);
            }
        }

        //director manager
        [HttpGet]
        [Route("/director-manager", Name = "DManager")]
        public IActionResult DirectorManage(string msg)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }

            ViewBag.mess = msg;
            ViewBag.listD = dDAO.GetAllDirector();
            return View();
        }

        //add director
        [HttpPost]
        [Route("/director-manager", Name = "DManager")]
        public IActionResult DirectorManage(int id)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            DirectorDAO directorDAO = new DirectorDAO();
            string dname = Request.Form["diName"].ToString();
            string dnation = Request.Form["diNation"].ToString();
            if (dname.Equals("") || dnation.Equals(""))
            {
                msg = "You've enter blank director!";
                return DirectorManage(msg);
            }
            else if (directorDAO.CheckDirectorAlreadExisted(dname))
            {
                msg = "This Director Already Exist!!";
                return DirectorManage(msg);
            }
            else
            {
                ArrayList arrayList = new ArrayList();
                arrayList.Add(dname);
                arrayList.Add(dnation);
                directorDAO.AddDirector(arrayList);
                msg = "Add Director Success!!";
                return DirectorManage(msg);
            }
        }

        //genre manager
        [HttpGet]
        [Route("/genre-manager", Name = "GManager")]
        public IActionResult GenreManage(string msg)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }

            ViewBag.mess = msg;
            ViewBag.listG = gDAO.GetAllGenres();
            return View();
        }

        //add new genre
        [HttpPost]
        [Route("/genre-manager", Name = "GManager")]
        public IActionResult GenreManage(int id)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            string gname = Request.Form["genreName"].ToString();
            if (gname.Equals(""))
            {
                msg = "You've enter a blank genre!";
                return GenreManage(msg);
            }
            else if (gDAO.CheckGenreAlreadyExisted(gname))
            {
                msg = "This genre already exist!";
                return GenreManage(msg);
            }
            else
            {
                gDAO.AddGenre(gname);
                msg = "Add Genre Success!!";
                return GenreManage(msg);
            }
        }


        /// <summary>
        /// This one is Edit Control Part
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        //to movie edit page
        [HttpGet]
        [Route("/editM", Name = "EditM")]
        public IActionResult EditMovie(int id)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }

            ViewBag.Status = sDAO.GetAllStatus();
            ViewBag.MovieInfor = mDAO.GetAllMovieInforByID(id);
            return View();
        }

        //edit movie
        [HttpPost]
        [Route("/editM", Name = "EditM")]
        public async Task<IActionResult> EditMovie(IFormFile IMG, IFormFile BigIMG)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                //get session
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            try
            {
                int id = Convert.ToInt32(Request.Form["id"].ToString());
                int sid = Convert.ToInt32(Request.Form["status"].ToString());
                string title = Request.Form["title"].ToString();
                string desc = Request.Form["description"].ToString();
                int totalEsp = Convert.ToInt32(Request.Form["totalEsp"].ToString());
                string nation = Request.Form["nationality"].ToString();
                string language = Request.Form["language"].ToString();
                int release = Convert.ToInt32(Request.Form["release"].ToString());
                string trailer = Request.Form["trailer"].ToString();
                int length = Convert.ToInt32(Request.Form["length"].ToString());

                ArrayList list = new ArrayList()
                {
                    sid,
                    title,
                    desc,
                    totalEsp,
                    nation,
                    language,
                    release,
                    trailer,
                    length
                };

                bool edit = await mDAO.EditMovie(id, list, IMG, BigIMG);
                if (edit)
                {
                    //sent mess
                    msg = "Edit Successful!";
                    return MovieManage(msg);
                }
                else
                {
                    msg = "Edit Fail!";
                    return MovieManage(msg);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return MovieManage(e.ToString());
            }
        }

        //to actor edit page
        [HttpGet]
        [Route("/editA", Name = "EditA")]
        public IActionResult EditActor(int id)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            Actor actor = aDAO.GetActor(id);
            ViewBag.actor = actor;
            return View();
        }

        //edit actor
        [HttpPost]
        [Route("/editA", Name = "EditA")]
        public IActionResult EditActor()
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }
                ActorDAO actorDAO = new ActorDAO();
                int aid = Convert.ToInt32(Request.Form["aid"]);
                string actorname = Request.Form["acName"].ToString();
                string acWiki = Request.Form["acWiki"].ToString();
                if (actorname.Equals("") || acWiki.Equals(""))
                {
                    return RedirectToRoute("AManager");
                }
                else
                {
                    ArrayList arrayList = new ArrayList();
                    arrayList.Add(actorname);
                    arrayList.Add(acWiki);
                    arrayList.Add(aid);
                    actorDAO.UpdateActor(arrayList);
                    return RedirectToRoute("AManager");
                }
            }
            catch (Exception e)
            {
                msg = $"{e.ToString()}";
                return ActorManage(msg);
            }
        }

        //to director page
        [HttpGet]
        [Route("/editD", Name = "EditD")]
        public IActionResult EditDirector(int id)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            DirectorDAO directorDAO = new DirectorDAO();
            Director director = directorDAO.GetDirector(id);
            ViewBag.director = director;
            return View();
        }

        //edit director
        [HttpPost]
        [Route("/editD", Name = "EditD")]
        public IActionResult EditDirector()
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            DirectorDAO directorDAO = new DirectorDAO();
            int did = Convert.ToInt32(Request.Form["did"]);
            string dname = Request.Form["diName"].ToString();
            string dnation = Request.Form["diNation"].ToString();
            if (dname.Equals("") || dnation.Equals(""))
            {
                msg = "You've enter change data to blank";
                return RedirectToRoute("DManager");
            }
            else
            {
                ArrayList arrayList = new ArrayList();
                arrayList.Add(dname);
                arrayList.Add(dnation);
                arrayList.Add(did);
                directorDAO.UpdateDirector(arrayList);
                msg = "Edit Director Success!";
                return RedirectToRoute("DManager");
            }
        }

        //to episode page
        [HttpGet]
        [Route("/editE", Name = "EditE")]
        public IActionResult EditEpisode(int id, int val)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            Episode episode = eDAO.GetEpisodeByMID(id, val);
            List<Movie> movies = mDAO.GetAllMovies();
            ViewBag.episode = episode;
            ViewBag.movies = movies;
            return View();
        }

        //edit episode
        [HttpPost]
        [Route("/editE", Name = "EditE")]
        public IActionResult EditEpisode()
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            EpisodeDAO episodeDAO = new EpisodeDAO();
            int mid_new = Convert.ToInt32(Request.Form["mid_new"]);
            int episode_new = 0;
            try
            {
                episode_new = Convert.ToInt32(Request.Form["episode_new"]);
            }
            catch (Exception)
            {
                episode_new = -1;
            }
            int mid_old = Convert.ToInt32(Request.Form["mid_old"]);
            int episode_old = Convert.ToInt32(Request.Form["episode_old"]);
            string etitle = Request.Form["title"].ToString();
            string elink = Request.Form["epiLink"].ToString();
            if (episode_new < 0 || etitle.Equals("") || elink.Equals(""))
            {
                msg = "There was no Episode or You've change data to blank";
                return RedirectToRoute("EManager");
            }
            else
            {
                ArrayList arrayList = new ArrayList();
                arrayList.Add(mid_new);
                arrayList.Add(episode_new);
                arrayList.Add(etitle);
                arrayList.Add(elink);
                arrayList.Add(mid_old);
                arrayList.Add(episode_old);
                episodeDAO.UpdateEpisode(arrayList);
                msg = "Edit Episode Successful!";
                return RedirectToRoute("EManager");
            }
        }

        //move to genre page
        [HttpGet]
        [Route("/editG", Name = "EditG")]
        public IActionResult EditGenre(int id)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            Genre genre = gDAO.GetGenreByID(id);
            ViewBag.genre = genre;
            return View();
        }

        //edit genre
        [HttpPost]
        [Route("/editG", Name = "EditG")]
        public IActionResult EditGenre()
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            int gid = Convert.ToInt32(Request.Form["gid"]);
            string gname = Request.Form["genreName"].ToString();
            if (gname.Equals(""))
            {
                msg = "You've enter blank genre name";
                return RedirectToRoute("GManager");
            }
            else if (gDAO.CheckGenreAlreadyExisted(gname))
            {
                msg = "This Genre Already Exist!!";
                return RedirectToRoute("GManager");
            }
            else
            {
                ArrayList arrayList = new ArrayList();
                arrayList.Add(gname);
                arrayList.Add(gid);
                gDAO.UpdateGenre(arrayList);
                msg = "Edit Genre Successful!!";
                return RedirectToRoute("GManager");
            }
        }


        /// <summary>
        /// 1. This one is Delete Control
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        //delete movie
        [Route("/deleteMovie", Name = "DeleteMovie")]
        public IActionResult DeleteMovie(int id)
        {
            string msg = string.Empty;
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            MoviesDAO movieDAO = new MoviesDAO();
            int countA = movieDAO.DeleteMovie_Actor(id);
            int countD = movieDAO.DeleteMovie_Director(id);
            int countE = movieDAO.DeleteMovie_Ep(id);
            int countF = movieDAO.DeleteMovie_Favorite(id);
            int countG = movieDAO.DeleteMovie_Genre(id);
            if (countA > 0 && countD > 0
                           && countE > 0 && countF > 0
                           && countG > 0)
            {
                int count = movieDAO.DeleteMovie(id);

                if (count > 0)
                {
                    msg = "Delete Successfully";
                }
                else
                {
                    msg = "Delete Failed";
                }
            }
            else
            {
                msg = "Delete Failed";
            }
            return MovieManage(msg);
        }

        //delete Episode
        [HttpGet]
        [Route("/deleteE", Name = "DeleteE")]
        public IActionResult DeleteE(int id, int val)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            EpisodeDAO episodeDAO = new EpisodeDAO();
            ArrayList arrayList = new ArrayList();
            arrayList.Add(id);
            arrayList.Add(val);
            episodeDAO.DeleteEpisode(arrayList);
            msg = "Delete Episode Success!";
            return RedirectToRoute("EManager");
        }

        //delete Actor
        [HttpGet]
        [Route("/deleteA", Name = "DeleteA")]
        public IActionResult DeleteA(int id)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            ActorDAO actorDAO = new ActorDAO();
            actorDAO.DeleteActor(id);
            return RedirectToRoute("AManager");
        }

        //delete director
        [HttpGet]
        [Route("/deleteD", Name = "DeleteD")]
        public IActionResult DeleteD(int id)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            DirectorDAO directorDAO = new DirectorDAO();
            directorDAO.DeleteDirector(id);

            msg = "Delete Director Success!";
            return RedirectToRoute("DManager");
        }

        //delete genre
        [HttpGet]
        [Route("/deleteG", Name = "DeleteG")]
        public IActionResult DeleteG(int id)
        {
            UProfileBase64 user = new UProfileBase64();
            if (HttpContext.Session.GetString("user") != null)
            {
                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                ViewBag.user = user;
            }
            GenreDAO genreDAO = new GenreDAO();
            genreDAO.DeleteGenre(id);

            msg = "Delete Genre Success";
            return RedirectToRoute("GManager");
        }

        //delete user
        [HttpGet]
        [Route("/deleteU", Name = "DeleteU")]
        public IActionResult DeleteU(int id)
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }

                int result = uDAO.DeleteUser(id);
                if (result > 0)
                {
                    msg = "Delete Success";
                    return UserManage(msg);
                }
                else
                {
                    msg = "Delete Fail";
                    return UserManage(msg);
                }
            }
            catch (Exception e)
            {
                msg = $"{e.ToString()}";
                return UserManage(msg);
            }
        }

        //upgrade user
        [HttpGet]
        [Route("/upgradeU", Name = "UpgradeU")]
        public IActionResult UpgradeU(int id)
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }

                bool result = uDAO.UpgradeUser(id);
                if (result)
                {
                    return RedirectToRoute("UManager");
                }
                else
                {
                    return RedirectToRoute("UManager");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToRoute("UManager");
            }
        }

        //de-upgrade
        [HttpGet]
        [Route("/deUpgradeU", Name = "DeUpgradeU")]
        public IActionResult DeUpgradeU(int id)
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }

                bool result = uDAO.DeUpgrade(id);
                if (result)
                {
                    //sent mess
                    return RedirectToRoute("UManager");
                }
                else
                {
                    return RedirectToRoute("UManager");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToRoute("UManager");
            }
        }

        //un ban user
        [HttpGet]
        [Route("/unbanU", Name = "UnBanU")]
        public IActionResult BanUser(int id)
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }

                bool result = uDAO.UnBanU(id);
                if (result)
                {
                    //sent mess
                    return RedirectToRoute("UManager");
                }
                else
                {
                    return RedirectToRoute("UManager");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToRoute("UManager");
            }
        }

        //ban user
        [HttpGet]
        [Route("/banU", Name = "BanU")]
        public IActionResult UnBanUser(int id)
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }

                bool result = uDAO.BanU(id);
                if (result)
                {
                    //sent mess
                    return RedirectToRoute("UManager");
                }
                else
                {
                    return RedirectToRoute("UManager");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToRoute("UManager");
            }
        }


        /// <summary>
        /// This one is other Table Data
        /// </summary>
        /// <param name="mess"></param>
        /// <returns></returns>

        //movie actor
        [HttpGet]
        [Route("/MActor", Name = "MActor")]
        public IActionResult MActor(string mess)
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }
                List<Movie> listm = mDAO.GetAllMovies();
                List<Actor> lista = aDAO.GetAllActor();
                ViewBag.M = listm;
                ViewBag.A = lista;
                ViewBag.Mess = mess;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToRoute("MActor");
            }
            return View("MActor");
        }

        [HttpPost]
        [Route("/MActor", Name = "MActor")]
        public IActionResult MActor(int mid, int aid)
        {
            string mess = string.Empty;
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }
                aid = int.Parse(Request.Form["aid"].ToString());
                mid = int.Parse(Request.Form["mid"].ToString());
                if (!aDAO.checkMovieActorExist(aid, mid))
                {
                    int count = aDAO.AddMovieActor(aid, mid);
                    if (count > 0)
                    {
                        mess = "Add Success";
                    }
                    else
                    {
                        mess = "Add failed";
                    }
                }
                else
                {
                    mess = "This actor is already involved in the movie";
                }


            }
            catch (Exception e)
            {
                mess = e.Message;
            }
            return MActor(mess);
        }

        //movie genre
        [HttpGet]
        [Route("/MGenre", Name = "MGenre")]
        public IActionResult MGenre(string mess)
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }
                List<Genre> listg = gDAO.GetAllGenres();
                List<Movie> listm = mDAO.GetAllMovies();
                ViewBag.G = listg;
                ViewBag.M = listm;
                ViewBag.Mess = mess;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToRoute("MGenre");

            }
            return View("MGenre");
        }

        [HttpPost]
        [Route("/MGenre", Name = "MGenre")]
        public IActionResult MGenre(int mid, int gid)
        {
            string mess = string.Empty;
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }
                gid = int.Parse(Request.Form["gid"].ToString());
                mid = int.Parse(Request.Form["mid"].ToString());
                if (gDAO.CheckMovieGenreAlreadyExisted(mid, gid))
                {
                    mess = "This movie already has this Genre";
                }
                else
                {
                    int count = gDAO.AddMovieGenre(mid, gid);
                    if (count > 0)
                    {
                        mess = "Add Success";
                    }
                    else
                    {
                        mess = "Add failed";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToRoute("MGenre");

            }
            return MGenre(mess);
        }

        //movie director
        [HttpGet]
        [Route("/MDirector", Name = "MDirector")]
        public IActionResult MDirector(string mess)
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                    List<Movie> listMovie = mDAO.GetAllMovies();
                    ViewBag.movie = listMovie;

                    List<Director> listdir = dDAO.GetAllDirector();
                    ViewBag.director = listdir;

                    ViewBag.Mess = mess;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToRoute("MDirector");
            }
            return View("MDirector");

        }

        [HttpPost]
        [Route("/MDirector", Name = "MDirector")]
        public IActionResult MDirector(int mid, int did)
        {
            string mess = string.Empty;
            try
            {
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }
                //int mid = Convert.ToInt32(Request.Form["mid"].ToString());
                if (mDAO.CheckMovie_DirectorAlreadyExisted(mid, did))
                {
                    mess = "Movie Director already exist";
                }
                else
                {
                    ArrayList arrayList = new ArrayList();
                    arrayList.Add(did);
                    arrayList.Add(mid);
                    int count = mDAO.AddMovie_Director(arrayList);
                    if (count > 0)
                    {
                        mess = "Add Success";
                    }
                    else
                    {
                        mess = "Add failed";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToRoute("MDirector");
            }
            return MDirector(mess);
        }
    }
}
