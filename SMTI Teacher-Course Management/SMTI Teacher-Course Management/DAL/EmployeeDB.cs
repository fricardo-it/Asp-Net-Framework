using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SMTI_Teacher_Course_Management.BLL;

namespace SMTI_Teacher_Course_Management.DAL
{
    public class EmployeeDB
    {
        public static Employee SearchRecord(int empId)
        {
            Employee employee = new Employee();

            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearch = new SqlCommand();
            cmdSearch.Connection = conn;
            cmdSearch.CommandText = "SELECT * FROM Employees " +
                                    "WHERE EmployeeNumber=@EmployeeNumber";
            cmdSearch.Parameters.AddWithValue("@EmployeeNumber", empId);
            SqlDataReader dr = cmdSearch.ExecuteReader();
            if (dr.Read())
            {
                employee.EmployeeNumber = Convert.ToInt32(dr["EmployeeNumber"]);
                employee.FirstName = dr["FirstName"].ToString();
                employee.LastName = dr["LastName"].ToString();
                employee.JobTitle = dr["JobTitle"].ToString();
            }
            else
            {
                employee = null;
            }
            conn.Close();

            return employee;
        }

        public static List<Employee> GetAllRecords()
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", conn);
            SqlDataReader dr = cmdSelectAll.ExecuteReader();
            Employee employee;
            while (dr.Read())
            {
                employee = new Employee();
                employee.EmployeeNumber = Convert.ToInt32(dr["EmployeeNumber"]);
                employee.FirstName = dr["FirstName"].ToString();
                employee.LastName = dr["LastName"].ToString();
                employee.JobTitle = dr["JobTitle"].ToString();

                listE.Add(employee);
            }

            conn.Close();
            return listE;
        }
    }
}