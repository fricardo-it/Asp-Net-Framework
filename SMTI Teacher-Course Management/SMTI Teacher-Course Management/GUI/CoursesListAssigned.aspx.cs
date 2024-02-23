using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SMTI_Teacher_Course_Management.BLL;

namespace SMTI_Teacher_Course_Management.GUI
{
    public partial class CourseListAssigned : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)

            {
                int employeeNumber = (int)Session["EmployeeNumber"];
                Employee employee = new Employee();
                employee = employee.SearchEmployee(employeeNumber);
                LabelEmployeeNumber.Text = employee.EmployeeNumber.ToString();
                LabelEmployeeName.Text = employee.FirstName + " " + employee.LastName;
                LabelJobTitle.Text = employee.JobTitle;

                CourseAssigned ca = new CourseAssigned();
                List<Course> listC = ca.ListCoursesByEmployee(employeeNumber);
                if (listC.Count != 0)
                {
                    GridViewCoursesAssigned.DataSource = listC;
                    GridViewCoursesAssigned.DataBind();
                }
                else
                {
                    MessageBox.Show("No courses has been assigned to this employee.", "No Courses");
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}