using System;
using System.Collections.Generic;
using System.Text;

namespace Hudson.TrayTracker.Entities
{
    public class Project
    {
        Server server;
        string name;
        string url;
        BuildStatus status = BuildStatus.Indeterminate;
        BuildDetails lastSuccessfulBuild;
        BuildDetails lastFailedBuild;

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

        public BuildStatus Status
        {
            get { return status; }
            set { status = value; }
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
    }
}
