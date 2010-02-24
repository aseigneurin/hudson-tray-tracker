using System.IO;
using Hudson.TrayTracker.Entities;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class NotificationService
    {
        private BuildStatus lastStatus = BuildStatus.Unknown;

        public NotificationSounds Sounds { get; set; }

        public void Execute(BuildStatus status)
        {
            switch (status)
            {
                case BuildStatus.Successful:
                    HandleSucceeded();
                    break;
                case BuildStatus.Failed:
                    HandleFailed();
                    break;
            }
            lastStatus = status;
        }

        private void HandleSucceeded()
        {
            if (lastStatus == BuildStatus.Successful || lastStatus == BuildStatus.Unknown)
            {
                return;
            }
            if (lastStatus == BuildStatus.Failed_BuildInProgress)
            {
                SoundPlayer.PlayFile(Sounds.FixedSoundPath);
            }
            else
            {
                SoundPlayer.PlayFile(Sounds.SucceededSoundPath);
            }
        }

        private void HandleFailed()
        {
            if (lastStatus == BuildStatus.Failed || lastStatus == BuildStatus.Unknown)
            {
                return;
            }
            if (lastStatus == BuildStatus.Failed_BuildInProgress)
            {
                SoundPlayer.PlayFile(Sounds.StillFailingSoundPath);
            }
            else
            {
                SoundPlayer.PlayFile(Sounds.FailedSoundPath);
            }
        }
    }
}