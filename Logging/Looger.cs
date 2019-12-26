using System;
using System.Diagnostics;
using System.IO;

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
        public static string filePath = @"log.txt";
        private static FileLogger instance = null;
        public override void Log(string message)
        {
            lock (lockObj)
            {
                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    streamWriter.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " - " + message);
                    streamWriter.Close();
                }
            }
        }

        public static FileLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileLogger();
                    using (StreamWriter streamWriter = new StreamWriter(filePath))
                    {
                        streamWriter.Close();
                    }
                }
                return instance;
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
                    logger = FileLogger.Instance;
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
