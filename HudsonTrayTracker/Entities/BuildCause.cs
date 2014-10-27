using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Iesi.Collections.Generic;

namespace Hudson.TrayTracker.Entities
{
    public enum BuildCauseEnum
    {
        Unknown,
        SCM,
        Timer,
        User,
        UpstreamProject,
        RemoteHost
    }

    public class BuildCause
    {
        public string ShortDescription { get; set; }
        public string Starter { get; set; }
        public BuildCauseEnum Cause;

        public BuildCause()
        {

        }
    }

    public class BuildCauses
    {
        public ISet<BuildCause> Causes;
        public string Summary { get; set; }

        public BuildCauses()
        {
            Causes = new HashedSet<BuildCause>();
        }

        public static void FillInBuildCauses(BuildDetails res, XmlDocument xml)
        {
            XmlNodeList causes = xml.SelectNodes("/*/action/cause");
            foreach (XmlNode causeNode in causes)
            {
                string causeShortDesc = causeNode["shortDescription"].InnerText;
                BuildCause cause = new BuildCause();
                cause.ShortDescription = causeShortDesc;
                if (causeShortDesc.StartsWith("Started by user"))
                {
                    cause.Cause = BuildCauseEnum.User;
                    var userId = causeNode["userId"];
                    cause.Starter = userId != null ? userId.ToString() : "";
                }
                else if (causeShortDesc.StartsWith("Started by Timer", StringComparison.CurrentCultureIgnoreCase))
                {
                    cause.Cause = BuildCauseEnum.Timer;
                }
                else if (causeShortDesc.StartsWith("Started by Upstream Project", StringComparison.CurrentCultureIgnoreCase))
                {
                    cause.Cause = BuildCauseEnum.UpstreamProject;
                }
                else if (causeShortDesc.StartsWith("Started by SCM Changes", StringComparison.CurrentCultureIgnoreCase))
                {
                    cause.Cause = BuildCauseEnum.SCM;
                }
                else if (causeShortDesc.StartsWith("Started by Remote Host", StringComparison.CurrentCultureIgnoreCase))
                {
                    cause.Cause = BuildCauseEnum.RemoteHost;
                }
                else
                {
                    cause.Cause = BuildCauseEnum.Unknown;
                }
                res.Causes.Causes.Add(cause);
            }
        }
    }
}
