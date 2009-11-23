using System;
using System.Collections.Generic;
using System.Text;
using Hudson.TrayTracker.Entities;
using Iesi.Collections.Generic;
using Hudson.TrayTracker.Utils.IO;
using System.IO;
using System.Reflection;
using Dotnet.Commons.Logging;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class ConfigurationService
    {
        public delegate void ConfigurationUpdatedHandler();
        public event ConfigurationUpdatedHandler ConfigurationUpdated;

        static readonly ILog logger = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private const string HUDSON_TRAY_TRACKER_DIRECTORY = "Hudson Tray Tracker";
        private const string PROPERTIES_FILE = "hudson.properties";

        PropertiesFile propertiesFile;
        ISet<Server> servers = new HashedSet<Server>();
        NotificationSounds notificationSounds;

        public ISet<Server> Servers
        {
            get { return servers; }
        }

        public NotificationSounds NotificationSounds
        {
            get { return notificationSounds; }
        }

        public ConfigurationService()
        {
            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            string userAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string userAppDataPath = PathHelper.Combine(userAppDataDir, HUDSON_TRAY_TRACKER_DIRECTORY);
            string userConfigurationFile = PathHelper.Combine(userAppDataPath, PROPERTIES_FILE);

            // create the directory in case it does not exist
            Directory.CreateDirectory(userAppDataPath);

            // read the properties file
            propertiesFile = PropertiesFile.ReadPropertiesFile(userConfigurationFile);

            // load the servers
            Dictionary<int, Server> serverMap = new Dictionary<int, Server>();
            int serverCount = propertiesFile.GetGroupCount("servers");
            for (int serverId = 0; serverId < serverCount; serverId++)
            {
                // read the server configuration
                Server server = new Server();
                server.Url = propertiesFile.GetGroupRequiredStringValue("servers", serverId, "url");

                // credentials
                string username = propertiesFile.GetGroupStringValue("servers", serverId, "username");
                if (username != null)
                {
                    string passwordBase64 = propertiesFile.GetGroupRequiredStringValue("servers", serverId, "passwordBase64");
                    string password = Encoding.UTF8.GetString(Convert.FromBase64String(passwordBase64));
                    server.Credentials = new Credentials(username, password);
                }

                // keep the server
                servers.Add(server);

                // temporary keep for projects loading
                serverMap.Add(serverId, server);
            }

            // load the projects
            int projectCount = propertiesFile.GetGroupCount("projects");
            for (int projectId = 0; projectId < projectCount; projectId++)
            {
                // read the project configuration
                int serverId = propertiesFile.GetGroupRequiredIntValue("projects", projectId, "server");
                Server server = serverMap[serverId];
                Project project = new Project();
                project.Server = server;
                project.Name = propertiesFile.GetGroupRequiredStringValue("projects", projectId, "name");
                project.Url = propertiesFile.GetGroupRequiredStringValue("projects", projectId, "url");

                // keep the project
                server.Projects.Add(project);
            }

            LoadNotificationSounds();
        }

        private void LoadNotificationSounds()
        {
            notificationSounds = new NotificationSounds();
            notificationSounds.FailedSoundPath = propertiesFile.GetGroupStringValue("sound", 0, "failed");
            notificationSounds.FixedSoundPath = propertiesFile.GetGroupStringValue("sound", 0, "fixed");
            notificationSounds.StillFailingSoundPath = propertiesFile.GetGroupStringValue("sound", 0, "stillfailing");
            notificationSounds.SucceededSoundPath = propertiesFile.GetGroupStringValue("sound", 0, "succeeded");
        }

        private void SaveConfiguration()
        {
            // clear to remove old values
            propertiesFile.Clear();

            // save the servers
            int serverId = 0;
            foreach (Server server in servers)
            {
                propertiesFile.SetGroupStringValue("servers", serverId, "url", server.Url);
                Credentials credentials = server.Credentials;
                if (credentials != null)
                {
                    propertiesFile.SetGroupStringValue("servers", serverId, "username", credentials.Username);
                    string passwordBase64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials.Password));
                    propertiesFile.SetGroupStringValue("servers", serverId, "passwordBase64", passwordBase64);
                }
                serverId++;
            }
            if (serverId > 0)
                propertiesFile.SetGroupCount("servers", serverId);

            // save the projects
            serverId = 0;
            int projectId = 0;
            foreach (Server server in servers)
            {
                foreach (Project project in server.Projects)
                {
                    propertiesFile.SetGroupIntValue("projects", projectId, "server", serverId);
                    propertiesFile.SetGroupStringValue("projects", projectId, "name", project.Name);
                    propertiesFile.SetGroupStringValue("projects", projectId, "url", project.Url);
                    projectId++;
                }
                serverId++;
            }
            if (projectId > 0)
                propertiesFile.SetGroupCount("projects", projectId);

            SaveNotificationSounds();

            propertiesFile.WriteProperties();

            if (ConfigurationUpdated != null)
                ConfigurationUpdated();
        }

        private void SaveNotificationSounds()
        {
            SaveNotificationSound("failed", notificationSounds.FailedSoundPath);
            SaveNotificationSound("fixed", notificationSounds.FixedSoundPath);
            SaveNotificationSound("stillfailing", notificationSounds.StillFailingSoundPath);
            SaveNotificationSound("succeeded", notificationSounds.SucceededSoundPath);
        }

        private void SaveNotificationSound(string key, string value)
        {
            propertiesFile.SetGroupStringValue("sound", 0, key, value);
        }

        public Server AddServer(string url, string username, string password)
        {
            Server server = new Server();
            BindData(server, url, username, password);
            servers.Add(server);
            SaveConfiguration();
            return server;
        }

        public void UpdateServer(Server server, string url, string username, string password)
        {
            // note: we need remove and re-add the server because its hash-code might change
            servers.Remove(server);
            BindData(server, url, username, password);
            servers.Add(server);
            SaveConfiguration();
        }

        private void BindData(Server server, string url, string username, string password)
        {
            server.Url = url;
            if (String.IsNullOrEmpty(username) == false)
                server.Credentials = new Credentials(username, password);
            else
                server.Credentials = null;
        }

        public void RemoveServer(Server server)
        {
            servers.Remove(server);
            SaveConfiguration();
        }

        public void AddProject(Project project)
        {
            DoAddProject(project);
            SaveConfiguration();
        }

        public void AddProjects(IList<Project> projects)
        {
            foreach (Project project in projects)
                DoAddProject(project);
            SaveConfiguration();
        }

        private void DoAddProject(Project project)
        {
            Server server = project.Server;
            server.Projects.Add(project);
        }

        public void RemoveProject(Project project)
        {
            DoRemoveProject(project);
            SaveConfiguration();
        }

        public void RemoveProjects(IList<Project> projects)
        {
            foreach (Project project in projects)
                DoRemoveProject(project);
            SaveConfiguration();
        }

        private void DoRemoveProject(Project project)
        {
            Server server = project.Server;
            server.Projects.Remove(project);
        }

        public IDictionary<Server, ISet<Project>> GetProjects()
        {
            IDictionary<Server, ISet<Project>> res = new Dictionary<Server, ISet<Project>>();
            foreach (Server server in Servers)
            {
                ISet<Project> projects = new HashedSet<Project>();
                foreach (Project project in server.Projects)
                    projects.Add(project);
                res[server] = projects;
            }
            return res;
        }
    }
}
