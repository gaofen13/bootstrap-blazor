namespace BootstrapBlazor
{
    internal class CountdownTimer : IDisposable
    {
        private readonly Timer _timer;
        private int _countdownTime;

        private Func<int, Task>? _tickDelegate;
        private Action? _elapsedDelegate;

        internal CountdownTimer(int timeout)
        {
            _countdownTime = timeout;
            _timer = new Timer(TimerElapsed);
        }

        private void TimerElapsed(object? state)
        {
            if (_countdownTime > 0)
            {
                _countdownTime--;
                _tickDelegate?.Invoke(_countdownTime);
            }
            else
            {
                _elapsedDelegate?.Invoke();
            }
        }

        internal CountdownTimer OnTick(Func<int, Task> updateProgressDelegate)
        {
            _tickDelegate = updateProgressDelegate;
            return this;
        }

        internal CountdownTimer OnElapsed(Action elapsedDelegate)
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
