using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using WebAppMidtermReview.BLL;


namespace WebAppMidtermReview.DAL
{
    public class ProjectAssignmentDB
    {
        // select Projects.* from Projects
        //join ProjectAssignments on Projects.ProjectCode= ProjectAssignments.ProjectCode
        //where ProjectAssignments.StudentID= 1111111

        //select P.* from Projects P
        // join ProjectAssignments PA on P.ProjectCode= PA.ProjectCode
        //where PA.StudentID= 1111111

        public static List<Project> ListProjectsByStudent(int sId)
        {
            List<Project> listP = new List<Project>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdProjByStudent = new SqlCommand();
            cmdProjByStudent.Connection = conn;
            cmdProjByStudent.CommandText = "SELECT P.* FROM Projects P " +
                                           "JOIN ProjectAssignments PA " +
                                           " ON P.ProjectCode= PA.ProjectCode " +
                                           " WHERE StudentID = @StudentID";
            cmdProjByStudent.Parameters.AddWithValue("@StudentID", sId);
            SqlDataReader dr = cmdProjByStudent.ExecuteReader();
            while (dr.Read())
            {
                Project project = new Project();
                project.ProjectCode = dr["ProjectCode"].ToString();
                project.ProjectTitle = dr["ProjectTitle"].ToString();
                project.DueDate = Convert.ToDateTime(dr["DueDate"]);
                listP.Add(project);
            }

            return listP;
        }

        public static List<Student> ListStudentsByProject(string pCode)
        {
            List<Student> listS = new List<Student>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdStdByProject = new SqlCommand();
            cmdStdByProject.Connection = conn;
            cmdStdByProject.CommandText = "SELECT S.* FROM Students S " +
                                          "JOIN ProjectAssignments PA " +
                                          " ON S.StudentId = PA.StudentId " +
                                          " WHERE ProjectCode = @ProjectCode";
            cmdStdByProject.Parameters.AddWithValue("ProjectCode", pCode);
            SqlDataReader dr = cmdStdByProject.ExecuteReader();
            while (dr.Read())
            {
                Student student = new Student();
                student.StudentId = Convert.ToInt32(dr["StudentId"]);
                student.FirstName = dr["FirstName"].ToString();
                student.LastName = dr["LastName"].ToString();
                listS.Add(student);
            }

            return listS;
        }

        public static void SaveProjectAssignment(ProjectAssigned pa)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                SqlCommand cmdSave = new SqlCommand();
                cmdSave.Connection = conn;
                cmdSave.CommandText =
                    "INSERT INTO ProjectAssignments(StudentId,ProjectCode, AssignedDate, SubmittedDate, Grade)" +
                    "VALUES (@StudentId, @ProjectCode, @AssignedDate, @SubmittedDate, @Grade)";
                cmdSave.Parameters.AddWithValue("StudentId", pa.StudentId);
                cmdSave.Parameters.AddWithValue("ProjectCode", pa.ProjectCode);
                cmdSave.Parameters.AddWithValue("AssignedDate", pa.AssignedDate);
                cmdSave.Parameters.AddWithValue("SubmittedDate", pa.SubmittedDate);
                cmdSave.Parameters.AddWithValue("Grade", pa.Grade);
                cmdSave.ExecuteNonQuery();
            }
        }

        public static bool IsProjectAssigned(int sId, string pCode)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                List<ProjectAssigned> listPA = new List<ProjectAssigned>();

                SqlCommand cmdSelectPA = new SqlCommand();
                cmdSelectPA.Connection = conn;
                cmdSelectPA.CommandText =
                    "SELECT * FROM ProjectAssignments WHERE StudentId = @StudentId AND ProjectCode = @ProjectCode";
                cmdSelectPA.Parameters.AddWithValue("StudentId", sId);
                cmdSelectPA.Parameters.AddWithValue("ProjectCode", pCode);

                SqlDataReader dr = cmdSelectPA.ExecuteReader();
                while (dr.Read())
                {
                    ProjectAssigned projectAssigned = new ProjectAssigned();
                    listPA.Add(projectAssigned);
                }

                if (listPA.Count > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public static int GetAssignedProjectsCountForStudent(int studentId)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                SqlCommand cmdCountProjects = new SqlCommand();
                cmdCountProjects.Connection = conn;
                cmdCountProjects.CommandText =
                    "SELECT COUNT(*) FROM ProjectAssignments WHERE StudentId = @StudentId";
                cmdCountProjects.Parameters.AddWithValue("StudentId", studentId);

                int count = (int)cmdCountProjects.ExecuteScalar();
                return count;
            }
        }

    }
}
