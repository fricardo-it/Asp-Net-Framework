using SMTI_Teacher_Course_Management.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMTI_Teacher_Course_Management.DAL
{
    public class UserDB
    {
        public static User SearchRecord(int username)
        {
            User user = new User();

            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearch = new SqlCommand();
            cmdSearch.Connection = conn;
            cmdSearch.CommandText = "SELECT * FROM Users " +
                                    "WHERE Username = @Username";
            cmdSearch.Parameters.AddWithValue("@Username", username);
            SqlDataReader dr = cmdSearch.ExecuteReader();
            if (dr.Read())
            {
                user.Username = Convert.ToInt32(dr["Username"]);
                user.Password = dr["Password"].ToString();

            }
            else
            {
                user = null;
            }

            conn.Close();

            return user;
        }

    }
}