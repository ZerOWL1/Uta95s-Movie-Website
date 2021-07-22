using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO
{
    public class UserDAO
    {
        public bool CheckUserExist(string email, string password)
        {
            string sql = "SELECT * FROM dbo.USERM WHERE Email = '" + email + "' AND Passwords = '" + password + "'";
            DataTable data = DBContext.GetDataBySQL(sql);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckUserAlreadExisted(string email)
        {
            string sql = "SELECT * FROM dbo.USERM where Email ='" + email + "'";
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


        public User GetUser(string email)
        {
            string sql = "select * from USERM where Email = '" + email + "'";
            DataTable data = DBContext.GetDataBySQL(sql);
            DataRow dataRow = data.Rows[0];
            string name = dataRow["Name"].ToString();
            string myEmail = dataRow["Email"].ToString();
            string password = dataRow["Passwords"].ToString();
            int role = Convert.ToInt32(dataRow["Role"]);
            User user = new User (name, myEmail, password, role);
            return user;
        }

        public UProfile GetUserInfo(string email)
        {
            string sql = "select * from USERM where Email = '" + email + "'";
            DataTable data = DBContext.GetDataBySQL(sql);
            DataRow dataRow = data.Rows[0];
            string uID = dataRow["UID"].ToString();
            string name = dataRow["Name"].ToString();
            string myEmail = dataRow["Email"].ToString();
            string password = dataRow["Passwords"].ToString();
            /*byte[] uImg = (byte[])data.Rows[0]["UIMG"];
            string base64img = Convert.ToBase64String(uImg, 0, uImg.Length);*/
            int role = Convert.ToInt32(dataRow["Role"]);
            UProfile user = new UProfile(uID);
            return user;
        }
        public int SignUp(string name, string email, string pass)
        {
            int role = 0;
            ArrayList list = new ArrayList()
            {
               name, email,pass,role
            };
            string sql = "INSERT INTO [dbo].[USERM]([Name],[Email],[Passwords],[Role])" +
                            "VALUES (@Name,@Email,@Pass,@Role)";
            SqlParameter[] sqlParameters = new SqlParameter[]{
                new SqlParameter("@Name ", SqlDbType.NVarChar),
                new SqlParameter("@Email ", SqlDbType.NVarChar),
                new SqlParameter("@Pass", SqlDbType.NVarChar),
                new SqlParameter("@Role", SqlDbType.Int)};
            for (int i = 0; i < list.Count; i++)
            {
                sqlParameters[i].Value = list[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        public int ChangePassword(int id,string pass)
        {
            ArrayList list = new ArrayList()
            {
               id,pass
            };
            string sql = "UPDATE [dbo].[USERM] "+
   "SET[Passwords] = @pass"+
    " WHERE[UID] = @id ";
            SqlParameter[] sqlParameters = new SqlParameter[]{
                new SqlParameter("@id",SqlDbType.Int),
                new SqlParameter("@pass", SqlDbType.NVarChar), };
            for (int i = 0; i < list.Count; i++)
            {
                sqlParameters[i].Value = list[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        public int ChangeName(int id, string name)
        {
            ArrayList list = new ArrayList()
            {
               id,name
            };
            string sql = "UPDATE [dbo].[USERM] " +
   "SET[Name] = @name" +
    " WHERE[UID] = @id ";
            SqlParameter[] sqlParameters = new SqlParameter[]{
                new SqlParameter("@id",SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar), };
            for (int i = 0; i < list.Count; i++)
            {
                sqlParameters[i].Value = list[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        public int ChangeMail(string oldmail, string newmail)
        {
            ArrayList list = new ArrayList()
            {
               oldmail, newmail
            };
            string sql = "UPDATE [dbo].[USERM] " +
   "SET[Email] = @newmail" +
    " WHERE[Email] = @oldmail ";
            SqlParameter[] sqlParameters = new SqlParameter[]{
                new SqlParameter("@oldmail",SqlDbType.NVarChar),
                new SqlParameter("@newmail", SqlDbType.NVarChar), };
            for (int i = 0; i < list.Count; i++)
            {
                sqlParameters[i].Value = list[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);
        }
        public int DeleteUser(int id)
        {
            int rs = 0;
            string sql = "DELETE [dbo].[USERM] WHERE UID = @uid";
            SqlParameter sqlParameters = new SqlParameter("@uid", SqlDbType.Int); ;
            sqlParameters.Value = id;
            rs = DBContext.ExecuteSQL(sql, sqlParameters);
            return rs;
        }

    }
}


