using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMTI_Teacher_Course_Management.DAL;

namespace SMTI_Teacher_Course_Management.BLL
{
    public class CourseAssigned
    {

    //EmployeeNumber, CourseCode
        public int EmployeeNumber { get; set; }
        public string CourseCode { get; set; }

        public List<Course> ListCoursesByEmployee(int employeeNumber) => CourseAssignmentDB.ListCoursesByEmployee(employeeNumber);
        public void AssignCourse(CourseAssigned courseAssigned) => CourseAssignmentDB.SaveCourseAssignment(courseAssigned);

    }
}