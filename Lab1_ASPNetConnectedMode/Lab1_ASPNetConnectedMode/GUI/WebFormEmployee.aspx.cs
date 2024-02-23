using Lab1_ASPNetConnectedMode.BLL;
using Lab1_ASPNetConnectedMode.DAL;
using Lab1_ASPNetConnectedMode.VALIDATION;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;

// State Management in ASP.Net 
// Http : Stateless
//     Client Side State Management
//         - ViewState     
//     
//     Server Side State Management
//         - Database
//         - Session State
//         - Application State

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class WebFormEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownListSearchOption.Items.Add("Employee ID");
                DropDownListSearchOption.Items.Add("First Name");
                DropDownListSearchOption.Items.Add("Last Name");
                DropDownListSearchOption.Items.Add("First Name & Last Name");
                LabelDisplay.Text = "Please enter EmployeeId";
                TextBoxInput.Focus();
                LabelDisplay2.Visible = false;
                TextBoxInput2.Visible = false;
                GridViewEmployee.HeaderStyle.ForeColor = System.Drawing.Color.Blue;
            }
        }

        protected void ButtonListAll_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            GridViewEmployee.DataSource = employee.GetEmployees();
            GridViewEmployee.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string input = "";
            Employee emp = new Employee();
            List<Employee> listE;


            switch (DropDownListSearchOption.SelectedIndex)
            {
                case 0: // EmployeeId
                    input = TextBoxInput.Text.Trim();
                    if (!Validator.IsValidId(input))
                    {
                        MessageBox.Show("EmployeeId must be 4-digit number, try again!", "Invalid EmployeeId", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = "";
                        TextBoxInput.Focus();
                        return;
                    }
                    emp = emp.SearchEmployee(Convert.ToInt32(input));

                    if (emp != null)
                    {
                        TextBoxEmployeeId.Text = emp.EmployeeID.ToString();
                        TextBoxFirstName.Text = emp.FirstName;
                        TextBoxLastName.Text = emp.LastName;
                        TextBoxJobTitle.Text = emp.JobTitle;

                        TextBoxInput.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("EmployeeId must be 4-digit number, try again!", "Invalid EmployeeId", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = "";
                        TextBoxInput.Focus();
                        return;
                    }

                    break;
                case 1: // First Name
                    input = TextBoxInput.Text.Trim();
                    if (!Validator.IsValidName(input))
                    {
                        MessageBox.Show("Invalid First Name\n" + "Please enter another name", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = "";
                        TextBoxInput.Focus();
                        return;
                    }

                    listE = emp.SearchEmployee(input);

                    if (listE.Count != 0)
                    {
                        GridViewEmployee.DataSource = listE;
                        GridViewEmployee.DataBind();
                        TextBoxInput.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Employee not found", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxInput.Text = "";
                        TextBoxInput.Focus();
                        return;
                    }

                    break;
                default:
                    break;
            }
            
        }

        protected void DropDownListSearchOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownListSearchOption.SelectedIndex)
            {
                case 0:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter Employee ID :";
                    }
                    LabelDisplay.Text = Session["message"].ToString();
                    TextBoxInput.Focus();
                    LabelDisplay2.Visible = false;
                    TextBoxInput2.Visible = false;

                    break;
                case 1:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter First Name :";
                    }
                    LabelDisplay.Text = Session["message"].ToString();
                    TextBoxInput.Focus();
                    LabelDisplay2.Visible = false;
                    TextBoxInput2.Visible = false;
                    break;
                case 2:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter Last Name :";
                    }
                    LabelDisplay.Text = Session["message"].ToString();
                    TextBoxInput.Focus();
                    LabelDisplay2.Visible = false;
                    TextBoxInput2.Visible = false;
                    break;
                case 3:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter First and Last Name:";
                    }
                    LabelDisplay.Text = Session["message"].ToString();
                    TextBoxInput.Focus();
                    LabelDisplay2.Visible = true;
                    TextBoxInput2.Visible = true;
                    break;
                default:
                    break;
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            // Validate:
            // id = 4-digits, unique
            // FN, LS, JT


            string input = TextBoxEmployeeId.Text;

            if (Validator.IsValidId(input,4))
            {
                int employeeId = Convert.ToInt32(TextBoxEmployeeId.Text.Trim());
                string firstName = TextBoxFirstName.Text.Trim();
                string lastName = TextBoxLastName.Text.Trim();
                string jobTitle = TextBoxJobTitle.Text.Trim();

                Employee newEmployee = new Employee
                {
                    EmployeeID = employeeId,
                    FirstName = firstName,
                    LastName = lastName,
                    JobTitle = jobTitle
                };

                EmployeeDB.SaveRecord(newEmployee);

                MessageBox.Show("Employee Registered!");
                CleanTextFields();

                // redraw Gridview
                ButtonListAll_Click(sender, e);

            }else
            {
                MessageBox.Show("EmployeeId format wrong, try again!");
                TextBoxEmployeeId.Focus();
            }
}

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string input = TextBoxEmployeeId.Text;

            if (Validator.IsValidId(input))
            {
                int employeeId = Convert.ToInt32(TextBoxEmployeeId.Text.Trim());
                string firstName = TextBoxFirstName.Text.Trim();
                string lastName = TextBoxLastName.Text.Trim();
                string jobTitle = TextBoxJobTitle.Text.Trim();

                Employee updatedEmployee = new Employee
                {
                    EmployeeID = employeeId,
                    FirstName = firstName,
                    LastName = lastName,
                    JobTitle = jobTitle
                };

                updatedEmployee.UpdateEmployee(updatedEmployee);

                MessageBox.Show("Employee has been updated sucessfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CleanTextFields();

                // redraw Gridview
                ButtonListAll_Click(sender, e);
            }else
            {
                MessageBox.Show("EmployeeId format wrong, try again!");
                TextBoxEmployeeId.Focus();

            }

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

            //if ((MessageBox.Show("Do you confirm the deletion of the record?", "Confirm delete", MessageBoxButtons.YesNo) == "YES"){
                int employeeId = Convert.ToInt32(TextBoxEmployeeId.Text);

                EmployeeDB.DeleteRecord(employeeId);

                MessageBox.Show("Employee Deleted!");
            //}


            CleanTextFields();

            // redraw Gridview
            ButtonListAll_Click(sender, e);

        }

        public void CleanTextFields()
        {
            TextBoxEmployeeId.Text = "";
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxJobTitle.Text = "";
            TextBoxInput.Text = "";
            TextBoxInput2.Text = "";

        }

    }
}