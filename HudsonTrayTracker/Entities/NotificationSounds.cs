namespace Hudson.TrayTracker.Entities
{
    public class NotificationSounds
    {
        private string failedSoundPath;
        private string succeededSoundPath;
        private string stillFailingSoundPath;
        private string fixedSoundPath;

        public string FailedSoundPath
        {
            get { return failedSoundPath; }
            set { failedSoundPath = value; }
        }

        public string SucceededSoundPath
        {
            get { return succeededSoundPath; }
            set { succeededSoundPath = value; }
        }

        public string StillFailingSoundPath
        {
            get { return stillFailingSoundPath; }
            set { stillFailingSoundPath = value; }
        }

        public string FixedSoundPath
        {
            get { return fixedSoundPath; }
            set { fixedSoundPath = value; }
        }
    }
}