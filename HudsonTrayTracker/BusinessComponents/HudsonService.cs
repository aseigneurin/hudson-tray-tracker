using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using Hudson.TrayTracker.Entities;
using Hudson.TrayTracker.Utils;
using Dotnet.Commons.Logging;
using System.Reflection;
using Hudson.TrayTracker.Utils.Logging;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class HudsonService
    {
        static readonly ILog logger = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IList<Project> LoadProjects(Server server)
        {
            String url = server.Url + "/api/xml";

            logger.Info("Loading projects from " + url);

            WebClient webClient = new WebClient();
            String xmlStr = webClient.DownloadString(url);

            if (logger.IsTraceEnabled)
                logger.Trace("XML: " + xmlStr);

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

                if (logger.IsDebugEnabled)
                    logger.Debug("Found project " + projectName + " (" + projectUrl + ")");

                projects.Add(project);
            }

            logger.Info("Done loading projects");

            return projects;
        }

        public AllBuildDetails UpdateProject(Project project)
        {
            String url = project.Url + "/api/xml";

            logger.Info("Updating project from " + url);

            WebClient webClient = new WebClient();
            String xmlStr = webClient.DownloadString(url);

            if (logger.IsTraceEnabled)
                logger.Trace("XML: " + xmlStr);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlStr);

            string status = xml.SelectSingleNode("/*/color").InnerText;
            string lastSuccessfulBuildUrl = XmlUtils.SelectSingleNodeText(xml, "/*/lastSuccessfulBuild/url");
            string lastFailedBuildUrl = XmlUtils.SelectSingleNodeText(xml, "/*/lastFailedBuild/url");

            AllBuildDetails res = new AllBuildDetails();
            res.Status = GetStatus(status);
            res.LastSuccessfulBuild = GetBuildDetails(lastSuccessfulBuildUrl);
            res.LastFailedBuild = GetBuildDetails(lastFailedBuildUrl);

            logger.Info("Done updating project");
            return res;
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
            return BuildStatus.Unknown;
        }

        private BuildDetails GetBuildDetails(string buildUrl)
        {
            if (buildUrl == null)
                return null;

            String url = buildUrl + "/api/xml";

            logger.Info("Getting build details from " + url);

            WebClient webClient = new WebClient();
            String xmlStr = webClient.DownloadString(url);

            if (logger.IsTraceEnabled)
                logger.Trace("XML: " + xmlStr);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlStr);

            string number = xml.SelectSingleNode("/*/number").InnerText;
            string timestamp = xml.SelectSingleNode("/*/timestamp").InnerText;

            TimeSpan ts = TimeSpan.FromSeconds(long.Parse(timestamp) / 1000);
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            date = date.Add(ts);

            BuildDetails res = new BuildDetails();
            res.Number = int.Parse(number);
            res.Time = date;

            logger.Info("Done getting build details");

            return res;
        }

        public void SafeRunBuild(Project project)
        {
            try
            {
                RunBuild(project);
            }
            catch (Exception ex)
            {
                LoggingHelper.LogError(logger, ex);
            }
        }

        public void RunBuild(Project project)
        {
            String url = project.Url + "/build";

            logger.Info("Running build at " + url);

            WebClient webClient = new WebClient();
            String str = webClient.DownloadString(url);

            if (logger.IsTraceEnabled)
                logger.Trace("Result: " + str);

            logger.Info("Done running build");
        }
    }
}
