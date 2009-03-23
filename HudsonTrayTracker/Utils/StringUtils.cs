using System;
using System.Collections.Generic;
using System.Text;

namespace Hudson.TrayTracker.Utils
{
    public static class StringUtils
    {
        public static string Join<T>(IEnumerable<T> objects, string separator)
            where T : class
        {
            string sep = "";
            StringBuilder res = new StringBuilder();
            foreach (object o in objects)
            {
                res.Append(sep).Append(o);
                sep = separator;
            }
            return res.ToString();
        }
    }
}
