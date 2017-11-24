using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformConsumer
{
    
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        private string userName;
        public Login(string userID)
        {
            userName = userID;
            SetBrowserFeatureControl();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoNavigationAsync().ContinueWith(_ =>
            {
               // MessageBox.Show("Navigation complete!");
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async Task DoNavigationAsync()
        {
            TaskCompletionSource<bool> documentCompleteTcs = null;

            WebBrowserDocumentCompletedEventHandler handler = delegate
            {
                if (documentCompleteTcs.Task.IsCompleted)
                    return;
                documentCompleteTcs.SetResult(true);
            };

            documentCompleteTcs = new TaskCompletionSource<bool>();
            this.wb.DocumentCompleted += handler;

               this.wb.Navigate (string.Format("https://remote.hutchinsonengineering.co.uk/klogon?user={0}", userName));

            await documentCompleteTcs.Task;
            this.wb.DocumentCompleted -= handler;

                      
        }

        private static void SetBrowserFeatureControl()
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // WebBrowser Feature Control settings are per-process
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                return;

            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode());
        }

        private static void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
            }
        }

        private static UInt32 GetBrowserEmulationMode()
        {
            int browserVersion = 7;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode. Default value for Internet Explorer 10.
            UInt32 mode = 10000;

            switch (browserVersion)
            {
                case 7:
                    // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                    mode = 7000;
                    break;
                case 8:
                    // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                    mode = 8000;
                    break;
                case 9:
                    // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                    mode = 9000;
                    break;
                default:
                    // use IE10 mode by default
                    break;
            }

            return mode;
        }

        private void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
         
        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().Contains("/Success?")) {
                System.Windows.Forms.HtmlDocument document = this.wb.Document;
                
                string em = document.All["user_email"].GetAttribute("value");
                string pw = document.All["user_password"].GetAttribute("value");
                
                //if (document != null && document.All["result"] != null && !String.IsNullOrEmpty(document.All["result"].GetAttribute("value")))
                //{
                //}
            }
        }
    }
}
