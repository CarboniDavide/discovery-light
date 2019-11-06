using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoveryLight.Logging
{
    public enum LogTarget
    {
        File, EventLog
    }
    public abstract class LogBase
    {
        protected readonly object lockObj = new object();
        public abstract void Log(string message);
    }
    
    public class FileLogger : LogBase
    {
        public string filePath = @"Log/Log.txt";
        public override void Log(string message)
        {
            lock (lockObj)
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " - " + message);
                    streamWriter.Close();
                }
            }
        }
    }

    public class EventLogger : LogBase
    {
        public override void Log(string message)
        {
            lock (lockObj)
            {
                EventLog eventLog = new EventLog("");
                eventLog.Source = "IDGEventLog";
                eventLog.WriteEntry(DateTime.Now.ToString("h:mm:ss tt") + " - " + message);
            }
        }
    }

    public static class LogHelper
    {
        private static LogBase logger = null;
        public static void Log(LogTarget target, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLogger();
                    logger.Log(message);
                    break;
                case LogTarget.EventLog:
                    logger = new EventLogger();
                    logger.Log(message);
                    break;
                default:
                    return;
            }
        }
    }

    // use as LogHelper.Log(LogTarget.File, "This is a log");
}
