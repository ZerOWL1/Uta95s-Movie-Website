using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DAL_Database;

namespace Uta95s_Movie_Web___BETA_0._1.Models.Database
{
    public class DBContext
    {
        private static SqlCommand cmd;
        private static SqlDataAdapter da = new SqlDataAdapter();
        
        
        //connect return sql connection
        public static SqlConnection GetConnection()
        {
            DBConnection dbCon = new DBConnection();
            var conStr = dbCon.GetConnectionString();
            return new SqlConnection(conStr);
        } 

        //connect return connect string using for data reader
        public static string ConnectionString()
        {
            DBConnection dbCon = new DBConnection();
            var conStr = dbCon.GetConnectionString();
            return conStr;
        } 

        //SELECT Method
        public static DataTable GetDataBySQL(string sql)
        {
            DataSet ds = new DataSet();
            DataTable table = new DataTable();
            cmd = new SqlCommand(sql, GetConnection());
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds.Tables[0];
        }

        //Execute using for update, insert, delete
        public static int ExecuteSQL(string sql, params SqlParameter[] sqlParameter)
        {
            cmd = new SqlCommand(sql, GetConnection());
            //Add using Parameter
            cmd.Parameters.AddRange(sqlParameter);
            cmd.Connection.Open();
            int rs = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return rs;
        }
    }
}
