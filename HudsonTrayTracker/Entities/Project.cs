using System;
using System.Collections.Generic;
using System.Text;

namespace Hudson.TrayTracker.Entities
{
    public class Project : IComparable<Project>
    {
        Server server;
        string name;
        string url;
        AllBuildDetails allBuildDetails;

        public Server Server
        {
            get { return server; }
            set { server = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public AllBuildDetails AllBuildDetails
        {
            get { return allBuildDetails; }
            set { allBuildDetails = value; }
        }

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
            return name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Project other = obj as Project;
            if (other == null)
                return false;
            return other.server.Equals(server)
                && other.name == name;
        }

        public override string ToString()
        {
            return name;
        }

        public int CompareTo(Project other)
        {
            return name.CompareTo(other.name);
        }
    }
}
