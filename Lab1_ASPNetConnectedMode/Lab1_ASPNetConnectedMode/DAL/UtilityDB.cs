using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; //required for Sql Server database
                             // ADO.Net Object Model

using System.Configuration;

//How to write a method
//   Q1 : What is the purpose of your method?
//   Q2 : Does your method require fomal parameters?
//             YES                NO =======> ()
//          Specify it(them)
//          Each parameter : Type, Passing method (By value, by ref, by out)
//   Q3:  Does your method return a value explicitly?
//   Q4 : Where do you use your method?

namespace Lab1_ASPNetConnectedMode.DAL
{
    public static class UtilityDB
    {
        /// <summary>
        /// This methods returns an active database connection
        /// </summary>
        /// Version :1 Working but not good
        /// <returns>Obj of type SqlConnection</returns>
        //public static SqlConnection GetDBConnection()
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = "server=LAPTOP-2GV32KTB\\SQL2019EXPRESS;database=EmployeeDB;user=sa;password=lasalle";
        //    conn.Open();
        //    return conn;
        //}

        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            conn.Open();
            return conn;
        }
    }
}