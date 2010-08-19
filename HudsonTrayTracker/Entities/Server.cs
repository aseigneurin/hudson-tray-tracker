using System;
using System.Collections.Generic;
using System.Text;
using Iesi.Collections.Generic;

namespace Hudson.TrayTracker.Entities
{
    public class Server
    {
        public string Url { get; set; }
        public Credentials Credentials { get; set; }
        public bool IgnoreUntrustedCertificate { get; set; }
        public ISet<Project> Projects { get; private set; }

        public Server()
        {
            Projects = new HashedSet<Project>();
        }

        public override int GetHashCode()
        {
            return Url.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Server other = obj as Server;
            if (other == null)
                return false;
            return other.Url == Url;
        }

        public override string ToString()
        {
            return Url;
        }
    }
}
