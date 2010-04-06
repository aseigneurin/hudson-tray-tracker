using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Common.Logging;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Hudson.TrayTracker.Utils
{
    public static class UIUtils
    {
        public static void OpenWebPage(string url, ILog logger)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                logger.Warn("Failed opening page: " + url, ex);

                string errorMessage = String.Format(HudsonTrayTrackerResources.ErrorBoxMessage, ex.Message);
                XtraMessageBox.Show(errorMessage, HudsonTrayTrackerResources.ErrorBoxCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
