using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WebAppMidtermReview.BLL;

namespace WebAppMidtermReview.GUI
{
    public partial class ProjectListAssigned : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {

            if (!Page.IsPostBack)

            {
                int studentId = (int)Session["studentId"];
                Student student = new Student();
                student = student.SearchStudent(studentId);
                LabelStudentId.Text = student.StudentId.ToString();
                LabelStudentName.Text = student.FirstName.ToString() + " " + student.LastName;

                ProjectAssigned pa = new ProjectAssigned();
                List<Project> listP = pa.ListProjectsByStudent(studentId);
                if (listP.Count != 0)
                {
                    GridViewProjectsAssigned.DataSource = listP;
                    GridViewProjectsAssigned.DataBind();
                }
                else
                {
                    MessageBox.Show("No project has been assigned to this student.", "No Project");
                    Response.Redirect("Login.aspx");
                }
            }

        }
    }
}