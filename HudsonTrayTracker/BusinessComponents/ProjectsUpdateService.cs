using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Dotnet.Commons.Logging;
using System.Reflection;
using Hudson.TrayTracker.Entities;
using System.ComponentModel;
using Hudson.TrayTracker.Utils.Logging;
using Iesi.Collections.Generic;
using Amib.Threading;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class ProjectsUpdateService
    {
        public enum UpdateSource
        {
            User,
            Timer,
            Program
        }

        public delegate void ProjectsUpdatedHandler();
        public event ProjectsUpdatedHandler ProjectsUpdated;

        static readonly ILog logger = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // every 15 seconds
        static readonly int DEFAULT_UPDATE_PERIOD = 15 * 1000;

        const int TOTAL_THREAD_COUNT = 8;
        const int THREAD_COUNT_BY_DOMAIN = 4;

        ConfigurationService configurationService;
        HudsonService hudsonService;
        SmartThreadPool threadPool = new SmartThreadPool(60, TOTAL_THREAD_COUNT);

        Timer timer;
        int updatePeriod = DEFAULT_UPDATE_PERIOD;
        bool updating;

        public ConfigurationService ConfigurationService
        {
            get { return configurationService; }
            set { configurationService = value; }
        }

        public HudsonService HudsonService
        {
            get { return hudsonService; }
            set { hudsonService = value; }
        }

        public ProjectsUpdateService()
        {
        }

        public void Initialize()
        {
            timer = new Timer(UpdateProjects, null, 0, updatePeriod);
        }

        public void UpdateProjects()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                DoUpdateProjects(UpdateSource.User);
            };
            worker.RunWorkerAsync();
        }

        private void UpdateProjects(object state)
        {
            DoUpdateProjects(UpdateSource.Timer);
        }

        private void DoUpdateProjects(UpdateSource source)
        {
            logger.Info("Running update from " + source);

            lock (this)
            {
                if (updating)
                {
                    logger.Info("Already in update: skipping");
                    return;
                }
                updating = true;
            }

            try
            {
                DoUpdateProjectsInternal();
            }
            catch (Exception ex)
            {
                LoggingHelper.LogError(logger, ex);
                throw;
            }
            finally
            {
                lock (this)
                {
                    updating = false;
                }
            }

            logger.Info("Done");
        }

        private void DoUpdateProjectsInternal()
        {
            IDictionary<Server, ISet<Project>> projectsByServer = configurationService.GetProjects();
            IList<IWorkItemsGroup> allWorkItemsGroup = new List<IWorkItemsGroup>();
            IDictionary<Project, IWorkItemResult> allFutureBuildDetails
                = new Dictionary<Project, IWorkItemResult>();

            foreach (KeyValuePair<Server, ISet<Project>> pair in projectsByServer)
            {
                Server server = pair.Key;
                ISet<Project> projects = pair.Value;

                IWorkItemsGroup workItemsGroup = threadPool.CreateWorkItemsGroup(THREAD_COUNT_BY_DOMAIN);
                allWorkItemsGroup.Add(workItemsGroup);

                foreach (Project project in projects)
                {
                    WorkItemCallback work = delegate
                    {
                        AllBuildDetails newBuildDetail = null;
                        try
                        {
                            newBuildDetail = hudsonService.UpdateProject(project);
                        }
                        catch (Exception ex)
                        {
                            LoggingHelper.LogError(logger, ex);
                        }
                        return newBuildDetail;
                    };
                    IWorkItemResult futureRes = workItemsGroup.QueueWorkItem(work);
                    allFutureBuildDetails[project] = futureRes;
                }
            }

            foreach (IWorkItemsGroup workItemsGroup in allWorkItemsGroup)
            {
                workItemsGroup.WaitForIdle();
            }

            foreach (ISet<Project> projects in projectsByServer.Values)
            {
                foreach (Project project in projects)
                {
                    IWorkItemResult newStatus;
                    allFutureBuildDetails.TryGetValue(project, out newStatus);
                    project.AllBuildDetails = newStatus != null ? (AllBuildDetails)newStatus.Result : null;
                }
            }

            if (ProjectsUpdated != null)
                ProjectsUpdated();
        }
    }
}
