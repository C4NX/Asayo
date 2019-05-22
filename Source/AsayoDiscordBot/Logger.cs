using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot
{
    public class Logger
    {
        public Type CurrentType { get; private set; }

        public bool SaveFileLog { get; set; } = false;

        public bool WriteConsoleLog { get; set; } = true;

        public static bool GlobalWriteConsoleLog { get; set; } = true;

        public static string LogFormat { get; set; } = "{3} | [{2}] ({1}) - {0}";

        public static event EventHandler<LogMessageEventArgs> OnGlobalLogMessage;

        public event EventHandler<LogMessageEventArgs> OnLogMessage;

        public static string LogFilename = DateTime.Now.ToFileTime() + ".log";

        public static LogType GlobalLogLevel = LogType.Info | LogType.Fatal | LogType.Error;

        static Logger glogger = Logger.GetLogger<Logger>();

        public static Logger GlobalLogger { get { return glogger; } }

        internal Logger(Type type)
        {
            CurrentType = type;
        }

        public static Logger GetLogger(Type type)
        {
            return new Logger(type);
        }

        public static Logger GetLogger(object obj)
        {
            if (obj == null) throw new NullReferenceException("Logger Object cannot be null");
            return new Logger(obj.GetType());
        }

        public static Logger GetLogger<T>()
        {
            return new Logger(typeof(T));
        }

        void Log(LogType type, string str, DateTime datetime)
        {
            var args = new LogMessageEventArgs()
            {
                Logger = this,
                LogTime = datetime,
                LogType = type,
                Message = str,
            };

            var logtext = GetMessage(args);

            OnLogMessage?.Invoke(this, args);
            OnGlobalLogMessage?.Invoke(this, args);

            if (WriteConsoleLog && GlobalWriteConsoleLog)
            {
                var col = Console.ForegroundColor;
                switch (type)
                {
                    case LogType.Info:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case LogType.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case LogType.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case LogType.Fatal:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case LogType.Debug:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    default:
                        break;
                }
                Console.WriteLine(logtext);
                Console.ForegroundColor = col;
            }
            if (SaveFileLog) System.IO.File.AppendAllText(LogFilename, logtext + "\n");
        }

        internal static string GetMessage(LogMessageEventArgs args)
        {
            return string.Format(LogFormat, args.Message, args.LogTime.ToString(), args.LogType.ToString(), args.Logger.CurrentType.Name); ;
        }

        public void Debug(string str) => Log(LogType.Debug, str, DateTime.Now);
        public void Debug(string str, DateTime time) => Log(LogType.Debug, str, time);

        public void Info(string str) => Log(LogType.Info, str, DateTime.Now);
        public void Info(string str, DateTime time) => Log(LogType.Info, str, time);

        public void Warning(string str) => Log(LogType.Warning, str, DateTime.Now);
        public void Warning(string str, DateTime time) => Log(LogType.Warning, str, time);

        public void Error(string str) => Log(LogType.Error, str, DateTime.Now);
        public void Error(string str, DateTime time) => Log(LogType.Error, str, time);

        public void Fatal(string str) => Log(LogType.Fatal, str, DateTime.Now);
        public void Fatal(string str, DateTime time) => Log(LogType.Fatal, str, time);
    }

    public enum LogType
    {
        Info,
        Warning,
        Error,
        Fatal,
        Debug
    }

    public class LogMessageEventArgs : EventArgs
    {
        public DateTime LogTime { get; internal set; }
        public string Message { get; internal set; }
        public LogType LogType { get; internal set; }
        public Logger Logger { get; internal set; }

        public override string ToString()
        {
            return Logger.GetMessage(this);
        }
    }
}
