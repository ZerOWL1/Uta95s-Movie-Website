using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Controllers.EControl
{
    public class MailVerification
    {
        public string RandomCode()
        {
            Random rd = new Random();
            int number = rd.Next(999999);
            return $"UTA95S{number:000000}";
        }

        public bool SendMail(Mail mail, string code)
        {
            bool sendMail = false;
            try
            {
                string pass = "pokemonlol123478kid";
                var smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential("uta95s.verify@gmail.com", pass);

                var fromMail = new MailAddress("uta95s.verify@gmail.com", "UTA95S Verification Team");
                var toMail = new MailAddress(mail.ToMail);

                var mailMess = new MailMessage(fromMail, toMail);
                mailMess.Subject = "Uta95s Verification";
                mailMess.Body = $"Please verify your account using this code: {code}";
                mailMess.IsBodyHtml = true;
                mailMess.Priority = MailPriority.High;
                smtpClient.Send(mailMess);
                //Test
                Console.WriteLine("Sent message successfully....");
                sendMail = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error at SendMail Func " + e.Message);
                throw;
            }
            return sendMail;
        }
    }
}
