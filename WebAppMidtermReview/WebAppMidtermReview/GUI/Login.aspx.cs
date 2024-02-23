using System;
using System.Windows.Forms;
using WebAppMidtermReview.BLL;
using WebAppMidtermReview.Validation;


//using WebAppMidtermReview.DAL; // just for test

namespace WebAppMidtermReview.GUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownListLoginAs.Items.Add("Teacher");
                DropDownListLoginAs.Items.Add("Student");
            }
        }
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(UtilityDB.GetDBConnection().State.ToString());
            // use Session object to store UserName (StudentId)

            if (!Validator.IsEmpty(TextBoxUsername.Text, TextBoxPassword.Text))
            {
                MessageBox.Show("Username and Password are required. Fill both fields.", "Invalid Credentials");
                return;
            }

            switch (DropDownListLoginAs.SelectedIndex)
            {
                case 0: // for Teacher
                    Teacher teacher = new Teacher();
                    teacher = teacher.SearchTeacher(Convert.ToInt32(TextBoxUsername.Text));
                    if (teacher != null && (teacher.Password).ToUpper() == TextBoxPassword.Text.ToUpper())
                    {
                        Session["teacherId"] = Convert.ToInt32(TextBoxUsername.Text.Trim());
                        Response.Redirect("ProjectAssignment.aspx");
                    }
                    else
                    {
                        MessageBox.Show("Invalid UserName or Password!", "Invalid credentials");
                        TextBoxUsername.Text = string.Empty;
                        TextBoxPassword.Text = string.Empty;
                        TextBoxUsername.Focus();
                    }
                    break;
                case 1: // for Student
                    Student student = new Student();
                    student = student.SearchStudent(Convert.ToInt32(TextBoxUsername.Text));
                    if (student != null && (student.Password).ToUpper() == TextBoxPassword.Text.ToUpper())
                    {
                        Session["studentId"] = Convert.ToInt32(TextBoxUsername.Text.Trim());
                        // Session["studentUser"] = student;
                        Response.Redirect("ProjectListAssigned.aspx");
                    }
                    else
                    {
                        MessageBox.Show("Invalid UserName or Password!", "Invalid User");
                        TextBoxUsername.Text = string.Empty;
                        TextBoxPassword.Text = string.Empty;
                        TextBoxUsername.Focus();
                    }
                    break;
                default:
                    break;
            }

        }
    }
}