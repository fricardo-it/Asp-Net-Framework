using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SMTI_Teacher_Course_Management.BLL;

namespace SMTI_Teacher_Course_Management.DAL
{
    public class CourseAssignmentDB
    {
        // select C.* from Courses
        //join EmployeeCourses EC on C.CourseCode = EC.CourseCode
        //where EC.EmployeeNumber = 1234


        public static List<Course> ListCoursesByEmployee(int empId)
        {
            List<Course> listC = new List<Course>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdCourseByEmployee = new SqlCommand();
            cmdCourseByEmployee.Connection = conn;
            cmdCourseByEmployee.CommandText = "SELECT C.* FROM Courses C" +
                                              " JOIN CourseAssignments CA on C.CourseCode = CA.CourseCode " +
                                              " WHERE CA.EmployeeNumber = @EmployeeNumber";
            cmdCourseByEmployee.Parameters.AddWithValue("@EmployeeNumber", empId);
            SqlDataReader dr = cmdCourseByEmployee.ExecuteReader();
            while (dr.Read())
            {
                Course course = new Course();
                course.CourseCode = dr["CourseCode"].ToString();
                course.CourseTitle = dr["CourseTitle"].ToString();
                course.TotalHour = Convert.ToInt32(dr["TotalHour"]);
                listC.Add(course);
            }

            return listC; 
        }

        public static void SaveCourseAssignment(CourseAssigned ca)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                SqlCommand cmdSave = new SqlCommand();
                cmdSave.Connection = conn;
                cmdSave.CommandText =
                    "INSERT INTO CourseAssignments(EmployeeNumber,CourseCode)" +
                    "VALUES (@EmployeeNumber, @CourseCode)";
                cmdSave.Parameters.AddWithValue("EmployeeNumber", ca.EmployeeNumber);
                cmdSave.Parameters.AddWithValue("CourseCode", ca.CourseCode);
                cmdSave.ExecuteNonQuery();
            }
        }

        public static int GetAssignedCoursesCountForEmployee(int empId)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                SqlCommand cmdCountCourses = new SqlCommand();
                cmdCountCourses.Connection = conn;
                cmdCountCourses.CommandText =
                    "SELECT COUNT(*) FROM CourseAssignments WHERE EmployeeNumber = @EmployeeNumber";
                cmdCountCourses.Parameters.AddWithValue("EmployeeNumber", empId);

                int count = (int)cmdCountCourses.ExecuteScalar();
                return count;
            }
        }


        public static bool IsCourseAssigned(int empId, string courseCode)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                List<CourseAssigned> listCA = new List<CourseAssigned>();

                SqlCommand cmdSelectCA = new SqlCommand();
                cmdSelectCA.Connection = conn;
                cmdSelectCA.CommandText =
                    "SELECT * FROM CourseAssignments WHERE EmployeeNumber = @EmployeeNumber AND CourseCode = @CourseCode";
                cmdSelectCA.Parameters.AddWithValue("EmployeeNumber", empId);
                cmdSelectCA.Parameters.AddWithValue("CourseCode", courseCode);

                SqlDataReader dr = cmdSelectCA.ExecuteReader();
                while (dr.Read())
                {
                    CourseAssigned courseAssigned = new CourseAssigned();
                    listCA.Add(courseAssigned);
                }

                if (listCA.Count > 0)
                {
                    return true;
                }

                return false;
            }
        }

    }
}
