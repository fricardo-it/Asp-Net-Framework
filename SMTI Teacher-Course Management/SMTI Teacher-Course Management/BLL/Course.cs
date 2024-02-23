using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMTI_Teacher_Course_Management.DAL;

namespace SMTI_Teacher_Course_Management.BLL
{
    public class Course
    {

        //CourseCode, CourseTitle, TotalHour

        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public int TotalHour { get; set; }

        public List<Course> GetCourseList() => CourseDB.GetAllRecords();

    }
}