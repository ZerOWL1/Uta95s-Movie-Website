using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Database;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO
{
    public class ActorDAO
    {
        public SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        private SqlDataAdapter da = new SqlDataAdapter();
        private string status = String.Empty;
        private SqlDataReader dr;
        private SqlConnection con = new SqlConnection();
        DBContext db = new DBContext();
        public List<Actor> GetActors()
        {
            List<Actor> list = new List<Actor>();
            try
            {
                con.ConnectionString = db.ConnectionString();
                con.Open();
                cmd.Connection = con;
                string sql = "SELECT * FROM Actor";
                cmd.CommandText = sql;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Actor()
                    {
                        ActorName = dr.GetString(1),
                        ActorWiki = dr.GetString(2)
                    });
                }
                cmd.Clone();
            }
            catch (Exception e)
            {
                status = "Error while at GetActors Func " + e.Message;
                throw;
            }
            return list;
        }
    }
}
