using WebAppMidtermReview.DAL;

namespace WebAppMidtermReview.Validation
{
    public class Validator
    {
        public static bool IsProjectAssigned(int studentId, string projectCode) => ProjectAssignmentDB.IsProjectAssigned(studentId, projectCode);


        public static bool IsStudentMaxProjectsReached(int studentId, int maxProjectsAllowed)
        {
            int assignedProjectsCount = ProjectAssignmentDB.GetAssignedProjectsCountForStudent(studentId);

            return assignedProjectsCount >= maxProjectsAllowed;
        }

        public static bool IsEmpty(string usr, string pw)
        {
            return usr != null && pw != null;
        }
    }
}