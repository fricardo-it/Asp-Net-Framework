using SMTI_Teacher_Course_Management.VALIDATION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using SMTI_Teacher_Course_Management.BLL;

namespace SMTI_Teacher_Course_Management.GUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownListLoginAs.Items.Add("Employee");
                DropDownListLoginAs.Items.Add("Program Coordinator");
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (!Validator.IsEmpty(TextBoxUsername.Text, TextBoxPassword.Text))
            {
                MessageBox.Show("Username and Password are required. Fill both fields.", "Invalid Credentials");
                return;
            }


            User user = new User();
            user = user.SearchUser(Convert.ToInt32(TextBoxUsername.Text));

            if (user != null && (user.Password).ToUpper() == TextBoxPassword.Text.ToUpper())
            {
                if (Validator.IsCoordinator(user.Username)) //Coordinator
                {
                    Session["CoordinatorId"] = Convert.ToInt32(TextBoxUsername.Text.Trim());
                    Response.Redirect("CourseAssignment.aspx");
                }
                else  // Employee
                {
                    Session["EmployeeNumber"] = Convert.ToInt32(TextBoxUsername.Text.Trim());
                    Response.Redirect("CoursesListAssigned.aspx");
                }
            }
            else
            {
                MessageBox.Show("Invalid UserName or Password!", "Invalid credentials");
                TextBoxUsername.Text = string.Empty;
                TextBoxPassword.Text = string.Empty;
                TextBoxUsername.Focus();
            } 

        }
    
    }
}