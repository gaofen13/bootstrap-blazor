using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class ToastInstance : IDisposable
    {
        private CountdownTimer? _countdownTimer;

        public int CountdownTimeout { get; set; }

        public ToastOptions LiveOptions { get; set; } = new();

        [CascadingParameter]
        private BootstrapToastContainer? ToastContainer { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public ToastOptions? Options { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        protected override Task OnInitializedAsync()
        {
            if (Options != null)
            {
                LiveOptions = Options;
            }
            else
            {
                if (ToastContainer?.GlobalOptions != null)
                {
                    LiveOptions = ToastContainer.GlobalOptions;
                }
            }

            if (LiveOptions.AutoClose && LiveOptions.CountdownTimeout > 0)
            {
                _countdownTimer = new CountdownTimer(CountdownTimeout = LiveOptions.CountdownTimeout)
                    .OnTick(CountdownAsync)
                    .OnElapsed(Close);

                _countdownTimer.Start();
            }
            return base.OnInitializedAsync();
        }

        private async Task CountdownAsync(int time)
        {
            CountdownTimeout = time;
            await InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Closes the toast
        /// </summary>
        public void Close() => ToastContainer?.RemoveToast(Id);

        void IDisposable.Dispose()
        {
            _countdownTimer?.Dispose();
            _countdownTimer = null;
            GC.SuppressFinalize(this);
        }
    }
}
