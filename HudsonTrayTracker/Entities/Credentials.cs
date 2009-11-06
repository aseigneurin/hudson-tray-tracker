using System;
using System.Collections.Generic;
using System.Text;

namespace Hudson.TrayTracker.Entities
{
    public class Credentials
    {
        string username;
        string password;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Credentials()
        {
        }

        public Credentials(string username, string password)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (password == null)
                password = "";
            this.username = username;
            this.password = password;
        }
    }
}
