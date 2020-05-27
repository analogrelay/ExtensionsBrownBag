using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace _04_Logging
{
    class SimpleJsonLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new SimpleJsonLogger(categoryName);
        }

        public void Dispose()
        {
        }

        private class SimpleJsonLogger : ILogger
        {
            private string _categoryName;

            public SimpleJsonLogger(string categoryName)
            {
                _categoryName = categoryName;
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return NullLogger.Instance.BeginScope(state);
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                // This is deprecated anyway.
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                Console.WriteLine("Event!");
                Console.WriteLine($"    Category: {_categoryName}");
                if (state is IEnumerable<KeyValuePair<string, object>> pairs)
                {
                    var dict = pairs.ToDictionary(p => p.Key, p => p.Value);
                    var oldFg = Console.ForegroundColor;
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"    JSON: {JsonSerializer.Serialize(dict)}");
                    }
                    finally
                    {
                        Console.ForegroundColor = oldFg;
                    }
                }
                Console.WriteLine($"    {formatter(state, exception)}");
            }
        }
    }
}

namespace Microsoft.Extensions.DependencyInjection
{
    static class SimpleJsonLoggerProviderExtensions
    {
        public static void AddSimpleJsonLogging(this ILoggingBuilder logging)
        {
            logging.Services.AddSingleton<ILoggerProvider, _04_Logging.SimpleJsonLoggerProvider>();
        }
    }
}
