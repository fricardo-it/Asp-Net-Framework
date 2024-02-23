using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebAppMidtermReview.BLL;

namespace WebAppMidtermReview.DAL
{
    public class StudentDB
    {
        public static Student SearchRecord(int sId)
        {
            Student student = new Student();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearch = new SqlCommand();
            cmdSearch.Connection = conn;
            cmdSearch.CommandText = "SELECT * FROM Students " +
                                    "WHERE StudentId=@StudentId";
            cmdSearch.Parameters.AddWithValue("@StudentId", sId);
            SqlDataReader dr = cmdSearch.ExecuteReader();
            if (dr.Read())
            {
                student.StudentId = Convert.ToInt32(dr["StudentId"]);
                student.FirstName = dr["FirstName"].ToString();
                student.LastName = dr["LastName"].ToString();
                student.Password = dr["Password"].ToString();
            }
            else
            {
                student = null;
            }
            conn.Close();
            return student;
        }

        public static List<Student> GetAllRecords()
        {
            List<Student> listS = new List<Student>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Students", conn);
            SqlDataReader dr = cmdSelectAll.ExecuteReader();
            Student student;
            while (dr.Read())
            {
                student = new Student();
                student.StudentId = Convert.ToInt32(dr["StudentId"]);
                student.FirstName = dr["FirstName"].ToString();
                student.LastName = dr["LastName"].ToString();
                student.Password = dr["Password"].ToString();

                listS.Add(student);
            }

            conn.Close();
            return listS;
        }
    }
}