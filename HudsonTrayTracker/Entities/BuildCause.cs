using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hudson.TrayTracker.Entities
{
    public enum BuildCauseEnum
    {
        Unknown,
        SCM,
        Timer,
        User,
        Upstream,
    }

    public class BuildCause
    {
        public string ShortDescription { get; set; }
        public string UpstreamBuild { get; set; }
        public string UpstreamProject { get; set; }
    }
}
