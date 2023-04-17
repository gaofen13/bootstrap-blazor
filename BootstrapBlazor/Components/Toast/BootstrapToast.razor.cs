using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapToast : BootstrapComponentBase
    {
        private bool HasHeader => !string.IsNullOrWhiteSpace(Title) || IconContent != null || (ToastInstance?.LiveOptions.AutoClose == true && ToastInstance.LiveOptions.CountdownTimeout > 0) || ToastInstance?.LiveOptions.ManualClose == true;

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
        private ToastInstance? ToastInstance { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? Message { get; set; }

        [Parameter]
        public RenderFragment? IconContent { get; set; }

        public void Close()
        {
            ToastInstance?.Close();
        }
    }
}
