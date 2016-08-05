using MaterialSkin.Controls;
using BusinessEntityLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookStore2
{
    public partial class Registration : MaterialForm
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var usernameRegex = new Regex("^[a-zA-Z][a-zA-Z0-9]{5,16}$");
                var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
                var addressRegex = new Regex(@"^[\p{L} \.\-]+$");
                var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                var phoneRegex = new Regex(@"^\d{10}$");
                if (!usernameRegex.IsMatch(txtUsername.Text))
                {
                    errUsername.SetError(txtUsername, "Enter valid username at least 5 digit");
                }
                else if (!passwordRegex.IsMatch(txtPassword.Text))
                {
                    errUsername.Clear();
                    errPassword.SetError(txtPassword, "Enter Valid password should contain atleast one upper and lowercase letter");
                
                }
                else if (!emailRegex.IsMatch(txtEmail.Text))
                {
                    errPassword.Clear();
                    errEmail.SetError(txtEmail, "Enter a valid email!!");
                }
                else if (!phoneRegex.IsMatch(txtPhone.Text))
                {
                    errEmail.Clear();
                    errPhone.SetError(txtPhone, "Enter a valid 10 digit no.");
                }
                else
                {
                    errPhone.Clear();
                    var ui = new UserInfo();
                    ui.username = txtUsername.Text;
                    ui.first_name = txtFname.Text;
                    ui.last_name = txtLname.Text;
                    ui.address = txtAddress.Text;
                    ui.phone_no = Convert.ToInt64(txtPhone.Text);
                    ui.email = txtEmail.Text;
                    ui.dob = txtDob.Text;
                    ui.password = txtPassword.Text;

                    if (radMale.Checked)
                    {
                        ui.gender = radMale.Text;
                    }
                    else if (radFemale.Checked)
                    {
                        ui.gender = radFemale.Text;
                    }
                    else
                        ui.gender = radOther.Text;

                    var db = new DbConnection();

                    if (db.insertData(ui) > 0)
                    {
                        this.Close();
                        MyMessageBox.ShowBox("Sign UP success !! LogIn Now", "Notification");
                    }
                }
            }
            catch (Exception ex)
            {

                MyMessageBox.ShowBox( ex.Message, "Alert");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
