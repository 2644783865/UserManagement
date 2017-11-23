using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinformConsumer
{
    public partial class TestLogin : Form
    {
        public TestLogin()
        {
            InitializeComponent();
        }

        private void toolStripButtonLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void TestLogin_Shown(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            // ASSUME PREVIOUS USER LOGGED IN WAS ME
            Models.LoginViewModels.ValidUser vu = new Models.LoginViewModels.ValidUser();
            // somehow you need to pass me something back from WinformConsumer.Login, so that I can cast it to vu, above;
            WinformConsumer.Login loginForm = new WinformConsumer.Login("stuart@hutchinsonengineering.co.uk")
            {
                MdiParent = this
            };
            loginForm.Show();
        }

    }
}
