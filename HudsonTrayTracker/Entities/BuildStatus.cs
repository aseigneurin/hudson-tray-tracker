using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Hudson.TrayTracker.Entities
{
    public enum BuildStatusEnum
    {
        Unknown,
        Aborted,
        Successful,
        Successful_BuildInProgress,
        Indeterminate,
        Indeterminate_BuildInProgress,
        Unstable,
        Unstable_BuildInProgress,
        Failed,
        Failed_BuildInProgress,
        Stuck
    }

    [DebuggerDisplay("Status={Value}, Stuck={Stuck}")]
    public class BuildStatus
    {
        public readonly BuildStatusEnum Value;
        public readonly bool IsStuck;

        public BuildStatus(BuildStatusEnum value, bool isStuck)
        {
            this.Value = value;
            this.IsStuck = isStuck;
        }
    }

    public static class BuildStatusUtils
    {
        public static bool IsBuildInProgress(BuildStatus status)
        {
            return IsBuildInProgress(status.Value);
        }
        public static bool IsBuildInProgress(BuildStatusEnum status)
        {
            return (status == BuildStatusEnum.Successful_BuildInProgress
                || status == BuildStatusEnum.Indeterminate_BuildInProgress
                || status == BuildStatusEnum.Unstable_BuildInProgress
                || status == BuildStatusEnum.Failed_BuildInProgress);
        }

        public static BuildStatusEnum GetBuildInProgress(BuildStatusEnum status)
        {
            // don't switch if the status is already a build-in-progress status
            if (BuildStatusUtils.IsBuildInProgress(status)
                || status == BuildStatusEnum.Unknown
                || status == BuildStatusEnum.Stuck)
                return status;
            return status + 1;
        }

        public static bool IsWorse(BuildStatus status, BuildStatus thanStatus)
        {
            return IsWorse(status.Value, thanStatus.Value);
        }
        public static bool IsWorse(BuildStatusEnum status, BuildStatusEnum thanStatus)
        {
            BuildStatusEnum degradedStatus = DegradeStatus(status);
            BuildStatusEnum thanDegradedStatus = DegradeStatus(thanStatus);
            bool res = degradedStatus > thanDegradedStatus;
            return res;
        }

        public static BuildStatusEnum DegradeStatus(BuildStatusEnum status)
        {
            if (status == BuildStatusEnum.Successful_BuildInProgress)
                return BuildStatusEnum.Successful;
            if (status == BuildStatusEnum.Indeterminate_BuildInProgress)
                return BuildStatusEnum.Indeterminate;
            if (status == BuildStatusEnum.Unstable_BuildInProgress)
                return BuildStatusEnum.Unstable;
            if (status == BuildStatusEnum.Failed_BuildInProgress)
                return BuildStatusEnum.Failed;
            return status;
        }

        public static bool IsErrorBuild(BuildStatusEnum status)
        {
            return status == BuildStatusEnum.Failed || status == BuildStatusEnum.Failed_BuildInProgress;
        }
    }
}
