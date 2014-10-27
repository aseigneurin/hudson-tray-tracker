using System;
using System.Collections.Generic;
using System.Text;
using Iesi.Collections.Generic;

namespace Hudson.TrayTracker.Entities
{
    public class BuildDetails
    {
        public BuildCause Cause { get; set; }
        public int Number { get; set; }
        public string Url { get; set; }
        public string DisplayName { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan EstimatedDuration { get; set; }
        public ISet<string> Users { get; set; }
        public ClaimDetails ClaimDetails { get; set; }
    }
}
