using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Hudson.TrayTracker.Entities
{
    public class ProjectActivity
    {
        private readonly Project project;
        public bool HasNewBuild { get; set; }

        public ProjectActivity(Project project)
        {
            this.project = project;
        }

        public bool IsBuilding
        {
            get { return project.Status.IsInProgress; }
        }

        public bool IsQueuing
        {
            get { return project.Queue.InQueue; }
        }

        public bool IsStuck
        {
            get { return !IsBuilding && project.Status.IsStuck; }
        }

        public bool HasStatusChanged
        {
            get { return project.PreviousStatus.Key != project.Status.Key; }
        }

        public bool HasNewBuildStarted
        {
            get { return HasNewBuild || ( HasStatusChanged && IsBuilding ); }
        }

        public bool HasBuildEnded
        {
            get { return HasStatusChanged && !IsBuilding; }
        }

        public bool IsAnotherBuildComplete
        {
            get { return ( HasBuildEnded && HasNewBuild ) || ( !IsBuilding && HasNewBuild ); }
        }

        public bool WasLastBuildSuccessful
        {
            get { return project.StatusValue == BuildStatusEnum.Successful; }
        }

        public bool HasBuildActivity
        {
            get { return HasBuildEnded || HasNewBuildStarted; }
        }

//#if false // tests
        public void DebugWriteLine()
        {
            Debug.WriteLine("\r\n-- " + project + " activity status --");
            Debug.WriteLine(" = Status = " + project.PreviousStatus.Key + " -> " + project.Status.Key);
            if (IsBuilding)             Debug.WriteLine(" - IsBuilding = Yes ");
            if (HasNewBuild)            Debug.WriteLine(" - HasNewBuild = Yes ");
            if (HasStatusChanged)       Debug.WriteLine(" - HasStatusChanged = Yes ");
            if (HasNewBuildStarted)     Debug.WriteLine(" - HasNewBuildStarted = Yes ");
            if (HasBuildEnded)          Debug.WriteLine(" - HasBuildEnded = Yes ");
            if (IsAnotherBuildComplete) Debug.WriteLine(" - IsAnotherBuildComplete = Yes ");
            if (WasLastBuildSuccessful) Debug.WriteLine(" - WasLastBuildSuccessful = Yes ");
            if (HasBuildActivity)       Debug.WriteLine(" - HasBuildActivity = Yes ");
            Debug.WriteLine(" - BuildTransition = " + BuildTransition);
            Debug.WriteLine(" - Time = " + DateTime.Now.ToLongTimeString() + "\r\n");
        }
//#endif

        public BuildTransition BuildTransition
        {
            get
            {
                BuildTransition buildTransition = null;
                bool wasSuccessful = project.PreviousStatusValue == BuildStatusEnum.Successful;
                bool wasUnstable = project.PreviousStatusValue == BuildStatusEnum.Unstable;
                bool wasBroken = project.PreviousStatusValue == BuildStatusEnum.Failed;
                bool wasAborted = project.PreviousStatusValue == BuildStatusEnum.Aborted;

                bool isSuccessful = project.StatusValue == BuildStatusEnum.Successful;
                bool isUnstable = project.StatusValue == BuildStatusEnum.Unstable;
                bool isBroken = project.StatusValue == BuildStatusEnum.Failed;
                bool isAborted = project.StatusValue == BuildStatusEnum.Aborted;

                if      (wasSuccessful && isUnstable)       buildTransition = BuildTransition.Unstable;
                else if (wasSuccessful && isBroken)         buildTransition = BuildTransition.Broken;
                else if (wasSuccessful && isAborted)        buildTransition = BuildTransition.Aborted;
                else if (wasSuccessful && isSuccessful)     buildTransition = BuildTransition.StillSuccessful;

                else if (wasUnstable && isUnstable)         buildTransition = BuildTransition.StillUnstable;
                else if (wasUnstable && isBroken)           buildTransition = BuildTransition.Broken;
                else if (wasUnstable && isAborted)          buildTransition = BuildTransition.Aborted;
                else if (wasUnstable && isSuccessful)       buildTransition = BuildTransition.Fixed;

                else if (wasBroken && isUnstable)           buildTransition = BuildTransition.Unstable;
                else if (wasBroken && isBroken)             buildTransition = BuildTransition.StillFailing;
                else if (wasBroken && isAborted)            buildTransition = BuildTransition.Aborted;
                else if (wasBroken && isSuccessful)         buildTransition = BuildTransition.Fixed;

                else if (wasAborted && isUnstable)          buildTransition = BuildTransition.Unstable;
                else if (wasAborted && isBroken)            buildTransition = BuildTransition.Broken;
                else if (wasAborted && isAborted)           buildTransition = BuildTransition.Aborted;
                else if (wasAborted && isSuccessful)        buildTransition = BuildTransition.Fixed;

                else if (isUnstable)    buildTransition = BuildTransition.Unstable;
                else if (isBroken)      buildTransition = BuildTransition.Broken;
                else if (isAborted)     buildTransition = BuildTransition.Aborted;
                else if (isSuccessful)  buildTransition = BuildTransition.StillSuccessful;

                return buildTransition;
            }
        }
    }
}
