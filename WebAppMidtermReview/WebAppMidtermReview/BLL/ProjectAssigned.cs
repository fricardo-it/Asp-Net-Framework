using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebAppMidtermReview.DAL;

namespace WebAppMidtermReview.BLL
{
    //StudentId,ProjectCode,AssignedDate,SubmittedDate

    public class ProjectAssigned
    {
        public int StudentId { get; set; }
        public string ProjectCode { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime SubmittedDate { get; set; }
        public int Grade { get; set; }

        public List<Project> ListProjectsByStudent(int studentId) => ProjectAssignmentDB.ListProjectsByStudent(studentId);
        public List<Student> ListStudentsByProject(string projectCode) => ProjectAssignmentDB.ListStudentsByProject(projectCode);
        public void AssignProject(ProjectAssigned projectAssigned) => ProjectAssignmentDB.SaveProjectAssignment(projectAssigned);

    }
}