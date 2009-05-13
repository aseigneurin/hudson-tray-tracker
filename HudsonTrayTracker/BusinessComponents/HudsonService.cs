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
using Iesi.Collections.Generic;
using Hudson.TrayTracker.Utils.Web;
using System.Threading;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class HudsonService
    {
        static readonly ILog logger = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [ThreadStatic]
        static WebClient threadWebClient;

        // cache: key=url, value=xml
        IDictionary<string, string> cache = new Dictionary<string, string>();
        // URLs visited between 2 calls to RecycleCache()
        ISet<string> visitedURLs = new HashedSet<string>();

        public IList<Project> LoadProjects(Server server)
        {
            String url = server.Url + "/api/xml";

            logger.Info("Loading projects from " + url);

            String xmlStr = DownloadString(url, false);

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

            String xmlStr = DownloadString(url, false);

            if (logger.IsTraceEnabled)
                logger.Trace("XML: " + xmlStr);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlStr);

            string status = xml.SelectSingleNode("/*/color").InnerText;
            string lastBuildUrl = XmlUtils.SelectSingleNodeText(xml, "/*/lastBuild/url");
            string lastCompletedBuildUrl = XmlUtils.SelectSingleNodeText(xml, "/*/lastCompletedBuild/url");
            string lastSuccessfulBuildUrl = XmlUtils.SelectSingleNodeText(xml, "/*/lastSuccessfulBuild/url");
            string lastFailedBuildUrl = XmlUtils.SelectSingleNodeText(xml, "/*/lastFailedBuild/url");
            bool? stuck = XmlUtils.SelectSingleNodeBoolean(xml, "/*/queueItem/stuck");

            AllBuildDetails res = new AllBuildDetails();
            res.Status = GetStatus(status, stuck);
            res.LastBuild = GetBuildDetails(lastBuildUrl);
            res.LastCompletedBuild = GetBuildDetails(lastCompletedBuildUrl);
            res.LastSuccessfulBuild = GetBuildDetails(lastSuccessfulBuildUrl);
            res.LastFailedBuild = GetBuildDetails(lastFailedBuildUrl);

            logger.Info("Done updating project");
            return res;
        }

        private BuildStatus GetStatus(string status, bool? stuck)
        {
            if (stuck.HasValue && stuck.Value == true)
                return BuildStatus.Stuck;

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

            if (logger.IsDebugEnabled)
                logger.Debug("Getting build details from " + url);

            String xmlStr = DownloadString(url, true);

            if (logger.IsTraceEnabled)
                logger.Trace("XML: " + xmlStr);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlStr);

            string number = xml.SelectSingleNode("/*/number").InnerText;
            string timestamp = xml.SelectSingleNode("/*/timestamp").InnerText;
            XmlNodeList userNodes = xml.SelectNodes("/*/changeSet/item/user");

            TimeSpan ts = TimeSpan.FromSeconds(long.Parse(timestamp) / 1000);
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            date = date.Add(ts);

            ISet<string> users = new HashedSet<string>();
            foreach (XmlNode userNode in userNodes)
                users.Add(userNode.InnerText);

            BuildDetails res = new BuildDetails();
            res.Number = int.Parse(number);
            res.Time = date;
            res.Users = users;

            if (logger.IsDebugEnabled)
                logger.Debug("Done getting build details");

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

            String str = DownloadString(url, false);

            if (logger.IsTraceEnabled)
                logger.Trace("Result: " + str);

            logger.Info("Done running build");
        }

        private String DownloadString(string url, bool cacheable)
        {
            string res;

            if (logger.IsTraceEnabled)
                logger.Trace("Downloading: " + url);

            if (cacheable)
            {
                lock (this)
                {
                    // mark the URL as visited
                    visitedURLs.Add(url);
                    // perform a lookup in the cache
                    if (cache.TryGetValue(url, out res))
                    {
                        if (logger.IsTraceEnabled)
                            logger.Trace("Cache hit: " + url);
                        return res;
                    }
                }

                if (logger.IsTraceEnabled)
                    logger.Trace("Cache miss: " + url);
            }

            WebClient webClient = GetWebClient();
            res = webClient.DownloadString(url);

            if (logger.IsTraceEnabled)
                logger.Trace("Downloaded: " + res);

            if (cacheable)
            {
                lock (this)
                {
                    // store in cache
                    cache[url] = res;
                }
            }

            return res;
        }

        private WebClient GetWebClient()
        {
            if (threadWebClient == null)
            {
                logger.Info("Creating web client in thread " + Thread.CurrentThread.ManagedThreadId
                    + " (" + Thread.CurrentThread.Name + ")");
                threadWebClient = new CookieAwareWebClient();
            }
            return threadWebClient;
        }

        public void RecycleCache()
        {
            lock (this)
            {
                if (logger.IsTraceEnabled)
                    logger.Trace("Recycling cache: " + cache.Keys.Count + " items in cache");

                IDictionary<string, string> newCache = new Dictionary<string, string>();

                foreach (string visitedURL in visitedURLs)
                {
                    string value;
                    if (cache.TryGetValue(visitedURL, out value))
                        newCache.Add(visitedURL, value);
                }

                cache = newCache;
                visitedURLs.Clear();

                if (logger.IsTraceEnabled)
                    logger.Trace("Recycling cache: " + cache.Keys.Count + " items in cache");
            }
        }

        public string GetConsolePage(Project project)
        {
            AllBuildDetails allBuildDetails = project.AllBuildDetails;
            string res = project.Url;
            if (allBuildDetails != null && allBuildDetails.LastBuild != null)
                res += "lastBuild/console";
            return res;
        }
    }
}
