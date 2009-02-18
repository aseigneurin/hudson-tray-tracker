using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using Hudson.TrayTracker.Entities;
using Hudson.TrayTracker.Utils;
using Dotnet.Commons.Logging;
using System.Reflection;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class HudsonService
    {
        static readonly ILog logger = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IList<Project> LoadProjects(Server server)
        {
            String url = server.Url + "/api/xml";

            WebClient webClient = new WebClient();
            String xmlStr = webClient.DownloadString(url);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlStr);

            XmlNodeList jobElements = xml.SelectNodes("/hudson/job");
            IList<Project> projects = new List<Project>();
            foreach (XmlNode jobElement in jobElements)
            {
                string projectName = jobElement.SelectSingleNode("name").InnerText;
                string projectUrl = jobElement.SelectSingleNode("url").InnerText;

                Project project = new Project();
                project.Server = server;
                project.Name = projectName;
                project.Url = projectUrl;

                projects.Add(project);
            }

            return projects;
        }

        public void UpdateProject(Project project)
        {
            String url = project.Url + "/api/xml";

            WebClient webClient = new WebClient();
            String xmlStr = webClient.DownloadString(url);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlStr);

            string status = xml.SelectSingleNode("/mavenModuleSet/color").InnerText;
            string lastSuccessfulBuildUrl = XmlUtils.SelectSingleNodeText(xml, "/mavenModuleSet/lastSuccessfulBuild/url");
            string lastFailedBuildUrl = XmlUtils.SelectSingleNodeText(xml, "/mavenModuleSet/lastFailedBuild/url");

            project.Status = GetStatus(status);
            project.LastSuccessfulBuild = GetBuildDetails(lastSuccessfulBuildUrl);
            project.LastFailedBuild = GetBuildDetails(lastFailedBuildUrl);
        }

        private BuildStatus GetStatus(string status)
        {
            if (status == "grey")
                return BuildStatus.Indeterminate;
            if (status == "grey_anime")
                return BuildStatus.Indeterminate_BuildInProgress;
            if (status == "blue")
                return BuildStatus.Successful;
            if (status == "blue_anime")
                return BuildStatus.Successful_BuildInProgress;
            if (status == "yellow")
                return BuildStatus.Unstable;
            if (status == "yellow_anime")
                return BuildStatus.Unstable_BuildInProgress;
            if (status == "red")
                return BuildStatus.Failed;
            if (status == "red_anime")
                return BuildStatus.Failed_BuildInProgress;
            return BuildStatus.Indeterminate;
        }

        private BuildDetails GetBuildDetails(string buildUrl)
        {
            if (buildUrl == null)
                return null;

            String url = buildUrl + "/api/xml";

            WebClient webClient = new WebClient();
            String xmlStr = webClient.DownloadString(url);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlStr);

            string number = xml.SelectSingleNode("/mavenModuleSetBuild/number").InnerText;
            string timestamp = xml.SelectSingleNode("/mavenModuleSetBuild/timestamp").InnerText;

            TimeSpan ts = TimeSpan.FromSeconds(long.Parse(timestamp) / 1000);
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            date = date.Add(ts);

            BuildDetails res = new BuildDetails();
            res.Number = int.Parse(number);
            res.Time = date;
            return res;
        }
    }
}
