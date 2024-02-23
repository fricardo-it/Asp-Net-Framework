using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1_ASPNetConnectedMode.DAL;

//Encapsulation 
//
namespace Lab1_ASPNetConnectedMode.BLL
{
    //instance class
    public class Employee
    {
        //class variables
        private int employeeID;
        private string firstName;
        private string lastName;
        private string jobTitle;

        //properties
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        //default constructor
        public Employee()
        {
            employeeID = 0;
            firstName = string.Empty; //"Mary"
            lastName = string.Empty;
            jobTitle = string.Empty;
        }

        //parameterized constructor
        public Employee(int employeeID, string firstName, string lastName, string jobTitle)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.jobTitle = jobTitle;
        }

        //custom methods
        //public int GetEmployeeID() { return employeeID; }   
        //public void SetEmployeeID(int empID) { employeeID = empID; }
        public void SaveEmployee(Employee emp)
        {
            EmployeeDB.SaveRecord(emp);
        }

        public List<Employee> GetEmployees()
        {
            return EmployeeDB.GetAllRecords();
        }

        public Employee SearchEmployee(int empId)
        {
            return EmployeeDB.SearchRecord(empId);
        }

        //public List<Employee> SearchEmployee(string input)
        //{
        //    return EmployeeDB.SearchRecord(input);
        //}
        public List<Employee> SearchEmployee(string input) => EmployeeDB.SearchRecord(input);
        public List<Employee> SearchEmployee(string input1, string input2) => EmployeeDB.SearchRecord(input1, input2);
        public void UpdateEmployee(Employee empUpdated) => EmployeeDB.UpDateRecord(empUpdated);
        public void DeleteEmployee(int empId) => EmployeeDB.DeleteRecord(empId);

    }
}