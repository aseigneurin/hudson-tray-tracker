using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Hudson.TrayTracker.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Project : IComparable<Project>
    {
        public Server Server { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        public AllBuildDetails AllBuildDetails { get; set; }

        public BuildStatus Status
        {
            get
            {
                // get a copy of the reference to avoid a race condition
                AllBuildDetails details = this.AllBuildDetails;
                if (details == null)
                    return BuildStatus.UNKNOWN_BUILD_STATUS;
                return details.Status;
            }
        }

        public BuildStatusEnum StatusValue
        {
            get { return Status.Value; }
        }

        public BuildDetails LastBuild
        {
            get
            {
                // get a copy of the reference to avoid a race condition
                AllBuildDetails details = this.AllBuildDetails;
                if (details == null)
                    return null;
                return details.LastBuild;
            }
        }

        public BuildDetails LastSuccessfulBuild
        {
            get
            {
                // get a copy of the reference to avoid a race condition
                AllBuildDetails details = this.AllBuildDetails;
                if (details == null)
                    return null;
                return details.LastSuccessfulBuild;
            }
        }

        public BuildDetails LastFailedBuild
        {
            get
            {
                // get a copy of the reference to avoid a race condition
                AllBuildDetails details = this.AllBuildDetails;
                if (details == null)
                    return null;
                return details.LastFailedBuild;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Project other = obj as Project;
            if (other == null)
                return false;
            return other.Server.Equals(Server)
                && other.Name == Name;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Project other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
