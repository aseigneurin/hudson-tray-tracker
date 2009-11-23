using System.IO;
using Hudson.TrayTracker.Entities;

namespace Hudson.TrayTracker.BusinessComponents
{
    public class NotificationService
    {
        private readonly NotificationSounds sounds;
        private BuildStatus lastStatus = BuildStatus.Unknown;

        public NotificationService(NotificationSounds sounds)
        {
            this.sounds = sounds;
        }

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
                SoundPlayer.PlayFile(sounds.FixedSoundPath);
            }
            else
            {
                SoundPlayer.PlayFile(sounds.SucceededSoundPath);
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
                SoundPlayer.PlayFile(sounds.StillFailingSoundPath);
            }
            else
            {
                SoundPlayer.PlayFile(sounds.FailedSoundPath);
            }
        }
    }
}