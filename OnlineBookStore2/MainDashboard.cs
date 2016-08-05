using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework.Forms;
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
    public partial class MainDashboard : MetroForm
    {

        public MainDashboard(string username)
        {
            InitializeComponent();
            this.lblUsername.Text = username;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void lnkClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LogInForm().Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            
            
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            btnDashboard.Select();

        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();
            var d = new Category();
            metroPanel2.Controls.Add(d);
        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();
            var t = new Trade();
            metroPanel2.Controls.Add(t);
        }

        private void lnkSetting_Click(object sender, EventArgs e)
        {
            this.ctxSetting.Show(lnkSetting, 0, lnkSetting.Height);
        }

        private void menuEditProfile_Click(object sender, EventArgs e)
        {
            var ep = new EditProfile(lblUsername.Text);
            ep.Show();
        }
    }
}
