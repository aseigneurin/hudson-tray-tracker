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
        Failed_BuildInProgress,
        Blocked,
        Stuck
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

        public static BuildStatus GetBuildInProgress(BuildStatus status)
        {
            // don't switch if the status is already a build-in-progress status
            if (BuildStatusUtils.IsBuildInProgress(status)
                || status == BuildStatus.Unknown
                || status == BuildStatus.Blocked
                || status == BuildStatus.Stuck)
                return status;
            return status + 1;
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
