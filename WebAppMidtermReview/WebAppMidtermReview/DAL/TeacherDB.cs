using System.Data.SqlClient;
using System;
using WebAppMidtermReview.BLL;
using WebAppMidtermReview.DAL;
using System.Security.Cryptography;

namespace WebAppMidtermReview.DAL
{
    public static class TeacherDB
    {
        public static Teacher SearchRecord(int tId)
        {
            Teacher teacher = new Teacher();

            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearch = new SqlCommand();
            cmdSearch.Connection = conn;
            cmdSearch.CommandText = "SELECT * FROM Teachers " +
                                    "WHERE TeacherId=@TeacherId";
            cmdSearch.Parameters.AddWithValue("@TeacherId", tId);
            SqlDataReader dr = cmdSearch.ExecuteReader();
            if (dr.Read())
            {
                teacher.TeacherId = Convert.ToInt32(dr["TeacherId"]);
                teacher.FirstName = dr["FirstName"].ToString();
                teacher.LastName = dr["LastName"].ToString();
                teacher.Password = dr["Password"].ToString();
            }
            else
            {
                teacher = null;
            }
            conn.Close(); 

            return teacher;
        }
    }
}