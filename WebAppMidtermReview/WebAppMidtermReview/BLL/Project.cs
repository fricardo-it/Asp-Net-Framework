using System;
using System.Collections.Generic;
using WebAppMidtermReview.DAL;

namespace WebAppMidtermReview.BLL
{
    public class Project
    {
        //ProjectCode, ProjectTitle,DueDate

        public string ProjectCode { get; set; }
        public string ProjectTitle { get; set; }
        public DateTime DueDate { get; set; }

        public List<Project> GetProjectList() => ProjectDB.GetAllRecords();

    }
}