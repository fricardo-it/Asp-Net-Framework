using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppMidtermReview.BLL;
using WebAppMidtermReview.DAL;

namespace WebAppMidtermReview.DAL
{
    public class ProjectDB
    {

        public static List<Project> GetAllRecords()
        {
            List<Project> listP = new List<Project>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Projects",conn);
            SqlDataReader dr = cmdSelectAll.ExecuteReader();
            Project project;
            while (dr.Read())
            {
                project = new Project();
                project.ProjectCode = dr["ProjectCode"].ToString();
                project.ProjectTitle = dr["ProjectTitle"].ToString();
                project.DueDate = Convert.ToDateTime(dr["DueDate"]);
                listP.Add(project);
            }

            conn.Close();
            return listP;
        }
    }
}
