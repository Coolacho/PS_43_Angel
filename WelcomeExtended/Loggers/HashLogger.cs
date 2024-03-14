﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    public class HashLogger: ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;

        private readonly string _name;

        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            //This logger does not support scopes
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // This logger is always enabled
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            switch(logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine("- LOGGER -");
            Console.WriteLine($"[{logLevel}][{_name}]");
            Console.WriteLine($"{message}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;
        }

        public void GetAllLogs()
        {
            foreach (var log in _logMessages.Values)
            {
                Console.WriteLine(log);
            }
        }

        public void GetLogByEventId(EventId eventId)
        {
            if (_logMessages.TryGetValue(eventId.Id, out var log))
                Console.WriteLine($"{eventId.Id}: {log}");
            else
                Console.WriteLine("Log doesn't exist!");
        }

        public bool RemoveLogByEventId(EventId eventId)
        {
            return _logMessages.TryRemove(eventId.Id, out _);
        }

    }
}
