using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Child;
using Uta95s_Movie_Web___BETA_0._1.Models.Entity.Parent;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database.LoadDAO
{
    public class UserDAO
    {
        //count user
        public int CountUser()
        {
            string sql = "select COUNT(UID) as count from USERM";
            DataTable data = DBContext.GetDataBySQL(sql);
            DataRow row = data.Rows[0];
            return Convert.ToInt32(row["count"]);
        }

        //check user exist by email and pass
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

        //check user exist by email
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

        //get user profile

        public UProfile GetUserProfile(string email)
        {
            string sql = "select * from USERM where Email = '" + email + "'";
            DataTable data = DBContext.GetDataBySQL(sql);
            DataRow dataRow = data.Rows[0];
            string uid = dataRow["UID"].ToString();
            string name = dataRow["Name"].ToString();
            string myEmail = dataRow["Email"].ToString();
            string password = dataRow["Passwords"].ToString();
            int role = Convert.ToInt32(dataRow["Role"]);
            byte[] uIMG = (byte[])data.Rows[0]["UIMG"];
            UProfile uProfile = new UProfile(name, email, password, role, uid, uIMG);
            return uProfile;
        }

        //get user by email
        public User GetUser(string email)
        {
            string sql = "select * from USERM where Email = '" + email + "'";
            DataTable data = DBContext.GetDataBySQL(sql);
            DataRow dataRow = data.Rows[0];
            string name = dataRow["Name"].ToString();
            string myEmail = dataRow["Email"].ToString();
            string password = dataRow["Passwords"].ToString();
            int role = Convert.ToInt32(dataRow["Role"]);
            User user = new User(name, email, password, role);
            return user;
        }

        //sign up
        public int SignUp(string name, string email, string pass)
        {
            int role = 0;

            byte[] imgData = System.IO.File.ReadAllBytes(@"./wwwroot/sources/images/Loveyou.png");

            ArrayList list = new ArrayList()
            {
               name, email, pass, role, imgData
            };
            string sql = "INSERT INTO [dbo].[USERM]([Name],[Email],[Passwords],[Role],[UIMG])" +
                            "VALUES (@Name,@Email,@Pass,@Role,@UIMG)";

            SqlParameter[] sqlParameters = new SqlParameter[]{
                new SqlParameter("@Name ", SqlDbType.NVarChar),
                new SqlParameter("@Email ", SqlDbType.NVarChar),
                new SqlParameter("@Pass", SqlDbType.NVarChar),
                new SqlParameter("@Role", SqlDbType.Int),
                new SqlParameter("@UIMG", SqlDbType.VarBinary),
            };
            

            for (int i = 0; i < list.Count; i++)
            {
                sqlParameters[i].Value = list[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        //get all user favor
        public ArrayList GetFavoriteMovie(string uid, int currentPage)
        {
            ArrayList ListFavorite = new ArrayList();
            try
            {
                string sql = "SELECT * FROM STATUS INNER JOIN MOVIES ON STATUS.SID = MOVIES.SID"
                            + " INNER JOIN FAVORITE_MOVIES ON MOVIES.MID = FAVORITE_MOVIES.MID"
                            + " INNER JOIN USERM ON FAVORITE_MOVIES.UID = USERM.UID"
                            + " WHERE USERM.UID = " + uid
                            + " ORDER BY USERM.UID OFFSET " + (currentPage - 1) * 9 + " ROWS FETCH NEXT 9 ROWS ONLY";
                DataTable data = DBContext.GetDataBySQL(sql);
                int count = 0;
                foreach (var item in data.Rows)
                {
                    int id = int.Parse(data.Rows[count]["MID"].ToString());
                    string title = data.Rows[count]["Title"].ToString();
                    string des = data.Rows[count]["Description"].ToString();
                    int totalEsp = int.Parse(data.Rows[count]["Total_Episode"].ToString());
                    string national = data.Rows[count]["Nationality"].ToString();
                    string language = data.Rows[count]["Languages"].ToString();
                    string release = data.Rows[count]["Release"].ToString();

                    //img
                    byte[] bytesImg = (byte[])data.Rows[count]["Movie_IMG"];
                    string base64img = Convert.ToBase64String(bytesImg, 0, bytesImg.Length);

                    //background image
                    byte[] bytesBGImg = (byte[])data.Rows[count]["BG_IMG"];
                    string base64BGIMG = Convert.ToBase64String(bytesBGImg, 0, bytesBGImg.Length);

                    string trailer = data.Rows[count]["Trailer"].ToString();
                    int length = int.Parse(data.Rows[count]["Lenght"].ToString());
                    int view = int.Parse(data.Rows[count]["View"].ToString());
                    DateTime date = DateTime.Parse(data.Rows[count]["DateADD"].ToString());
                    string mStatus = data.Rows[count]["saName"].ToString();
                    MBase64Favorite m = new MBase64Favorite(id, title, des, totalEsp, national, language, release, trailer, length, view,
                            date, base64img, base64BGIMG, mStatus);
                    ListFavorite.Add(m);
                    count++;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            return ListFavorite;
        }

        //delete user favor
        public int DeleteFavorite(string uid, int mid)
        {
            string sql = "DELETE FROM FAVORITE_MOVIES WHERE UID = @uid AND MID = @mid";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                 new SqlParameter("@uid ", SqlDbType.NVarChar),
                 new SqlParameter("@mid", SqlDbType.Int)
            };
            sqlParameter[0].Value = uid;
            sqlParameter[1].Value = mid;
            int rs = DBContext.ExecuteSQL(sql, sqlParameter);
            return rs;
        }

        //get total favor
        public int GetNumberFavorite(string uid)
        {
            try
            {
                string sql = "SELECT * FROM FAVORITE_MOVIES WHERE UID = " + uid;
                DataTable data = DBContext.GetDataBySQL(sql);
                int total = data.Rows.Count;
                return total;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        //process User IMG
        public UProfileBase64 GetUserProfile64(string email)
        {
            try
            {
                string sql = "select * from USERM where Email = '" + email + "'";
                DataTable data = DBContext.GetDataBySQL(sql);
                DataRow dataRow = data.Rows[0];
                string uid = dataRow["UID"].ToString();
                string name = dataRow["Name"].ToString();
                string myEmail = dataRow["Email"].ToString();
                string password = dataRow["Passwords"].ToString();
                int role = Convert.ToInt32(dataRow["Role"]);
                byte[] uIMG = (byte[])data.Rows[0]["UIMG"];
                string uIMG64 = Convert.ToBase64String(uIMG, 0, uIMG.Length);
                UProfileBase64 uProfile64 = new UProfileBase64(name, email, password, role, uid, uIMG64);
                return uProfile64;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //save User info
        public int SaveUserInfo(byte[] uimg, string uid)
        {
            try
            {
                string sql = "UPDATE USERM"
                             + " SET UIMG = @uimg"
                             + " where UID = @uid";
                SqlParameter[] sqlParameter = new SqlParameter[]
                {
                    new SqlParameter("@uimg",SqlDbType.VarBinary),
                    new SqlParameter("@uid", SqlDbType.NVarChar)
                };

                sqlParameter[0].Value = uimg;
                sqlParameter[1].Value = uid;

                int rs = DBContext.ExecuteSQL(sql, sqlParameter);
                return rs;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        //change user name
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


        //change password
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
            
        //change mail
        public int ChangeMail(int uid, string newmail)
        {
            ArrayList list = new ArrayList()
            {
                uid, newmail
            };
            string sql = "UPDATE [dbo].[USERM] " +
                         "SET[Email] = @newmail" +
                         " WHERE[UID] = @uid ";
            SqlParameter[] sqlParameters = new SqlParameter[]{
                new SqlParameter("@uid",SqlDbType.Int),
                new SqlParameter("@newmail", SqlDbType.NVarChar), };
            for (int i = 0; i < list.Count; i++)
            {
                sqlParameters[i].Value = list[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        //delete User
        public int DeleteUser(int id)
        {
            int rs = 0;
            string sql = "DELETE [dbo].[USERM] WHERE UID = @uid";
            SqlParameter sqlParameters = new SqlParameter("@uid", SqlDbType.Int); ;
            sqlParameters.Value = id;
            rs = DBContext.ExecuteSQL(sql, sqlParameters);
            return rs;
        }

        //check Favorites Exist
        public bool checkFavoriteExist(int uid, int mid)
        {
            try {
                string sql = "select * from FAVORITE_MOVIES where [UID] =" + uid + " and [MID] = " + mid;
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
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            
        }

        //add favor
        public int AddFavorite(int uid, int mid)
        {
            ArrayList list = new ArrayList()
            {
                uid,mid
            };
            string sql = "INSERT INTO [dbo].[FAVORITE_MOVIES] " +
                         " ([UID],[MID]) VALUES (@uid,@Mid)";
            SqlParameter[] sqlParameters = new SqlParameter[]{
                new SqlParameter("@uid", SqlDbType.Int),
                new SqlParameter("@mid", SqlDbType.Int)
            };
            for (int i = 0; i < list.Count; i++)
            {
                sqlParameters[i].Value = list[i];
            }
            return DBContext.ExecuteSQL(sql, sqlParameters);
        }

        //get user return list
        public ArrayList GetAllUser()
        {
            string sql = "SELECT * FROM dbo.USERM";
            DataTable data = DBContext.GetDataBySQL(sql);
            ArrayList list = new ArrayList();
            foreach (DataRow item in data.Rows)
            {
                UProfileBase64 user = new UProfileBase64();
                user.UID = item["UID"].ToString();
                user.Name = item["Name"].ToString();
                user.Email = item["Email"].ToString();
                user.Role = Convert.ToInt32(item["Role"].ToString());
                list.Add(user);
            }
            return list;
        }

        //upgrade user role
        public bool UpgradeUser(int id)
        {
            string sql = "UPDATE dbo.USERM SET Role = '1' WHERE UID = @uid";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@uid", SqlDbType.Int)
            };
            parameters[0].Value = id;
            int rs = DBContext.ExecuteSQL(sql, parameters);
            if (rs > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //de-upgrade user role
        public bool DeUpgrade(int id)
        {
            string sql = "UPDATE dbo.USERM SET Role = '0' WHERE UID = @uid";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@uid", SqlDbType.Int)
            };
            parameters[0].Value = id;
            int rs = DBContext.ExecuteSQL(sql, parameters);
            if (rs > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //ban user
        public bool BanU(int id)
        {
            string sql = "UPDATE dbo.USERM SET Role = '-1' WHERE UID = @uid";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@uid", SqlDbType.Int)
            };
            parameters[0].Value = id;
            int rs = DBContext.ExecuteSQL(sql, parameters);
            if (rs > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //un ban user
        public bool UnBanU(int id)
        {
            string sql = "UPDATE dbo.USERM SET Role = '0' WHERE UID = @uid";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@uid", SqlDbType.Int)
            };
            parameters[0].Value = id;
            int rs = DBContext.ExecuteSQL(sql, parameters);
            if (rs > 0)
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
