using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Hudson.TrayTracker.Entities
{
    public enum BuildStatusEnum
    {
        Unknown,
        Disabled,
        Aborted,
        Successful,
        Indeterminate,
        Unstable,
        Failed,
    }

    [DebuggerDisplay("Status={Value}, Stuck={IsStuck}")]
    public class BuildStatus
    {
        public static BuildStatus UNKNOWN_BUILD_STATUS = new BuildStatus(BuildStatusEnum.Unknown, false, false);

        public readonly BuildStatusEnum Value;
        public readonly bool IsInProgress;
        public readonly bool IsStuck;

        public BuildStatus(BuildStatusEnum value, bool isInProgress, bool isStuck)
        {
            if (value < BuildStatusEnum.Successful)
                isInProgress = false;

            this.Value = value;
            this.IsInProgress = isInProgress;
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
        public static bool IsWorse(BuildStatus status, BuildStatus thanStatus)
        {
            bool res = status.Value > thanStatus.Value;
            return res;
        }

        public static BuildStatus DegradeStatus(BuildStatus status)
        {
            return new BuildStatus(status.Value, false, status.IsStuck);
        }

        public static bool IsErrorBuild(BuildStatus status)
        {
            return IsErrorBuild(status.Value);
        }
        public static bool IsErrorBuild(BuildStatusEnum status)
        {
            return status == BuildStatusEnum.Failed;
        }
    }
}
