using System;
using System.Collections.Generic;
using System.Text;
using Iesi.Collections.Generic;

namespace Hudson.TrayTracker.Entities
{
    public class Server
    {
        string url;
        ISet<Project> projects = new HashedSet<Project>();

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public ISet<Project> Projects
        {
            get { return projects; }
        }

        public override int GetHashCode()
        {
            return url.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Server other = obj as Server;
            if (other == null)
                return false;
            return other.url == url;
        }
    }
}
