using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using static SemniarPI.Program;
namespace SemniarPI
{
    public static class MyLogger
    {
        private static Thread _logLoop;
        private static LinkedList<LogObject> _logQue = new LinkedList<LogObject>();
        private static bool _run;
        private static int _autoExit;
        public enum LogType
        {
            Error,
            Warning,
            Info
        }
        private static string _logPath;
        static MyLogger()
        {
            if (!so.EnableLogging)
                return;
            _run = true;
            Directory.CreateDirectory("Logs");
            _logPath = Path.GetFullPath("Logs");
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
            if (_run)
                return;
            if (_logLoop.IsAlive)
            {
                if (!_logLoop.Join(200))
                    throw new Exception("Dafaq....lel"); //=> Should not happen!
            }
            _logLoop = new Thread(WriteLog);
            _logLoop.Start();
        }

        public static bool IsRunning => _run;

        public static void CallStaticConstructor()
        {
            _run.Equals(null); //gr8 m8 i r8 str8 8/8 no h8
        }
        private class LogObject
        {
            public Type T;
            public string S;
            public LogType Lt;
            public LogObject(Type t, string s, LogType lt)
            {
                S = s;
                T = t;
                Lt = lt;
            }
        }
        public static void Log(Type t, string s, LogType lt = LogType.Info)
        {
            if (!so.EnableLogging)
                return;
            _logQue.AddLast(new LogObject(t, s, lt));
            Start();
        }

        private static void WriteLog()
        {
            _autoExit = 0;
            while (_run)
            {
                if (_logQue.Count == 0)
                {
                    Thread.Sleep(100);
                    if (_autoExit++ > 10) //TODO: Add confg limit
                    {
                        _run = false;
                    }
                    continue;

                }
                var o = _logQue.First;
                var timeStamp = DateTime.Now.ToLocalTime().ToShortDateString();
                var val = o.Value;
                if (!File.Exists(_logPath + @"\" + val.T.Name + ".txt"))
                    File.Create(_logPath + @"\" + val.T.Name + ".txt").Close();
                try
                {
                    using (var w = new StreamWriter(_logPath + @"\" + val.T.Name + ".txt", true))
                    {
                        w.WriteLine("[" + timeStamp + "]" + "<" + val.Lt + ">" + val.S);
                        w.Close();
                        w.Dispose();
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                    continue;
                }
                _logQue.RemoveFirst();
            }
        }
        public static void Stop()
        {
            _run = false;
            _logQue.Clear();
        }
    }
}
