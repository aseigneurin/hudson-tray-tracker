using System;
using System.Collections.Generic;
using System.Text;

namespace Hudson.TrayTracker.Entities
{
    public class Project : IComparable<Project>
    {
        public Server Server{ get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public AllBuildDetails AllBuildDetails { get; set; }

        public BuildStatus Status
        {
            get
            {
                // get a copy of the reference to avoid a race condition
                AllBuildDetails details = this.AllBuildDetails;
                if (details == null)
                    return BuildStatus.Unknown;
                return details.Status;
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
