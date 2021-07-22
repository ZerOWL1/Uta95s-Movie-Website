using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Uta95s_Movie_Web___BETA_0._1.Controllers.EControl;
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
        string mess = string.Empty;

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
                        HttpContext.Session.Remove("signup");
                        return RedirectToAction("Index", "Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Code Input!!");
                        return RedirectToAction("Index", "Index");
                    }
                }
                else if (HttpContext.Session.GetString("changeMail") != null)
                {
                    mail = JsonConvert.DeserializeObject<Mail>(HttpContext.Session.GetString("changeMail"));
                    if (inputCode.Equals(mail.ReCode))
                    {
                        if (HttpContext.Session.GetString("user") != null)
                        {
                            user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                            string oldmail = user.Email;
                            int count = userDAO.ChangeMail(oldmail, mail.ToMail);
                            if (count > 0)
                            {
                                user = userDAO.GetUser(mail.ToMail);

                                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                                mess = "Change Success";
                            }
                            HttpContext.Session.Remove("changeMail");
                            return Profile(mess);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Code Input!!");
                        return RedirectToAction("home");
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
                                user = userDAO.GetUser(mail.ToMail);
                            UProfile up = userDAO.GetUserInfo(mail.ToMail);
                            int uID = Convert.ToInt32(up.UID);
                            string hashPassword = BCrypt.Net.BCrypt.HashPassword(encryptedPass);
                            int count = userDAO.ChangePassword(uID, hashPassword);
                            if (count > 0)
                            {
                                mess = "Change sucessfully";
                                //HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));

                            }
                            HttpContext.Session.Remove("changePass");
                            HttpContext.Session.Remove("newPass");
                            return Profile(mess);

                        }
                        else
                        {
                            return RedirectToAction("Index", "Index");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Code Input!!");
                        return RedirectToAction("home");
                    }
                    HttpContext.Session.Remove("changePass");
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


        [Route("/profile", Name = "profile")]
        public IActionResult Profile(string mess)
        {
            try
            {
                User user = new User();
                UProfile uP = new UProfile();
                UserDAO udao = new UserDAO();
                int uID = 0;
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                    uP = udao.GetUserInfo(user.Email);
                    ViewBag.uP = uP;
                    ViewBag.Message = mess;
                }
                return View("Profile");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View("Profile");
            }

        }

        [Route("/editName", Name = "editName")]
        public IActionResult editName()
        {
            return View();
        }
        [Route("/editEmail", Name = "editEmail")]
        public IActionResult editEmail()
        {
            return View();
        }
        [Route("/changePass", Name = "changePass")]
        public IActionResult changePass()
        {
            try
            { 
            User user = new User();
            UProfile uP = new UProfile();
            UserDAO udao = new UserDAO();
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
                user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                string passwordData = user.Pass;
                uP = udao.GetUserInfo(user.Email);
                uID = Convert.ToInt32(uP.UID);

                cupass = Request.Form["cu-pass"].ToString();
                if(cupass != string.Empty)
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

                            } else {

                                renewpass = Request.Form["re-new-pass"].ToString();
                                if (newpass.Equals(renewpass))
                                {
                                    //string hashPassword = BCrypt.Net.BCrypt.HashPassword(encryptedPass);
                                        Mail mail = new Mail(user.Name,user.Pass,user.Email,code);
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
                                        /*int count = userDAO.ChangePassword(uID, hashPassword);
                                         // alert successful
                                         if (count > 0)
                                         {
                                             mess = "Change successfully";
                                         }
                                         // alert failed
                                         else
                                         {
                                             mess = "Change failed";
                                         }*/
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
                   mess =  "Current Password is Empty";
                }

            }
            }catch (Exception e)
            {
                mess = e.Message;
            }


            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Insert is successfull')", true);
            return Profile(mess);
        }
        [Route("/deleteUser", Name = "deleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                User user = new User();
                UProfile uP = new UProfile();
                UserDAO udao = new UserDAO();
                int count = 0;
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                    ViewBag.user = user;
                    uP = udao.GetUserInfo(user.Email);
                    ViewBag.uP = uP;
                    id = Convert.ToInt32(uP.UID);
                    count = userDAO.DeleteUser(id);
                    if(count > 0)
                    {
                        return RedirectToAction("Index", "Index");
                    }
                    else
                    {
                        return Profile("");
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
                return Profile("");
            }
        }

        [Route("/changeName", Name = "changeName")]
        public IActionResult changeName()
        {
            try
            {
                UserDAO udao = new UserDAO();
                User user = new User();
                UProfile uP = new UProfile();
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                }
                string email = user.Email;
                uP = udao.GetUserInfo(email);
                int uID = Convert.ToInt32(uP.UID);
                string name = Request.Form["userName"].ToString();
                if (name != string.Empty)
                {
                    int count = udao.ChangeName(uID, name);
                    if (count > 0)
                    {
                        user = udao.GetUser(email);
                        HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Name can not be empty");
                }
            }catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
           
            return RedirectToRoute("profile");
        }

        [Route("/changeMail", Name = "changeMail")]
        public IActionResult changeMail()
        {

            try
            {
                UserDAO udao = new UserDAO();
                User user = new User();
                UProfile uP = new UProfile();
                
                MailVerification m = new MailVerification();
                string code = m.RandomCode();
                if (HttpContext.Session.GetString("user") != null)
                {
                    //get session
                    user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                }
                Regex regex = new Regex(@"^([a-z0-9\.]+)\@([a-z\.]+)\.([a-z]+){2,3}$");
                string email = user.Email;
                string pass = user.Pass;
                string name = user.Name;
                uP = udao.GetUserInfo(email);
                int uID = Convert.ToInt32(uP.UID);
                string newMail = Request.Form["userEmail"].ToString();
                
                if (newMail != string.Empty)
                {
                    if (regex.IsMatch(newMail)) {
                        if (!udao.CheckUserAlreadExisted(newMail)) {
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
                                mess = "Change failed";
                                return Profile(mess);
                            }
                        }
                        else
                        {
                            mess = "This Email is aldready registered";
                            return Profile(mess);
                        }
                    }
                    else
                    {
                        mess = "Mail is not Valid";
                        return Profile(mess);
                    }
                }
                else
                {
                    mess = "Mail can not be empty";
                    return Profile(mess);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
           return RedirectToRoute("profile");
        }

        [Route("/logout", Name = "logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Index");
        }
    }
}
