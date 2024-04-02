using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace WelcomeExtended.Loggers
{
    public class FileLogger : ILogger
    {

        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;
        private readonly string _filePath;

        public FileLogger(string name, string filePath)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
            _filePath = filePath;

        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            //This logger does not support scopes
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //This logger is always enabled
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            using (StreamWriter w = File.AppendText(_filePath))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                w.WriteLine($"  :{message}");
                w.WriteLine("-------------------------------");
            }
            _logMessages[eventId.Id] = message;
        }
    }
}
