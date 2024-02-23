using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebAppMidtermReview.BLL;
using WebAppMidtermReview.Validation;


namespace WebAppMidtermReview.GUI
{
    public partial class ProjectAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //show the list for the first time 
            if (!IsPostBack)
            {
                int teacherId = 11111;//(int)Session["teacherId"];
                Teacher teacher = new Teacher();
                teacher = teacher.SearchTeacher(teacherId);
                //MessageBox.Show(teacher.TeacherId.ToString());
                LabelTeacherId.Text = teacher.TeacherId.ToString();
                LabelTeacherName.Text = teacher.FirstName.ToString() + " " + teacher.LastName;


                Student student = new Student();
                foreach (var s in student.GetStudentList())
                {
                    DropDownListStudent.Items.Add(s.StudentId + " |  " + s.FirstName + " | " + s.LastName);
                }

                Project project = new Project();
                foreach (var p in project.GetProjectList())
                {
                    DropDownListProject.Items.Add(p.ProjectCode + " | " + p.ProjectTitle + " | " + p.DueDate);
                }
            }
        }

        protected void CalendarAssignedDate_SelectionChanged(object sender, EventArgs e)
        {
            TextBoxAssignedDate.Text = CalendarAssignedDate.SelectedDate.ToString();
        }

        protected void CalendarSubmittedDate_SelectionChanged(object sender, EventArgs e)
        {
            TextBoxSubmittedDate.Text = CalendarSubmittedDate.SelectedDate.ToString();
        }

        protected void ButtonAssignProject_Click(object sender, EventArgs e)
        {
            // check if form is filled

            if (DropDownListStudent.SelectedIndex < 0 || DropDownListProject.SelectedIndex < 0
                                                      || string.IsNullOrEmpty(TextBoxAssignedDate.Text) || string.IsNullOrEmpty(TextBoxSubmittedDate.Text))
            {
                MessageBox.Show("Please select all fields before assigning the project.", "Select fields");
                return;
            }

            string inputStudent = DropDownListStudent.Text.Trim();
            string[] fieldsS = inputStudent.Split('|');
            int sId = Convert.ToInt32(fieldsS[0]);

            string inputProject = DropDownListProject.Text.Trim();
            string[] fieldsP = inputProject.Split('|');
            string pCode = fieldsP[0];
            
            ProjectAssigned projectAssigned = new ProjectAssigned();

            // check duplicate ProjectAssigned

            if (Validator.IsProjectAssigned(sId,pCode))
            {
                MessageBox.Show("A project has already been assigned to this student for the selected project.", "Validation Error");
                return;
            }

            // check the limit of projects assigned 

            int maxProjectsAllowed = 3;

            if (Validator.IsStudentMaxProjectsReached(sId, maxProjectsAllowed))
            {
                MessageBox.Show("Cannot assign more than 3 projects to the same student.", "Validation Error");
                return;
            }

            projectAssigned.StudentId = sId;
            projectAssigned.ProjectCode = pCode;
            projectAssigned.AssignedDate = Convert.ToDateTime(TextBoxAssignedDate.Text);
            projectAssigned.SubmittedDate = Convert.ToDateTime(TextBoxSubmittedDate.Text);
            projectAssigned.AssignProject(projectAssigned);

            MessageBox.Show("Project has been assigned to this student successfully", "Confirmation");
            
        }

        protected void ButtonListProjectsByStudent_Click(object sender, EventArgs e)
        {
            List<Project> listP = new List<Project>();

            string inputStudent = DropDownListStudent.Text.Trim();
            string[] fields = inputStudent.Split('|');
            int sId = Convert.ToInt32(fields[0]);

            ProjectAssigned projectAssigned = new ProjectAssigned();
            listP = projectAssigned.ListProjectsByStudent(sId);
            if (listP.Count > 0)
            {
                GridViewProjects.DataSource = listP;
                GridViewProjects.DataBind();
                LabelHowManyProject.Text = "Number of Projects: " + listP.Count.ToString();
            }
            else
            {
                GridViewProjects.DataSource = null;
                GridViewProjects.DataBind();
                LabelHowManyProject.Text = "Number of Projects: 0";
            }



        }

        protected void ButtonListStudentsByProject_Click(object sender, EventArgs e)
        {
            List<Student> listS= new List<Student>();

            string inputProject = DropDownListProject.Text.Trim();
            string[] fields = inputProject.Split('|');
            string pCode= fields[0];

            ProjectAssigned projectAssigned = new ProjectAssigned();
            listS = projectAssigned.ListStudentsByProject(pCode);
            if (listS.Count > 0)
            {
                GridViewStudents.DataSource = listS;
                GridViewStudents.DataBind();
                LabelHowManyStudents.Text = "Number of Students: " + listS.Count.ToString();
            }
            else
            {
                GridViewStudents.DataSource = null;
                GridViewStudents.DataBind();
                LabelHowManyStudents.Text = "Number of Students: 0";
            }


        }
    }
}
