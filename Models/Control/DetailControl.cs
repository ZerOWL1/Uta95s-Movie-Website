using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Control
{
    public class DetailControl
    {
        private static ActorDAO aDAO = new ActorDAO();
        private static MoviesDAO mDAO = new MoviesDAO();
        private string status = string.Empty;

        public MBase64_MAD getMovieById(int id)
        {
            try
            {
                MBase64_MAD mad = new MBase64_MAD();
                DataTable GetMovieById = mDAO.GetMoviesById(id);
                int count = 0;

                int mid = int.Parse(GetMovieById.Rows[count]["MID"].ToString());
                string title = GetMovieById.Rows[count]["Title"].ToString();
                string des = GetMovieById.Rows[count]["Description"].ToString();
                int totalEsp = int.Parse(GetMovieById.Rows[count]["Total_Episode"].ToString());
                string national = GetMovieById.Rows[count]["Nationality"].ToString();
                string language = GetMovieById.Rows[count]["Languages"].ToString();
                string release = GetMovieById.Rows[count]["Release"].ToString();

                //img
                byte[] bytesImg = (byte[])GetMovieById.Rows[count]["Movie_IMG"];
                string base64img = Convert.ToBase64String(bytesImg, 0, bytesImg.Length);

                //background image
                byte[] bytesBGImg = (byte[])GetMovieById.Rows[count]["BG_IMG"];
                string base64BGimg = Convert.ToBase64String(bytesBGImg, 0, bytesBGImg.Length);

                string trailer = GetMovieById.Rows[count]["Trailer"].ToString();
                int length = int.Parse(GetMovieById.Rows[count]["Lenght"].ToString());
                int view = int.Parse(GetMovieById.Rows[count]["View"].ToString());
                DateTime date = DateTime.Parse(GetMovieById.Rows[count]["DateADD"].ToString());
                string download = GetMovieById.Rows[count]["Download"].ToString();
                int actorID = int.Parse(GetMovieById.Rows[count]["AID"].ToString());
                string actorName = GetMovieById.Rows[count]["AcName"].ToString();
                string actorWiki = GetMovieById.Rows[count]["AcWiki"].ToString();
                int did = int.Parse(GetMovieById.Rows[count]["DID"].ToString());
                string dName = GetMovieById.Rows[count]["DiName"].ToString();
                string dNational = GetMovieById.Rows[count]["DiNationality"].ToString();

                mad = new MBase64_MAD(mid, title, des, totalEsp, national, language, release, trailer,
                    length, view, date, download, actorID, actorName,
                    actorWiki, did, dName, dNational, base64img, base64BGimg);
                return mad;
            }
            catch (Exception e)
            {
                status = "Error at function GetMovieById " + e.Message;
                return null;
            }
        }

        public ArrayList getActorById(int id)
        {
            ArrayList listActor = new ArrayList();
            try
            {
                DataTable ActorTable = aDAO.GetActorById(id);
                int count = 0;
                foreach(var item in ActorTable.Rows)
                {
                    int aid = int.Parse(ActorTable.Rows[count]["AID"].ToString());
                    string acName = ActorTable.Rows[count]["AcName"].ToString();
                    string acWiki = ActorTable.Rows[count]["AcWiki"].ToString();

                    Actor actor = new Actor(aid,acName,acWiki);
                    listActor.Add(actor);
                    count++;
                }
            }
            catch(Exception e)
            {
                status = "Error at function getActorById " + e.Message;
            }
            return listActor;
        }
    }
}
