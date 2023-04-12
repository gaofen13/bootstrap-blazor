using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapToast : BootstrapComponentBase
    {
        private int _countdownTime;
        private ToastOptions _options = new();
        private CountdownTimer? _countdownTimer;

        private string Classname =>
            new ClassBuilder("toast fade show")
            .AddClass($"text-bg-{ToastLevel}")
            .AddClass(Class)
            .Build();

        private string HeaderClassname =>
            new ClassBuilder("toast-header")
            .AddClass($"text-{ToastLevel}")
            .Build();

        [CascadingParameter]
        private BootstrapToastContainer? ToastContainer { get; set; }

        [Parameter]
        public Color ToastLevel { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? MessageContent { get; set; }

        [Parameter]
        public Guid ToastId { get; set; }

        [Parameter]
        public ToastOptions? Options { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Options != null)
            {
                _options = Options;
            }
            else
            {
                if (ToastContainer?.GlobalOptions != null)
                {
                    _options = ToastContainer.GlobalOptions;
                }
            }

            _countdownTimer = new CountdownTimer(_countdownTime = _options.TimeOut)
                .OnTick(CountdownAsync)
                .OnElapsed(Close);

            await _countdownTimer.StartAsync();
        }

        private async Task CountdownAsync(int time)
        {
            _countdownTime = time;
            await InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Closes the toast
        /// </summary>
        public void Close() => ToastContainer?.RemoveToast(ToastId);

        void IDisposable.Dispose()
        {
            _countdownTimer?.Dispose();
            _countdownTimer = null;
            GC.SuppressFinalize(this);
        }
    }
}
