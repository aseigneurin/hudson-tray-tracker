using System;
using System.ComponentModel;
using Hudson.TrayTracker.Entities;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class NotificationService : Component
    {
        private AllServersStatus allServersStatus = new AllServersStatus();

        public ConfigurationService ConfigurationService { get; set; }
        public ProjectsUpdateService UpdateService { private get; set; }
        public NotificationSettings Settings { private get; set; }

        public void Initialize()
        {
            ConfigurationService.ConfigurationUpdated += Execute;
            UpdateService.ProjectsUpdated += Execute;
            Disposed += delegate
            {
                ConfigurationService.ConfigurationUpdated -= Execute;
                UpdateService.ProjectsUpdated -= Execute;
            };

            Execute();
        }

        public void Execute()
        {
            allServersStatus.Update(ConfigurationService.Servers);

            if (allServersStatus.StillFailingProjects.Count > 0)
            {
                SoundPlayer.PlayFile(Settings.StillFailingSoundPath);
            }
            else if (allServersStatus.FailingProjects.Count > 0)
            {
                SoundPlayer.PlayFile(Settings.FailedSoundPath);
            }
            else if (allServersStatus.FixedProjects.Count > 0)
            {
                SoundPlayer.PlayFile(Settings.FixedSoundPath);
            }
            else if (allServersStatus.SucceedingProjects.Count > 0)
            {
                SoundPlayer.PlayFile(Settings.SucceededSoundPath);
            }
        }

        private bool TreatAsFailure(BuildStatusEnum status)
        {
            return status == BuildStatusEnum.Failed ||
                   status == BuildStatusEnum.Stuck ||
                   (Settings.TreatUnstableAsFailed && status == BuildStatusEnum.Unstable);
        }
    }
}