using System;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Windows.Forms;

namespace HudsonTrayTracker.Setup.CustomActions
{
    [RunInstaller(true)]
    public class ApplicationInstaller : Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            MessageBox.Show("ApplicationInstaller[Install]");
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);

            MessageBox.Show("ApplicationInstaller[Uninstall]: stopping all instances of the application");

            Process[] processes = Process.GetProcessesByName("HudsonTrayTracker");
            MessageBox.Show("ApplicationInstaller[Uninstall]: found " + processes.Length + " instances to stop");

            foreach (Process process in processes)
            {
                MessageBox.Show("ApplicationInstaller[Uninstall]: Stopping process id: " + process.Id);
                try
                {
                    process.Kill();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ApplicationInstaller[Uninstall]: Failed stopping process: "
                        + ex.Message + "\n" + ex.StackTrace);
                }
            }

            MessageBox.Show("ApplicationInstaller[Uninstall]: done");
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            MessageBox.Show("ApplicationInstaller[Commit]");
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
            MessageBox.Show("ApplicationInstaller[Rollback]");
        }
    }
}
