using System.Collections.Generic;
using WebAppMidtermReview.DAL;

namespace WebAppMidtermReview.BLL
{
    public class Student
    {
        //[Required]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public Student SearchStudent(int id) => StudentDB.SearchRecord(id);
        public List<Student> GetStudentList() => StudentDB.GetAllRecords();

    }
}