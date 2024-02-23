using SMTI_Teacher_Course_Management.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMTI_Teacher_Course_Management.BLL
{
    public class Group
    {

        //GroupNumber          Description

        public int GroupNumber { get; set; }
        public string Description { get; set; }

        public List<Group> GetGroupList() => GroupDB.GetAllRecords();
    }
}