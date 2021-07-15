using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Uta95s_Movie_Web___BETA_0._1.Controllers.EControl;
using Uta95s_Movie_Web___BETA_0._1.Controllers.EControl.MD5.Con;
using Uta95s_Movie_Web___BETA_0._1.Models.Control;
using Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Controllers
{
    public class IndexController : Controller
    {
        private MovieControl mControl;
        private UserDAO userDAO;
        private string status = string.Empty;
        public IndexController()
        {
            userDAO = new UserDAO();
            mControl = new MovieControl();
        }

        [HttpPost]
        [Route("/login", Name = "login")]
        public IActionResult Login(User user)
        {
            try
            {
                MD5Verification mD5 = new MD5Verification();
                string email = Request.Form["Email"].ToString();
                string inputPassword = Request.Form["Pass"].ToString();


                //regex mail
                Regex regex = new Regex(@"^([a-z0-9\.]+)\@([a-z\.]+)\.([a-z]+){2,3}$");
                //regex pass
                Regex passRegex = new Regex(@"(?=^.{6,32}$)(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?!.*\s).*$");

                if (user.Email != null)
                {
                    if (regex.IsMatch(email) || passRegex.IsMatch(inputPassword))
                    {
                        User userData = userDAO.GetUser(email);
                        string passwordData = userData.Pass;
                        if (user.Pass != null)
                        {
                            string encryptedPass = mD5.Encryption(inputPassword);
                            string hashPassword = BCrypt.Net.BCrypt.HashPassword(encryptedPass);
                            bool test = BCrypt.Net.BCrypt.Verify(encryptedPass, passwordData);

                            if (userDAO.CheckUserExist(email, passwordData))
                            {
                                if (test)
                                {
                                    UProfile userP = userDAO.GetUserProfile(email);
                                    //save to session
                                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(userP));
                                    return RedirectToRoute("home");
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Your password not match!!");
                                    return Index(user);
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("", "Your email you enter does not exist!!");
                                return Index(user);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "You've enter null Pass!");
                            return Index(user);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please enter a valid email or pass");
                        return Index(user);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please enter your email");
                    return Index(user);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return Index(user);
            }
        }

        [HttpPost]
        [Route("/signup", Name = "signup")]
        public IActionResult Signup(User user)
        {
            try
            {
                MailVerification m = new MailVerification();
                string code = m.RandomCode();

                MD5Verification mD5 = new MD5Verification();
                string email = Request.Form["EmailSign"].ToString();

                //regex mail
                Regex regex = new Regex(@"^([a-z0-9\.]+)\@([a-z\.]+)\.([a-z]+){2,3}$");

                /*  Pass must at least 1 number
                    Pass must at least 1 upper character
                    Pass must at least 1 character
                    Pass must have no spacing
                    Pass must have 1 special character
                    Pass must be min from 6 to max 32 char
                 */
                Regex passRegex = new Regex(@"(?=^.{6,32}$)(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?!.*\s).*$");
                string pass = Request.Form["PasswordSign"].ToString();
                string repass = Request.Form["RePasswordSign"].ToString();
                if (regex.IsMatch(email))
                {
                    if (passRegex.IsMatch(pass))
                    {
                        if (!userDAO.CheckUserAlreadExisted(email))
                        {
                            if (pass.Equals(repass))
                            {
                                string encryptedPass = mD5.Encryption(pass);
                                string hashPassword = BCrypt.Net.BCrypt.HashPassword(encryptedPass);

                                string[] split = email.Split('@');
                                string name = split[0];

                                Mail mail = new Mail(name, hashPassword,email, code);
                                //sent mail status
                                bool sendMail = m.SendMail(mail, code);

                                if (sendMail)
                                {
                                    //userDAO.SignUp(name, email, hashPassword);
                                    HttpContext.Session.SetString("signup", JsonConvert.SerializeObject(mail));
                                    return RedirectToRoute("code");
                                }
                                else
                                {
                                    return Index(user);
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("", "Pass and Re-Pass are not the same");
                                return Index(user);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Account existed");
                            return Index(user);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password must from at least 6-32 characters");
                        ModelState.AddModelError("", "With at least 1 digit, 1 uppercase, 1 lowercase");
                        ModelState.AddModelError("", "Pass need 1 special char and contain no space");
                        return Index(user);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email enter not valid");
                    return Index(user);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToRoute("default");
            }
        }


        [Route("", Name = "index")]
        [Route("/index", Name = "default")]
        public IActionResult Index(User user)
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
                status = "Error at Index func " + e.Message;
                throw;
            }
            return View("Index");
        }
    }
}
