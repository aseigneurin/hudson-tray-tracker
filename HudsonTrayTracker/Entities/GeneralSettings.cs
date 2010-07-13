using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hudson.TrayTracker.Entities
{
    public class GeneralSettings
    {
        public int RefreshIntervalInSeconds { get; set; }
        public bool UpdateMainWindowIcon { get; set; }
        public bool IntegrateWithClaimPlugin { get; set; }
    }
}
