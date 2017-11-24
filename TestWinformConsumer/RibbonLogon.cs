using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace TestWinformConsumer
{
    public partial class RibbonLogon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonLogon()
        {
            InitializeComponent();
        }

        private void Login()
        {
            // ASSUME PREVIOUS USER LOGGED IN WAS ME
            Models.LoginViewModels.ValidUser vu = new Models.LoginViewModels.ValidUser();
            // somehow you need to pass me something back from WinformConsumer.Login, so that I can cast it to vu, above;
            WinformConsumer.Login loginForm = new WinformConsumer.Login("stuart@hutchinsonengineering.co.uk");
            loginForm.Show();
        }

        private void RibbonForm1_Shown(object sender, EventArgs e)
        {
            Login();
            var d = this.tabbedView1.AddDocument(new UserControl());
            d.Caption = "Some Document e.g. Purchase Order";
            var d1 = this.tabbedView1.AddDocument(new UserControl());
            d1.Caption = "Some Other Document";
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (DevExpress.XtraEditors.ColorWheel.ColorWheelForm f = new DevExpress.XtraEditors.ColorWheel.ColorWheelForm())
            {
                f.ShowDialog(this);
            }
        }

        private void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
        }
    }
}