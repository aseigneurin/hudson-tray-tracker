namespace Hudson.TrayTracker.Entities
{
    public class NotificationSettings
    {
        public string FailedSoundPath { get; set; }
        public string SucceededSoundPath { get; set; }
        public string StillFailingSoundPath { get; set; }
        public string FixedSoundPath { get; set; }
        public bool TreatUnstableAsFailed { get; set; }
    }
}