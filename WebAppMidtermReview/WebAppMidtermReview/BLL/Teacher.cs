using WebAppMidtermReview.DAL;

namespace WebAppMidtermReview.BLL
{
    public class Teacher
    {

        //TeacherId          FirstName            LastName         Password

        public int  TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public Teacher SearchTeacher(int teacherId) => TeacherDB.SearchRecord(teacherId);

    }
}