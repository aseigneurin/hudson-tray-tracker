using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Dotnet.Commons.Logging;
using System.Reflection;
using Hudson.TrayTracker.Entities;
using System.ComponentModel;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class UpdateService
    {
        public delegate void ProjectsUpdatedHandler();
        public event ProjectsUpdatedHandler ProjectsUpdated;

        static readonly ILog logger = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // every 15 seconds
        static readonly int DEFAULT_UPDATE_PERIOD = 15 * 1000;

        ConfigurationService configurationService;
        HudsonService hudsonService;

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

        public UpdateService()
        {
            timer = new Timer(UpdateProjects, null, updatePeriod, updatePeriod);
        }

        public void UpdateProjects()
        {
            logger.Info("Running update from user");

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate { DoUpdateProjects(); };
            worker.RunWorkerAsync();

            logger.Info("Done");
        }

        private void UpdateProjects(object state)
        {
            logger.Info("Running update from timer");
            DoUpdateProjects();
            logger.Info("Done");
        }

        private void DoUpdateProjects()
        {
            lock (this)
            {
                if (updating)
                    return;
                updating = true;
            }

            foreach (Server server in configurationService.Servers)
            {
                foreach (Project project in server.Projects)
                {
                    hudsonService.UpdateProject(project);
                }
            }

            lock (this)
            {
                updating = false;
            }

            if (ProjectsUpdated != null)
                ProjectsUpdated();
        }
    }
}
