using SMTI_Teacher_Course_Management.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMTI_Teacher_Course_Management.BLL
{
    public class Employee
    {
        //EmployeeNumber          FirstName            LastName         JobTitle

        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }

        public Employee SearchEmployee(int employeeId) => EmployeeDB.SearchRecord(employeeId);
        public List<Employee> GetEmployeeList() => EmployeeDB.GetAllRecords();

    }
}