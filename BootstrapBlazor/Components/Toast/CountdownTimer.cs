namespace BootstrapBlazor
{
    internal class CountdownTimer : IDisposable
    {
        private readonly PeriodicTimer _timer;
        private readonly CancellationToken _cancellationToken;
        private int _countdownTime;

        private Func<int, Task>? _tickDelegate;
        private Action? _elapsedDelegate;

        internal CountdownTimer(int timeout, CancellationToken cancellationToken = default)
        {
            _countdownTime = timeout;
            _timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            _cancellationToken = cancellationToken;
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

        internal async Task StartAsync()
        {
            await DoWorkAsync();
        }

        private async Task DoWorkAsync()
        {
            while (await _timer.WaitForNextTickAsync(_cancellationToken) && !_cancellationToken.IsCancellationRequested)
            {
                if (_countdownTime > 0)
                {
                    _countdownTime--;
                    await _tickDelegate?.Invoke(_countdownTime)!;
                }
                if (_countdownTime == 0)
                {
                    _elapsedDelegate?.Invoke();
                }
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
