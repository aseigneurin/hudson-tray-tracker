using System;
using System.Collections.Generic;
using System.Text;

namespace Hudson.TrayTracker.Entities
{
    public enum BuildStatus
    {
        Unknown,
        Successful,
        Successful_BuildInProgress,
        Indeterminate,
        Indeterminate_BuildInProgress,
        Unstable,
        Unstable_BuildInProgress,
        Failed,
        Failed_BuildInProgress
    }

    public static class BuildStatusUtils
    {
        public static bool IsBuildInProgress(BuildStatus status)
        {
            return (status == BuildStatus.Successful_BuildInProgress
                || status == BuildStatus.Indeterminate_BuildInProgress
                || status == BuildStatus.Unstable_BuildInProgress
                || status == BuildStatus.Failed_BuildInProgress);
        }

        public static bool IsWorse(BuildStatus newBuildStatus, BuildStatus oldBuildStatus)
        {
            BuildStatus newDegradedStatus = DegradeStatus(newBuildStatus);
            BuildStatus oldDegradedStatus = DegradeStatus(oldBuildStatus);
            bool res = newDegradedStatus > oldDegradedStatus;
            return res;
        }

        public static BuildStatus DegradeStatus(BuildStatus status)
        {
            if (status == BuildStatus.Successful_BuildInProgress)
                return BuildStatus.Successful;
            if (status == BuildStatus.Indeterminate_BuildInProgress)
                return BuildStatus.Indeterminate;
            if (status == BuildStatus.Unstable_BuildInProgress)
                return BuildStatus.Unstable;
            if (status == BuildStatus.Failed_BuildInProgress)
                return BuildStatus.Failed;
            return status;
        }
    }
}
