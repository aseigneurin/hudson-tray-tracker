using System;
using System.Collections.Generic;
using System.Text;

namespace Hudson.TrayTracker.Entities
{
    public enum BuildStatus
    {
        Successful,
        Successful_BuildInProgress,
        Indeterminate,
        Indeterminate_BuildInProgress,
        Unstable,
        Unstable_BuildInProgress,
        Failed,
        Failed_BuildInProgress
    }
}
