using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO
{
    public class DirectorDAO
    {
        //check director exist
        public bool CheckDirectorAlreadExisted(string diname)
        {
            string sql = "select * from DIRECTOR where DiName = '" + diname + "'";
            DataTable data = DBContext.GetDataBySQL(sql);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //get all director
        public List<Director> GetAllDirector()
        {
            List<Director> listD = new List<Director>();
            string sql = "select * from DIRECTOR";
            DataTable data = DBContext.GetDataBySQL(sql);
            foreach (DataRow row in data.Rows)
            {
                int did = Convert.ToInt32(row["DID"]);
                string dname = row["DiName"].ToString();
                string dNationality = row["DiNationality"].ToString();
                Director d = new Director(did, dname, dNationality);
                listD.Add(d);
            }
            return listD;
        }

        //get director by id
        public Director GetDirector(int did)
        {
            string sql = "select * from DIRECTOR where did = " + did;
            DataTable data = DBContext.GetDataBySQL(sql);
            DataRow row = data.Rows[0];
            string dname = row["DiName"].ToString();
            string dNationality = row["DiNationality"].ToString();
            Director d = new Director(did, dname, dNationality);
            return d;
        }

        //add director
        public int AddDirector(ArrayList arrayList)
        {
            string sql = "Insert into [DIRECTOR] Values (@dname, @dnationality)";
            SqlParameter[] sqlParameters = new SqlParameter[] {
            new SqlParameter("@dname", SqlDbType.NVarChar),
            new SqlParameter("@dnationality", SqlDbType.NVarChar)
            };
            for (int i = 0; i < arrayList.Count; i++)
            {
                sqlParameters[i].Value = arrayList[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        //update director
        public int UpdateDirector(ArrayList arrayList)
        {
            string sql = "UPDATE [DIRECTOR] SET [DiName] = @dname,[DiNationality] = @dnationality WHERE DID = @did";
            SqlParameter[] sqlParameters = new SqlParameter[] {
            new SqlParameter("@dname", SqlDbType.NVarChar),
            new SqlParameter("@dnationality", SqlDbType.NVarChar),
            new SqlParameter("@did", SqlDbType.Int)
            };
            for (int i = 0; i < arrayList.Count; i++)
            {
                sqlParameters[i].Value = arrayList[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);

        }

        //delete director
        public int DeleteDirector(int did)
        {
            string sql = "DELETE FROM [DIRECTOR] WHERE DID = @did";

            SqlParameter sqlParameters = new SqlParameter("@did", SqlDbType.Int);
            sqlParameters.Value = did;

            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        public List<Director> GetDirectorById(int mid)
        {
            List<Director> list = new List<Director>();
            String sql = "SELECT * FROM  DIRECTOR INNER JOIN MOVIE_DIRECTOR ON MOVIE_DIRECTOR.DID = DIRECTOR.DID"
                         + " WHERE MOVIE_DIRECTOR.MID = " + mid;
            DataTable data = DBContext.GetDataBySQL(sql);
            foreach (DataRow row in data.Rows)
            {
                int did = Convert.ToInt32(row["DID"]);
                string dname = row["DiName"].ToString();
                string dNationality = row["DiNationality"].ToString();
                Director d = new Director(did, dname, dNationality);
                list.Add(d);
            }
            return list;
        }
    }
}
