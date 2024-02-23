using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using SMTI_Teacher_Course_Management.BLL;
using SMTI_Teacher_Course_Management.VALIDATION;

namespace SMTI_Teacher_Course_Management.GUI
{
    public partial class CourseAssignment : System.Web.UI.Page
    {
            protected void Page_Load(object sender, EventArgs e)
            {
                //show the list for the first time 
                if (!IsPostBack)
                {
                    int employeeNumber = 4444;//(int)Session["teacherId"];
                    Employee employee = new Employee();
                    employee = employee.SearchEmployee(employeeNumber);
                    LabelEmployeeNumber.Text = employee.EmployeeNumber.ToString();
                    LabelEmployeeName.Text = employee.FirstName + " " + employee.LastName;

                    foreach (var emp in employee.GetEmployeeList())
                    {
                        DropDownListEmployee.Items.Add(emp.EmployeeNumber + " | " + emp.FirstName + " " + emp.LastName + " | " + emp.JobTitle);
                    }

                    Course course = new Course();
                    foreach (var c in course.GetCourseList())
                    {
                        DropDownListCourse.Items.Add(c.CourseCode + " |  " + c.CourseTitle + " | " + c.TotalHour);
                    }
      
                }
            }


        protected void ButtonAssignCourse_Click(object sender, EventArgs e)
        {
            // check if form is filled

            if (DropDownListEmployee.SelectedIndex < 0 || DropDownListCourse.SelectedIndex < 0)

            {
                MessageBox.Show("Please select all fields before assigning the course.", "Select fields");
                return;
            }

            string inputEmployee = DropDownListEmployee.Text.Trim();
            string[] fieldsE = inputEmployee.Split('|');
            int empId = Convert.ToInt32(fieldsE[0]);

            string inputCourse = DropDownListCourse.Text.Trim();
            string[] fieldsP = inputCourse.Split('|');
            string cCode = fieldsP[0];

            CourseAssigned courseAssigned = new CourseAssigned();

            // check duplicate ProjectAssigned

            if (Validator.IsProjectAssigned(empId, cCode))
            {
                MessageBox.Show("A course has already been assigned to this employee for the selected project.", "Validation Error");
                return;
            }

            // check the limit of projects assigned 

            int maxProjectsAllowed = 3;

            if (Validator.IsEmployeeMaxCoursesReached(empId, maxProjectsAllowed))
            {
                MessageBox.Show("Cannot assign more than 3 courses to the same employee.", "Validation Error");
                return;
            }

            courseAssigned.EmployeeNumber = empId;
            courseAssigned.CourseCode = cCode;
            courseAssigned.AssignCourse(courseAssigned);

            MessageBox.Show("Course has been assigned to this employee successfully", "Confirmation");

        }

        protected void ButtonListCoursesByEmployee_Click(object sender, EventArgs e)
        {
            List<Course> listC = new List<Course>();

            string inputEmployee = DropDownListEmployee.Text.Trim();
            string[] fields = inputEmployee.Split('|');
            int empId = Convert.ToInt32(fields[0]);

            CourseAssigned courseAssigned= new CourseAssigned();
            listC = courseAssigned.ListCoursesByEmployee(empId);
            if (listC.Count > 0)
            {
                GridViewCourses.DataSource = listC;
                GridViewCourses.DataBind();
                LabelHowManyCourses.Text = "Number of Courses: " + listC.Count.ToString();
            }
            else
            {
                GridViewCourses.DataSource = null;
                GridViewCourses.DataBind();
                LabelHowManyCourses.Text = "Number of Courses: 0";
            }

        }

        protected void ButtonViewGroups_Click(object sender, EventArgs e)
        {
            List<Group> listG = new List<Group>();

            Group group = new Group();
            listG = group.GetGroupList();
            if (listG.Count > 0)
            {
                GridViewGroups.DataSource = listG;
                GridViewGroups.DataBind();
            }
            else
            {
                GridViewGroups.DataSource = null;
                GridViewGroups.DataBind();
            }

        }
    }
}