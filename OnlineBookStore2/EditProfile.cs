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
    public partial class EditProfile : MetroForm
    {
        private string username;
        public EditProfile(String username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }
    }
}
