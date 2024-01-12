using System;
using System.Diagnostics;

namespace PlaygroundCore.Performance
{
    public class PerformanceLogger : IDisposable
    {
        string _message;
        Stopwatch _timer;

        public PerformanceLogger(string message)
        {
            _message = message;
            _timer = new Stopwatch();
            _timer.Start();
        }

        public void Dispose()
        {
            _timer.Stop();
            var elapsedTime = _timer.Elapsed;

            var message = $"{_message} - Elapsed: {elapsedTime}";
            Debug.WriteLine(message);
            Console.WriteLine(message);
        }
    }
}

