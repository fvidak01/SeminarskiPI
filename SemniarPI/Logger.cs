using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using static SemniarPI.Program;
namespace SemniarPI
{
    public static class MyLogger
    {
        private static Thread LogLoop;
        private static LinkedList<LogObject> LogQue = new LinkedList<LogObject>();
        private static bool run;
        private static int autoExit = 0;
        public enum LogType
        {
            Error,
            Warning,
            Info
        };
        private static string LogPath;
        static MyLogger()
        {
            if (!so.EnableLogging)
                return;
            run = true;
            Directory.CreateDirectory("Logs");
            LogPath = Path.GetFullPath("Logs");
            so.LoggingSwitched += OnLoggingSwitched;
            Start();
        }

        private static void OnLoggingSwitched(object sender, EventArgs e)
        {
            var s = (SettingsObject)sender;
            if (s.EnableLogging)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        private static void Start()
        {
            if (run)
                return;
            if (LogLoop.IsAlive)
            {
                if (!LogLoop.Join(200))
                    throw new Exception("Dafaq....lel"); //=> Should not happen!
            }
            LogLoop = new Thread(WriteLog);
            LogLoop.Start();
        }

        public static bool IsRunning => run;

        public static void CallStaticConstructor()
        {
            run.Equals(null); //gr8 m8 i r8 str8 8/8 no h8
        }
        private class LogObject
        {
            public Type t;
            public string s;
            public LogType lt;
            public LogObject(Type t, string s, LogType lt)
            {
                this.s = s;
                this.t = t;
                this.lt = lt;
            }
        }
        public static void Log(Type t, string s, LogType lt = LogType.Info)
        {
            if (!so.EnableLogging)
                return;
            LogQue.AddLast(new LogObject(t, s, lt));
            Start();
        }

        private static void WriteLog()
        {
            autoExit = 0;
            while (run)
            {
                if (LogQue.Count == 0)
                {
                    Thread.Sleep(100);
                    if (autoExit++ > 10) //TODO: Add confg limit
                    {
                        run = false;
                    }
                    continue;

                }
                var o = LogQue.First;
                var timeStamp = DateTime.Now.ToLocalTime().ToShortDateString();
                var val = o.Value;
                if (!File.Exists(LogPath + @"\" + val.t.Name + ".txt"))
                    File.Create(LogPath + @"\" + val.t.Name + ".txt").Close();
                try
                {
                    using (var w = new StreamWriter(LogPath + @"\" + val.t.Name + ".txt", true))
                    {
                        w.WriteLine("[" + timeStamp + "]" + "<" + val.lt + ">" + val.s);
                        w.Close();
                        w.Dispose();
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                    continue;
                }
                LogQue.RemoveFirst();
            }
        }
        public static void Stop()
        {
            run = false;
            LogQue.Clear();
        }
    }
}
