using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    internal class ToastReference(RenderFragment toastContent, ToastOptions? options)
    {
        public Guid Id { get; } = Guid.NewGuid();

        public DateTime TimeStamp { get; } = DateTime.Now;

        public ToastOptions? Options { get; set; } = options;

        public RenderFragment ToastContent { get; set; } = toastContent;
    }
}
