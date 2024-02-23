using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1_ASPNetConnectedMode.BLL;
using System.Data.SqlClient;

namespace Lab1_ASPNetConnectedMode.DAL
{
    public static class EmployeeDB
    {
        //1. A method to save an employee record to the database
        /// <summary>
        /// Version : 1 working but has problem: SQL injection
        /// This method saves an employee record to the database
        /// </summary>
        /// <param name="emp"></param>

        //Insert into Employees
        //values(8888,'John','Thomas','Java Programmer')               
        //public static void SaveRecord (Employee emp)
        //{
        //    //connect DB
        //    SqlConnection conn = UtilityDB.GetDBConnection();

        //    //perform INSERT operation
        //    // create and customize an object of type SqlCommand
        //    SqlCommand cmdInsert = new SqlCommand();
        //    cmdInsert.Connection = conn;
        //    cmdInsert.CommandText = "INSERT INTO Employees " +
        //                            "VALUES(" + emp.EmployeeID + ",'" +
        //                                        emp.FirstName + "','" +
        //                                        emp.LastName + "','" +
        //                                        emp.JobTitle + "')";
        //    cmdInsert.ExecuteNonQuery();   
        //    //close DB

        //    conn.Close();
        //}

        //Version2 : Using parameterized query
        //use Parameter class
        public static void SaveRecord(Employee emp)
        {
            //Connect DB, How?
            SqlConnection conn = UtilityDB.GetDBConnection();
            //Perform the crud operation : INSERT
            //How:Create and Customize a SqlCommand object
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandText = "INSERT INTO Employees(EmployeeId,FirstName,LastName,Jobtitle) " +
                                    " VALUES (@EmployeeId,@FirstName,@LastName,@Jobtitle) ";
            cmdInsert.Parameters.AddWithValue("@EmployeeId", emp.EmployeeID);
            cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmdInsert.Connection = conn;
            cmdInsert.ExecuteNonQuery();
            //Close DB
            conn.Close();
        }

        public static List<Employee> GetAllRecords()
        {
            List<Employee> listE = new List<Employee>();

            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
                listE.Add(emp);

            }
            conn.Close();
            return listE;

        }

        //Search operation
        //Search Employee by Employee ID 
        //  if found =========> How many records returned :only one
        // Search Employee by First Name
        // if found ===========> How many records returned: 1..*
        // Design Time Polymorphism : Methods overloaded
        // If two methods have the same name but different signature (in term of
        // type and the number of parameters),they are called OVERLOADED METHODS
        // 
        public static Employee SearchRecord(int Id)
        {

            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {

                SqlCommand cmdSearch = new SqlCommand();
                cmdSearch.Connection = conn;
                cmdSearch.CommandText = "SELECT * FROM Employees " +
                                        "WHERE EmployeeId = @EmployeeId";
                cmdSearch.Parameters.AddWithValue("@EmployeeId", Id);
                // SqlDataReader provides a way of reading a forward-only stream
                // of rows from an SQL Server database
                SqlDataReader reader = cmdSearch.ExecuteReader();

                Employee emp = new Employee();
                if (reader.Read()) // found
                {
                    emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.LastName = reader["LastName"].ToString();
                    emp.JobTitle = reader["JobTitle"].ToString();

                }
                else // not found
                {
                    emp = null;
                }
                return emp;

            }

            catch (SqlException ex)
            {
                throw ex;
            }


            finally
            {
                conn.Close();
            }

        }

        public static List<Employee> SearchRecord(string input) // FirstName/LastName
        {
            List<Employee> listE = new List<Employee>();

            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSearchByName = new SqlCommand();
            cmdSearchByName.Connection = conn;
            cmdSearchByName.CommandText = "SELECT * FROM Employees " +
                                          "WHERE FirstName=@FirstName " +
                                          "      or LastName = @LastName";
            cmdSearchByName.Parameters.AddWithValue("@FirstName", input);
            cmdSearchByName.Parameters.AddWithValue("@LastName", input);
            SqlDataReader reader = cmdSearchByName.ExecuteReader();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
                listE.Add(emp);

            }
            conn.Close();
            return listE;
        }


        public static List<Employee> SearchRecord(string input1, string input2)
        {
            List<Employee> listE = new List<Employee>();

            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                SqlCommand cmdSearchByName = new SqlCommand();
                cmdSearchByName.Connection = conn;
                cmdSearchByName.CommandText = "SELECT * FROM Employees " +
                                              "WHERE FirstName=@FirstName " +
                                              "      and LastName = @LastName";
                cmdSearchByName.Parameters.AddWithValue("@FirstName", input1);
                cmdSearchByName.Parameters.AddWithValue("@LastName", input2);
                SqlDataReader reader = cmdSearchByName.ExecuteReader();
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.LastName = reader["LastName"].ToString();
                    emp.JobTitle = reader["JobTitle"].ToString();
                    listE.Add(emp);

                }

            }
            return listE;
        }

        public static void UpDateRecord(Employee empUpdated)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();

            try
            {
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE Employees " + 
                                        "SET FirstName=@FirstName, LastName=@LastName, JobTitle=@JobTitle " +
                                        "WHERE EmployeeId = @EmployeeId";

                cmdUpdate.Parameters.AddWithValue("@EmployeeId", empUpdated.EmployeeID);
                cmdUpdate.Parameters.AddWithValue("@FirstName", empUpdated.FirstName);
                cmdUpdate.Parameters.AddWithValue("@LastName", empUpdated.LastName);
                cmdUpdate.Parameters.AddWithValue("@JobTitle", empUpdated.JobTitle);

                cmdUpdate.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void DeleteRecord(int empId)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();

            try
            {
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = conn;
                cmdDelete.CommandText = "DELETE FROM Employees " + 
                                        "WHERE EmployeeId = @EmployeeId";
                cmdDelete.Parameters.AddWithValue("@EmployeeId", empId);

                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}