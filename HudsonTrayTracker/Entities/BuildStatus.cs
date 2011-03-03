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
    }

    [DebuggerDisplay("Status={Value}, Stuck={IsStuck}")]
    public class BuildStatus
    {
        public static BuildStatus UNKNOWN_BUILD_STATUS = new BuildStatus(BuildStatusEnum.Unknown, false);

        public readonly BuildStatusEnum Value;
        public readonly bool IsInProgress;
        public readonly bool IsStuck;

        public BuildStatus(BuildStatusEnum value, bool isStuck)
        {
            this.Value = value;
            this.IsStuck = isStuck;
        }

        public string Key
        {
            get
            {
                string res = Value.ToString();
                if (IsInProgress)
                    res += "_BuildInProgress";
                if (IsStuck)
                    res += "_Stuck";
                return res;
            }
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

        public static BuildStatus GetBuildInProgress(BuildStatus status)
        {
            BuildStatusEnum newValue = GetBuildInProgress(status.Value);
            return new BuildStatus(newValue, status.IsStuck);
        }
        public static BuildStatusEnum GetBuildInProgress(BuildStatusEnum status)
        {
            // don't switch if the status is already a build-in-progress status
            if (BuildStatusUtils.IsBuildInProgress(status)
                || status == BuildStatusEnum.Unknown)
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
