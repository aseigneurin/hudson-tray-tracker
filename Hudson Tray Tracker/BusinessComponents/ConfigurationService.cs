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

        public ISet<Server> Servers
        {
            get { return servers; }
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
        }

        private void SaveConfiguration()
        {
            // save the servers
            int serverCount = servers.Count;
            int serverId = 0;
            foreach (Server server in servers)
            {
                propertiesFile.SetGroupStringValue("servers", serverId, "url", server.Url);
                serverId++;
            }
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
            propertiesFile.SetGroupCount("projects", projectId);

            propertiesFile.WriteProperties();

            if (ConfigurationUpdated != null)
                ConfigurationUpdated();
        }

        public Server AddServer(string url)
        {
            Server server = new Server();
            server.Url = url;
            bool added = servers.Add(server);
            if (added == false)
                return null;

            SaveConfiguration();
            return server;
        }

        public void RemoveServer(Server server)
        {
            servers.Remove(server);
            SaveConfiguration();
        }

        public void AddProject(Project project)
        {
            Server server = project.Server;
            server.Projects.Add(project);
            SaveConfiguration();
        }

        public void RemoveProject(Project project)
        {
            Server server = project.Server;
            server.Projects.Remove(project);
            SaveConfiguration();
        }
    }
}
