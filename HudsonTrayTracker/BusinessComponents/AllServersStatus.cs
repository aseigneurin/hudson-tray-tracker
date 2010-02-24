using System.Collections.Generic;
using Hudson.TrayTracker.Entities;
using Hudson.TrayTracker.Utils;
using Hudson.TrayTracker.Utils.Collections;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class AllServersStatus
    {
        private ThreadSafeDictionary<string, BuildStatus> lastStatuses = new ThreadSafeDictionary<string, BuildStatus>();
        private ThreadSafeDictionary<string, BuildStatus> lastCompletedStatuses = new ThreadSafeDictionary<string, BuildStatus>();

        public IEnumerable<Server> Servers { get; private set; }

        public List<Project> FailingProjects { get; private set; }
        public List<Project> StillFailingProjects { get; private set; }
        public List<Project> SucceedingProjects { get; private set; }
        public List<Project> FixedProjects { get; private set; }

        public void Update(IEnumerable<Server> servers)
        {
            FailingProjects = new List<Project>();
            StillFailingProjects = new List<Project>();
            SucceedingProjects = new List<Project>();
            FixedProjects = new List<Project>();

            foreach (var server in servers)
            {
                UpdateForServer(server);
            }
        }

        private void UpdateForServer(Server server)
        {
            foreach (var project in server.Projects)
            {
                UpdateForProject(project);
                lastStatuses.SetOrAdd(project.Url, project.Status);
                if (!BuildStatusUtils.IsBuildInProgress(project.Status))
                {
                    lastCompletedStatuses.SetOrAdd(project.Url, project.Status);
                }
            }
        }

        private void UpdateForProject(Project project)
        {
            if (lastStatuses.ContainsKey(project.Url) && lastCompletedStatuses.ContainsKey(project.Url))
            {
                if (BuildStatusUtils.IsBuildInProgress(lastStatuses[project.Url]))
                {
                    if (project.Status == BuildStatus.Successful)
                    {
                        if (BuildStatusUtils.IsErrorBuild(lastCompletedStatuses[project.Url]))
                        {
                            FixedProjects.Add(project);
                        }
                        else
                        {
                            SucceedingProjects.Add(project);
                        }
                    }
                    else if (TreatAsFailure(project.Status))
                    {
                        if (TreatAsFailure(lastCompletedStatuses[project.Url]))
                        {
                            StillFailingProjects.Add(project);
                        }
                        else
                        {
                            FailingProjects.Add(project);
                        }
                    }
                }
            }
        }

        private bool TreatAsFailure(BuildStatus status)
        {
            return status == BuildStatus.Failed ||
                   status == BuildStatus.Stuck ||
                   status == BuildStatus.Unstable;
        }
    }
}
