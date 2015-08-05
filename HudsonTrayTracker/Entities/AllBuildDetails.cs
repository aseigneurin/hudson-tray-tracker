using System;
using System.Collections.Generic;
using System.Text;

namespace Hudson.TrayTracker.Entities
{
    public class AllBuildDetails
    {
        public BuildStatus Status { get; set; }
        public BuildDetails LastBuild { get; set; }
        public BuildDetails PreviousLastBuild { get; set; }
        public BuildDetails LastCompletedBuild { get; set; }
        public BuildDetails LastSuccessfulBuild { get; set; }
        public BuildDetails LastFailedBuild { get; set; }
    }
}
