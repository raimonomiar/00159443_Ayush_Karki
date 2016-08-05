using MaterialSkin;
using MaterialSkin.Controls;
using BusinessAccessLayer;
using BusinessEntityLayer;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookStore2
{
    public partial class LogInForm : MaterialForm
    {
        public LogInForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
            
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
           

            try
            {

                var ui = new UserInfo();
                ui.username = txtUsername.Text;
                ui.password = txtPassword.Text;
                if (chkRemember.Checked)
                {
                    OnlineBookStore2.Properties.Settings.Default.username = txtUsername.Text;
                    OnlineBookStore2.Properties.Settings.Default.password = txtPassword.Text;
                    OnlineBookStore2.Properties.Settings.Default.Save();

                }
                var uo = new UserOperation();
                if (uo.Login(ui) == 0)
                {
                    MyMessageBox.ShowBox("Please enter username and password!!", "Alert");
                }
                else if (uo.Login(ui) == 1)
                {
                    this.Hide();
                    var md = new MainDashboard(ui.username);
                    md.Show();
                }
                else
                    MyMessageBox.ShowBox("Username or password invalid!!", "Alert");

            }
            catch (Exception ex)
            {

                MyMessageBox.ShowBox(ex.Message);
            }
            
        }

        private void btnClickHere_Click(object sender, EventArgs e)
        {

            var reg = new Registration();
            reg.Show();

        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = OnlineBookStore2.Properties.Settings.Default.username;
            txtPassword.Text = OnlineBookStore2.Properties.Settings.Default.password;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
      
        }
    }
}
