using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMTI_Teacher_Course_Management.DAL;

namespace SMTI_Teacher_Course_Management.VALIDATION
{

    public class Validator
    {

        public static bool IsEmployeeMaxCoursesReached(int employeeNumber, int maxProjectsAllowed)
        {
            int assignedCoursesCount = CourseAssignmentDB.GetAssignedCoursesCountForEmployee(employeeNumber);

            return assignedCoursesCount >= maxProjectsAllowed;
        }

        public static bool IsEmpty(string usr, string pw)
        {
            return usr != null && pw != null;
        }

        public static bool IsCoordinator(int usrId)
        {
            return usrId == 4444;  // ID Coordinator
        }

        public static bool IsProjectAssigned(int employeeNumber, string courseCode) => CourseAssignmentDB.IsCourseAssigned(employeeNumber, courseCode);

    }
}