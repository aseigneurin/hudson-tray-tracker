using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Common.Logging;
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

        static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

#if !DEBUG
        const int TOTAL_THREAD_COUNT = 8;
        const int THREAD_COUNT_BY_DOMAIN = 4;
#else
        const int TOTAL_THREAD_COUNT = 1;
        const int THREAD_COUNT_BY_DOMAIN = 1;
#endif

        SmartThreadPool threadPool = new SmartThreadPool(3600, TOTAL_THREAD_COUNT, TOTAL_THREAD_COUNT);

        Timer timer;
        bool updating;

        public ConfigurationService ConfigurationService { get; set; }
        public HudsonService HudsonService { get; set; }

        public ProjectsUpdateService()
        {
        }

        public void Initialize()
        {
            timer = new Timer(UpdateProjects, null, 0, Timeout.Infinite);
        }

        public void UpdateProjects()
        {
            var worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                DoUpdateProjects(UpdateSource.User);
            };
            worker.RunWorkerAsync();
        }

        private void UpdateProjects(object state)
        {
            DoUpdateProjects(UpdateSource.Timer);

            int timeBetweenUpdates = ConfigurationService.GeneralSettings.RefreshIntervalInSeconds * 1000;
            timer.Change(timeBetweenUpdates, Timeout.Infinite);
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
                HudsonService.RecycleCache();
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
            IDictionary<Server, ISet<Project>> projectsByServer = ConfigurationService.GetProjects();
            var allWorkItemsGroup = new List<IWorkItemsGroup>();
            var allFutureBuildDetails = new Dictionary<Project, IWorkItemResult>();

            foreach (KeyValuePair<Server, ISet<Project>> pair in projectsByServer)
            {
                Server server = pair.Key;
                ISet<Project> projects = pair.Value;

                IWorkItemsGroup workItemsGroup = threadPool.CreateWorkItemsGroup(THREAD_COUNT_BY_DOMAIN);
                allWorkItemsGroup.Add(workItemsGroup);

                foreach (Project project in projects)
                {
                    WorkItemCallback work = delegate(object state)
                    {
                        AllBuildDetails newBuildDetail = null;
                        try
                        {
                            Project project_ = (Project)state;
                            newBuildDetail = HudsonService.UpdateProject(project_);
                        }
                        catch (Exception ex)
                        {
                            LoggingHelper.LogError(logger, ex);
                        }
                        return newBuildDetail;
                    };
                    IWorkItemResult futureRes = workItemsGroup.QueueWorkItem(work, project);
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
