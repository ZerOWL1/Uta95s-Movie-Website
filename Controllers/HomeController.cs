using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Uta95s_Movie_Web___BETA_0._1.Controllers.EControl;
using Uta95s_Movie_Web___BETA_0._1.Controllers.EControl.Captcha.Con;
using Uta95s_Movie_Web___BETA_0._1.Controllers.EControl.MD5.Con;
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
        private Captcha_Verification captcha;
        private string mess = String.Empty;

        // generate constructor injection
        public HomeController(ILogger<HomeController> logger)
        {
            captcha = new Captcha_Verification();
            userDAO = new UserDAO();
            indexControl = new IndexController();
            _logger = logger;
        }

        //home page
        [Route("/home", Name = "home")]
        public IActionResult Home()
        {
            UProfileBase64 user = new UProfileBase64();

            try
            {
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
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
                ModelState.AddModelError("", $"Your password not match - {e.ToString()}!!");
                return RedirectToAction("Index", "Index");
            }
        }

        //contact page
        [Route("/mail", Name = "mail")]
        public IActionResult Mail()
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
                ArrayList listGenre = GenreControl.Genre();
                ViewBag.Genre = listGenre;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return RedirectToAction("Home", "Home");
            }
            return View();
        }

        //random code page
        [Route("/code", Name = "code")]
        public IActionResult RandomCode(Mail mail)
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
                ArrayList listGenre = GenreControl.Genre();
                ViewBag.Genre = listGenre;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return RedirectToAction("Home", "Home");
            }
            return View(mail);
        }

        //verify code sent from mail
        [Route("/verifyCode", Name = "verifyCode")]
        public IActionResult VerifyCode()
        {
            Mail mail = new Mail();
            UProfileBase64 user = new UProfileBase64();
            try
            {
                string inputCode = Request.Form["randomCode"].ToString();
                ArrayList listGenre = GenreControl.Genre();
                ViewBag.Genre = listGenre;
                //get captcha siteKey
                var response = Request.Form["g-recaptcha-response"];
                bool checkCaptcha = false;
                checkCaptcha = captcha.checkCaptcha(response);
                if (checkCaptcha)
                {
                    if (HttpContext.Session.GetString("signup") != null)
                    {
                        //get session
                        mail = JsonConvert.DeserializeObject<Mail>(HttpContext.Session.GetString("signup"));
                        if (inputCode == mail.ReCode)
                        {
                            userDAO.SignUp(mail.Name, mail.ToMail, mail.Pass);
                            UProfileBase64 userSignUP = new UProfileBase64();
                            userSignUP = userDAO.GetUserProfile64(mail.ToMail);
                            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(userSignUP));
                            HttpContext.Session.Remove("signup");
                            mess = "Sign Up Successful! Please sign-in";
                            ViewBag.Mess = mess;
                            return RedirectToAction("Home", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", " Sign Up Fail! Invalid Code");
                            return View("RandomCode");
                        }
                    }
                    else if (HttpContext.Session.GetString("changeMail") != null)
                    {
                        mail = JsonConvert.DeserializeObject<Mail>(HttpContext.Session.GetString("changeMail"));
                        if (inputCode.Equals(mail.ReCode))
                        {
                            if (HttpContext.Session.GetString("user") != null)
                            {
                                user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                                int id = Convert.ToInt32(user.UID);
                                int count = userDAO.ChangeMail(id, mail.ToMail);
                                if (count > 0)
                                {
                                    user = userDAO.GetUserProfile64(mail.ToMail);
                                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                                    mess = "Change Mail Success";
                                }
                                HttpContext.Session.Remove("changeMail");
                                return Profile(1, 1, mess);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Index");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid Code");
                            return View("RandomCode");
                        }
                    }
                    else if ((HttpContext.Session.GetString("changePass") != null))
                    {
                        mail = JsonConvert.DeserializeObject<Mail>(HttpContext.Session.GetString("changePass"));
                        if (inputCode.Equals(mail.ReCode))
                        {
                            if (HttpContext.Session.GetString("newPass") != null)
                            {
                                string encryptedPass = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("newPass"));
                                user = userDAO.GetUserProfile64(mail.ToMail);
                                UProfileBase64 up = userDAO.GetUserProfile64(mail.ToMail);
                                int uID = Convert.ToInt32(up.UID);
                                string hashPassword = BCrypt.Net.BCrypt.HashPassword(encryptedPass);
                                int count = userDAO.ChangePassword(uID, hashPassword);
                                if (count > 0)
                                {
                                    mess = "Change Pass Successfully";
                                    //HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                                }
                                HttpContext.Session.Remove("changePass");
                                HttpContext.Session.Remove("newPass");
                                return Profile(1, 1, mess);

                            }
                            else
                            {
                                HttpContext.Session.Remove("changePass");
                                return RedirectToAction("Index", "Index");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid Code");
                            return View("RandomCode");
                        }
                    }
                    else
                    {
                        HttpContext.Session.Remove("changePass");
                        ModelState.AddModelError("", "Session Error!!");
                        return RedirectToAction("Index", "Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please check captcha");
                    return View("RandomCode");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToAction("Index", "Index", indexControl.Index(null, e.ToString()));
            }
        }

        //movie-detail
        [Route("/details", Name = "details")]
        public IActionResult Details(int id, string mess)
        {
            UProfileBase64 user = new UProfileBase64();
            try
            {
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }
                ArrayList listGenre = GenreControl.Genre();
                ViewBag.Genre = listGenre;

                DetailControl movieControl = new DetailControl();

                MBase64_MAD mad = movieControl.getMovieById(id);

                DirectorDAO dDAO = new DirectorDAO();
                List<Director> listDirector = dDAO.GetDirectorById(id);
                ViewBag.listDirector = listDirector;

                ArrayList listActor = movieControl.getActorById(id);
                ViewBag.listActor = listActor;
                ViewBag.Mess = mess;
                return View("details", mad);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Home", "Home");
            }
        }

        //details
        [Route("/films", Name = "films")]
        public IActionResult Movies(int id, int val)
        {
            UProfileBase64 user = new UProfileBase64();
            try
            {
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                }
                ArrayList listGenre = GenreControl.Genre();
                ViewBag.Genre = listGenre;

                if (val == 0) val = 1;

                MovieControl movieControl = new MovieControl();
                ArrayList listEpisodeMovie = movieControl.GetMovieEpisodeById(id);
                ViewBag.listEpMovie = listEpisodeMovie;

                ArrayList listMoviesLatestUpdate = movieControl.MoviesLatestUpdate();
                ViewBag.MoviesLatestUpdate = listMoviesLatestUpdate;

                ArrayList list4LatestUpdate = movieControl.Get4MoviesLatest();
                ViewBag.list4LatestUpdate = list4LatestUpdate;

                Episode me = movieControl.GetEpisode(id, val);
                if (me == null)
                {
                    mess = "This movies not ready!!";
                    return Details(id, mess);
                }
                else
                {
                    return View(me);
                }
            }
            catch (Exception e)
            {
                mess = $"{e.ToString()}";
                return Details(id, mess);
            }

        }

        //profile
        [Route("/profiles", Name = "profile")]
        public IActionResult Profile(int page, int col, string mess)
        {
            //lay session. uid
            if (page == 0) page = 1;
            //lay session. uid
            UProfileBase64 uProfile = new UProfileBase64();
            try
            {
                ArrayList listGenre = GenreControl.Genre();
                ViewBag.Genre = listGenre;

                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    uProfile = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.uProfile = uProfile;
                    ViewBag.user = uProfile;
                    ViewBag.userP = userDAO.GetUserProfile64(uProfile.Email);

                    ArrayList listFavorite = userDAO.GetFavoriteMovie(uProfile.UID, page);
                    ViewBag.listFavorite = listFavorite;

                    //Phan trang 9 items
                    int count = userDAO.GetNumberFavorite(uProfile.UID);
                    int endPage = count / 9;
                    if (count % 9 != 0) endPage++;

                    ViewBag.totalPage = endPage;
                    ViewBag.CurrentPage = page;
                    ViewBag.Col = col;
                    ViewBag.Mess = mess;

                }
                return View("Profile");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View("Profile");

            }
        }

        //change-pass user
        [Route("/changePass", Name = "changePass")]
        public IActionResult changePass()
        {
            try
            {
                UProfileBase64 uSession = new UProfileBase64();
                UProfileBase64 uP = new UProfileBase64();
                MD5Verification md5 = new MD5Verification();
                int uID = 0;
                string cupass = string.Empty;
                string newpass = string.Empty;
                string renewpass = string.Empty;
                MailVerification m = new MailVerification();
                string code = m.RandomCode();
                Regex passRegex = new Regex(@"(?=^.{6,32}$)(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?!.*\s).*$");
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    uSession = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    string passwordData = uSession.Pass;
                    uP = userDAO.GetUserProfile64(uSession.Email);
                    uID = Convert.ToInt32(uP.UID);

                    cupass = Request.Form["cu-pass"].ToString();
                    if (cupass != string.Empty)
                    {
                        cupass = md5.Encryption(cupass);
                        bool test = BCrypt.Net.BCrypt.Verify(cupass, passwordData);
                        if (test)
                        {
                            newpass = Request.Form["new-pass"].ToString();
                            if (passRegex.IsMatch(newpass))
                            {
                                string encryptedPass = md5.Encryption(newpass);
                                bool test2 = BCrypt.Net.BCrypt.Verify(newpass, passwordData);
                                if (test2)
                                {
                                    mess = "New pass can not be the same as old one";
                                }
                                else
                                {
                                    renewpass = Request.Form["re-new-pass"].ToString();
                                    if (newpass.Equals(renewpass))
                                    {
                                        //string hashPassword = BCrypt.Net.BCrypt.HashPassword(encryptedPass);
                                        Mail mail = new Mail(uSession.Name, uSession.Pass, uSession.Email, code);
                                        bool sendMail = m.SendMail(mail, code);

                                        if (sendMail)
                                        {
                                            //userDAO.SignUp(name, email, hashPassword);
                                            HttpContext.Session.SetString("newPass", JsonConvert.SerializeObject(encryptedPass));
                                            HttpContext.Session.SetString("changePass", JsonConvert.SerializeObject(mail));
                                            return RedirectToRoute("code");
                                        }
                                        else
                                        {
                                            return RedirectToRoute("profile");
                                        }
                                    }
                                    else
                                    {
                                        mess = "Re-pass is not similar with new-pass!";
                                    }
                                }
                            }
                            else
                            {
                                mess = "Password is not valid";
                            }
                        }
                        else
                        {
                            mess = "Wrong Password";
                        }
                    }
                    else
                    {
                        mess = "Current Password is Empty";
                    }
                }
            }
            catch (Exception e)
            {
                mess = e.Message;
            }
            return Profile(1, 2, mess);
        }

        //delete-acc
        [Route("/deleteUser", Name = "deleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                UProfileBase64 uP = new UProfileBase64();
                UProfileBase64 uProfile = new UProfileBase64();
                int count = 0;
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    uProfile = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    ViewBag.user = uProfile;
                    uP = userDAO.GetUserProfile64(uProfile.Email);
                    ViewBag.uP = uP;
                    id = Convert.ToInt32(uP.UID);
                    count = userDAO.DeleteUser(id);
                    if (count > 0)
                    {
                        return RedirectToAction("Index", "Index");
                    }
                    else
                    {
                        return RedirectToAction("Profile", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Index");
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToAction("Home", "Home"); ;
            }
        }

        //user-change-name
        [Route("/changeName", Name = "changeName")]
        public IActionResult changeName()
        {
            try
            {
                UProfileBase64 lastestUser = new UProfileBase64();
                UProfileBase64 user = new UProfileBase64();
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    lastestUser = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                }
                string email = lastestUser.Email;
                int uID = Convert.ToInt32(lastestUser.UID);
                string name = Request.Form["userName"].ToString();
                if (name != string.Empty)
                {
                    int count = userDAO.ChangeName(uID, name);
                    if (count > 0)
                    {
                        user = userDAO.GetUserProfile64(email);
                        HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                        mess = "Change name successful";
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Name can not be empty");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToRoute("profile");
            }

            return Profile(1, 1, mess);
        }

        //user change mail
        [Route("/changeMail", Name = "changeMail")]
        public IActionResult changeMail()
        {
            try
            {
                UProfileBase64 user = new UProfileBase64();

                MailVerification m = new MailVerification();
                string code = m.RandomCode();
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                }
                Regex regex = new Regex(@"^([a-z0-9\.]+)\@([a-z\.]+)\.([a-z]+){2,3}$");
                string pass = user.Pass;
                string name = user.Name;
                string newMail = Request.Form["userEmail"].ToString();

                if (newMail != string.Empty)
                {
                    if (regex.IsMatch(newMail))
                    {
                        if (!userDAO.CheckUserAlreadExisted(newMail))
                        {
                            Mail mail = new Mail(name, pass, newMail, code);
                            bool sendMail = m.SendMail(mail, code);

                            if (sendMail)
                            {
                                //userDAO.SignUp(name, email, hashPassword);
                                HttpContext.Session.SetString("changeMail", JsonConvert.SerializeObject(mail));
                                return RedirectToRoute("code");
                            }
                            else
                            {
                                mess = "Change Email failed";
                                return Profile(1, 1, mess);
                            }
                        }
                        else
                        {
                            mess = "This Email is already registered";
                            return Profile(1, 1, mess);
                        }
                    }
                    else
                    {
                        mess = "Mail is not Valid";
                        return Profile(1, 1, mess);
                    }
                }
                else
                {
                    mess = "Mail can not be empty";
                    return Profile(1, 1, mess);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return RedirectToRoute("profile");
        }

        //user edit image
        [Route("/EditImg", Name = "editprofile")]
        public async Task<IActionResult> EditUIMG(IFormFile UIMG)
        {
            try
            {
                UProfile uProfile = new UProfile();
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    uProfile = JsonConvert.DeserializeObject<UProfile>(HttpContext.Session.GetString("user"));
                }
                if (UIMG.Length < 0)
                {
                    return RedirectToAction("Profile", "Home");
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        await UIMG.CopyToAsync(ms);
                        uProfile.UIMG = ms.ToArray();
                    }
                    userDAO.SaveUserInfo(uProfile.UIMG, uProfile.UID);

                    //Get user with img base64 by using email from session
                    UProfileBase64 userP64 = userDAO.GetUserProfile64(uProfile.Email);
                    //save to session
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(userP64));
                    mess = "Upload Avatar Success!!";

                    //Success mess
                    return Profile(1, 1, mess);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.ToString();
                return RedirectToAction("Profile", "Home");
            }
        }

        //user remove favorites
        [Route("/DeleteFa", Name = "deletefa")]
        public IActionResult DeleteFavorite(int mid, int col)
        {
            //lay session. uid
            UProfileBase64 uProfile = new UProfileBase64();
            try
            {
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    uProfile = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    userDAO.DeleteFavorite(uProfile.UID, mid);
                    mess = String.Empty;
                }
            }
            catch (Exception ex)
            {
                return Profile(1, col, ex.ToString());
            }

            return Profile(1, col, mess);
        }

        //user-logout
        [Route("/logout", Name = "logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Index");
        }

        //category
        [Route("/category", Name = "category")]
        public IActionResult Category(int id, int page)
        {
            try
            {
                UProfile uProfile = null;
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    uProfile = JsonConvert.DeserializeObject<UProfile>(HttpContext.Session.GetString("user"));
                }

                ViewBag.user = uProfile;

                ArrayList listGenre = GenreControl.Genre();
                ViewBag.Genre = listGenre;
                if (page == 0) page = 1;

                ArrayList listMovies = GenreControl.GetMovieByGenre(id, page);
                ViewBag.listMovies = listMovies;

                MGenre mg = GenreControl.GetNameGenre(id);
                ViewBag.mg = mg;

                //OffSet 9 items
                int count = GenreControl.GetNumberMovie(id);
                int endPage = count / 12;
                if (count % 12 != 0) endPage++;

                ViewBag.totalPage = endPage;
                ViewBag.CurrentPage = page;

                return View("category");
            }
            catch (Exception e)
            {
                return View(e.ToString());
            }
        }


        [Route("/search", Name = "search")]
        public IActionResult Search(string txt, int page)
        {
            try
            {
                if (page == 0) page = 1;

                //string text = Request.Form["txt"].ToString();
                if (txt != null)
                {
                    HttpContext.Session.SetString("category", JsonConvert.SerializeObject(txt));
                }

                UProfile uProfile = null;
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    uProfile = JsonConvert.DeserializeObject<UProfile>(HttpContext.Session.GetString("user"));
                }
                ViewBag.user = uProfile;

                string text2 = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("category"));

                ArrayList listSearch = GenreControl.getMovieBySearch(text2, page);
                ViewBag.listSearch = listSearch;

                int count = GenreControl.GetNumberSearch(text2);
                int endPage = count / 12;
                if (count % 12 != 0) endPage++;

                ViewBag.totalPage = endPage;
                ViewBag.CurrentPage = page;

                ArrayList listGenre = GenreControl.Genre();
                ViewBag.Genre = listGenre;
                return View("category");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //add favor
        [Route("/favorite", Name = "favorite")]
        public IActionResult AddToFavorite(int mID)
        {
            UProfileBase64 user = new UProfileBase64();
            Movie m = new Movie();
            int uID = 0;
            bool checkExisted = false;
            try
            {
                ArrayList listGenre = GenreControl.Genre();
                ViewBag.Genre = listGenre;

                if (HttpContext.Session.GetString("user") != null)
                {
                    user = JsonConvert.DeserializeObject<UProfileBase64>(HttpContext.Session.GetString("user"));
                    string Mail = user.Email;
                    uID = Convert.ToInt32(user.UID);
                    checkExisted = userDAO.checkFavoriteExist(uID, mID);
                    ViewBag.Check = checkExisted;
                    ViewBag.user = user;
                    if (checkExisted)
                    {
                        //sent error mess
                        mess = "Already Added in Favorite";
                    }
                    else
                    {
                        int count = userDAO.AddFavorite(uID, mID);
                        if (count > 0)
                        {
                            mess = "Add To Favorite Successfully";
                        }
                        else
                        {
                            mess = "Add To Favorite Failed";
                        }
                    }
                }
                return Details(mID, mess);
            }
            catch (Exception e)
            {
                mess = $"{e.ToString()}";
                return Details(mID, mess);
            }

            //return RedirectToAction("Home", "Home");
        }
    }
}
