using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO
{
    public class UsersDao
    {
        public bool CheckUserExist(string email, string password)
        {
            string sql = "SELECT * FROM dbo.USERM WHERE Email = '" + email + "' AND Passwords = '" + password + "'";
            DataTable data = DBContext.GetDataBySql(sql);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckUserAlreadExisted(string email)
        {
            string sql = "SELECT * FROM dbo.USERM where Email ='" + email+ "'";
            /*SqlParameter[] sqlParameters = new SqlParameter[] {
             new SqlParameter("@Email ", SqlDbType.NVarChar)
            };
            sqlParameters[0].Value = email;*/
           DataTable data = DBContext.GetDataBySql(sql);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      
        public Users GetUser(string email)
        {
            string sql = "select * from USERM where Email = '" + email + "'";
            DataTable data = DBContext.GetDataBySql(sql);
            DataRow dataRow = data.Rows[0];
            string name = dataRow["Name"].ToString();
            string myEmail = dataRow["Email"].ToString();
            string password = dataRow["Passwords"].ToString();
            int role = Convert.ToInt32(dataRow["Role"]);
            Users user = new Users(name, myEmail, password, role);
            return user;
        }

        public int SignUp(string email, string pass )
        {
            string[] split = email.Split('@');
            string name = split[0];
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
            new SqlParameter("@Role", SqlDbType.Int),
            
        };
            for (int i = 0; i < list.Count; i++)
            {
                sqlParameters[i].Value = list[i];
            }
            return DBContext.ExecuteSql(sql, sqlParameters);
        }
    }
}
