using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapToast : BootstrapComponentBase, IDisposable
    {
        private int _counter;
        private CounterdownTimer? _counterdownTimer;
        private ToastOptions? _options;
        private bool _showCounterdown;
        private bool HasHeader => !string.IsNullOrWhiteSpace(Title) || IconContent != null || _showCounterdown || _options?.ManualClose == true;

        private string Classname =>
            new ClassBuilder("toast fade show")
            .AddClass($"text-bg-{Color}", Color != null)
            .AddClass(Class)
            .Build();

        private string HeaderClassname =>
            new ClassBuilder("toast-header")
            .AddClass($"text-{Color}", Color != null)
            .Build();

        [CascadingParameter]
        private BootstrapToastContainer? ToastContainer { get; set; }

        [CascadingParameter]
        private ToastInstance? ToastInstance { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? Message { get; set; }

        [Parameter]
        public RenderFragment? IconContent { get; set; }

        protected override Task OnInitializedAsync()
        {
            _options = ToastInstance?.Options ?? ToastContainer?.GlobalOptions;
            _showCounterdown = _options?.AutoClose == true && _options.CountdownTimeout > 0;

            if (_showCounterdown)
            {
                _counterdownTimer = new CounterdownTimer(_counter = _options!.CountdownTimeout)
                    .OnTick(CountdownAsync)
                    .OnElapsed(Close);

                _counterdownTimer.Start();
            }

            return base.OnInitializedAsync();
        }

        private async Task CountdownAsync(int counter)
        {
            _counter = counter;
            await InvokeAsync(StateHasChanged);
        }

        public void Close()
        {
            if (ToastInstance is not null)
            {
                ToastContainer?.RemoveToast(ToastInstance.Id);
            }
        }

        void IDisposable.Dispose()
        {
            _counterdownTimer?.Dispose();
            _counterdownTimer = null;
            GC.SuppressFinalize(this);
        }
    }
}
