using System;
using System.Collections;
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
        private SqlConnection con = new SqlConnection();


        //get actor by actor id return data table
        public DataTable GetActorById(int id)
        {
            String sql = "SELECT * FROM  ACTOR INNER JOIN MOVIE_ACTOR ON MOVIE_ACTOR.AID = ACTOR.AID"
                         + " WHERE MOVIE_ACTOR.MID = " + id;
            return DBContext.GetDataBySQL(sql);
        }

        //get all actor
        public List<Actor> GetAllActor()
        {
            List<Actor> listA = new List<Actor>();
            string sql = "select * from ACTOR";
            DataTable data = DBContext.GetDataBySQL(sql);
            foreach (DataRow row in data.Rows)
            {
                int aid = Convert.ToInt32(row["AID"]);
                string acname = row["AcName"].ToString();
                string acwiki = row["AcWiki"].ToString();
                Actor a = new Actor(aid, acname, acwiki);
                listA.Add(a);
            }
            return listA;
        }

        //get actor by ID
        public Actor GetActor(int aid)
        {
            string sql = "select * from ACTOR where AID = " + aid;
            DataTable data = DBContext.GetDataBySQL(sql);
            DataRow row = data.Rows[0];
            string acname = row["AcName"].ToString();
            string acwiki = row["AcWiki"].ToString();
            Actor a = new Actor(aid, acname, acwiki);
            return a;
        }

        //add actor
        public int AddActor(ArrayList arrayList)
        {
            string sql = "Insert into ACTOR Values (@aname, @awiki)";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@aname", SqlDbType.NVarChar),
                new SqlParameter("@awiki", SqlDbType.NVarChar)
            };
            for (int i = 0; i < arrayList.Count; i++)
            {
                sqlParameters[i].Value = arrayList[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);

        }
        
        //update actor
        public int UpdateActor(ArrayList arrayList)
        {
            string sql = "UPDATE ACTOR SET [AcName] = @aname,[AcWiki] = @awiki WHERE AID = @aid";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@aname", SqlDbType.NVarChar),
                new SqlParameter("@awiki", SqlDbType.NVarChar),
                new SqlParameter("@aid", SqlDbType.Int)
            };
            for (int i = 0; i < arrayList.Count; i++)
            {
                sqlParameters[i].Value = arrayList[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);

        }
        
        //delete actor
        public int DeleteActor(int aid)
        {
            string sql = "DELETE FROM [ACTOR] WHERE AID = @aid";

            SqlParameter sqlParameters = new SqlParameter("@aid", SqlDbType.Int);
            sqlParameters.Value = aid;

            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        //add movie_actor
        public int AddMovieActor(int aid, int mid)
        {
            string sql = "Insert into [MOVIE_ACTOR] Values  (@aid,@mid)";
            ArrayList ma = new ArrayList() { aid,mid};
            SqlParameter[] sqlParameters = new SqlParameter[]{
                new SqlParameter("@aid", SqlDbType.Int),
                new SqlParameter("@mid", SqlDbType.Int),
            };
            for (int i = 0; i< ma.Count; i++)
            {
                sqlParameters[i].Value = ma[i];
            }


            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        //check movie_actor exist
        public bool checkMovieActorExist(int aid,int mid)
        {
            string sql = "select * from MOVIE_ACTOR where AID = " + aid + " and MID = " + mid;
            DataTable data = DBContext.GetDataBySQL(sql);
            if(data.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
