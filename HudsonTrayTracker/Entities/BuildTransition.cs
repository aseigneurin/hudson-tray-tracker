using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hudson.TrayTracker.Entities
{
    public class BuildTransition
    {
        public static readonly BuildTransition Broken = new BuildTransition("Broken build", ToolTipIcon.Error);                     //  null, Unstable, Success -> Failure
        public static readonly BuildTransition Fixed = new BuildTransition("Fixed build", ToolTipIcon.Info);                        //  Failure, Unstable -> Success
        public static readonly BuildTransition Unstable = new BuildTransition("Unstable build", ToolTipIcon.Warning);               //  null, Failure, Success -> Unstable
        public static readonly BuildTransition Aborted = new BuildTransition("Aborted build", ToolTipIcon.Warning);                 //  * -> Aborted
        public static readonly BuildTransition StillUnstable = new BuildTransition("Build still unstable", ToolTipIcon.Warning);    //  Unstable -> Unstable
        public static readonly BuildTransition StillSuccessful = new BuildTransition("Build successful", ToolTipIcon.Info);         //  null, Success -> Success
        public static readonly BuildTransition StillFailing = new BuildTransition("Build still failing", ToolTipIcon.Error);        //  Failure -> Failure

        private readonly string caption;
        private readonly ToolTipIcon icon;

        private BuildTransition(string caption, ToolTipIcon icon)
        {
            this.caption = caption;
            this.icon = icon;
        }

        public ToolTipIcon Icon
        {
            get { return icon; }
        }

        public override string ToString()
        {
            return caption;
        }
    }
}
