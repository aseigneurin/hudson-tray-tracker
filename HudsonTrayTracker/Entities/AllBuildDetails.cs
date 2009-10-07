using System;
using System.Collections.Generic;
using System.Text;

namespace Hudson.TrayTracker.Entities
{
    public class AllBuildDetails
    {
        BuildStatus status = BuildStatus.Unknown;
        BuildDetails lastBuild;
        BuildDetails lastCompletedBuild;
        BuildDetails lastSuccessfulBuild;
        BuildDetails lastFailedBuild;

        public BuildStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public BuildDetails LastCompletedBuild
        {
            get { return lastCompletedBuild; }
            set { lastCompletedBuild = value; }
        }

        public BuildDetails LastSuccessfulBuild
        {
            get { return lastSuccessfulBuild; }
            set { lastSuccessfulBuild = value; }
        }

        public BuildDetails LastFailedBuild
        {
            get { return lastFailedBuild; }
            set { lastFailedBuild = value; }
        }
    }
}
