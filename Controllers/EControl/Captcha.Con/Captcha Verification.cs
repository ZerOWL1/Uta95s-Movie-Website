using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Uta95s_Movie_Web___BETA_0._1.Controllers.EControl.Captcha.Con
{
    public class Captcha_Verification
    {
        public bool checkCaptcha(string response)
        {
            bool status = false;
            //gg secretKey
            string secretKey = "6Lern4AaAAAAAE1GHMVOLnNKlQS0O3JqAVhYOrbe";
            //declare
            var client = new WebClient();
            var rs = client.DownloadString(
                string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(rs);
            return status = (bool) obj.SelectToken("success");
        }
    }
}
