using SMTI_Teacher_Course_Management.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMTI_Teacher_Course_Management.DAL
{
    public class CourseDB
    {
        public static List<Course> GetAllRecords()
        {
            List<Course> listC = new List<Course>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Courses", conn);
            SqlDataReader dr = cmdSelectAll.ExecuteReader();
            Course course;
            while (dr.Read())
            {
                course = new Course();
                course.CourseCode = dr["CourseCode"].ToString();
                course.CourseTitle = dr["CourseTitle"].ToString();
                course.TotalHour = Convert.ToInt32(dr["TotalHour"]);
                listC.Add(course);
            }

            conn.Close();
            return listC;
        }
    }
}