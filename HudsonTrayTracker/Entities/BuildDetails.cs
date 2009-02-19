using System;
using System.Collections.Generic;
using System.Text;

namespace Hudson.TrayTracker.Entities
{
  public  class BuildDetails
    {
        int number;
        string url;
        DateTime time;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
