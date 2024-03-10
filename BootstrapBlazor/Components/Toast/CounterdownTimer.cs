namespace BootstrapBlazor
{
    internal class CounterdownTimer : IDisposable
    {
        private int _counter;
        private readonly Timer _timer;
        private Action? _elapsedDelegate;
        private Func<int, Task>? _tickDelegate;

        internal CounterdownTimer(int timeout)
        {
            _counter = timeout;
            _timer = new Timer(TimerElapsed);
        }

        private void TimerElapsed(object? state)
        {
            if (_counter > 0)
            {
                _counter--;
                _tickDelegate?.Invoke(_counter);
            }
            else
            {
                _elapsedDelegate?.Invoke();
            }
        }

        internal CounterdownTimer OnTick(Func<int, Task> updateProgressDelegate)
        {
            _tickDelegate = updateProgressDelegate;
            return this;
        }

        internal CounterdownTimer OnElapsed(Action elapsedDelegate)
        {
            _elapsedDelegate = elapsedDelegate;
            return this;
        }

        internal void Start()
        {
            _timer?.Change(0, 1000);
        }

        internal void Stop()
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose()
        {
            Stop();
            _timer.Dispose();
        }
    }
}
