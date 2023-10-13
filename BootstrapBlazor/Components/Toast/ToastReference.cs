using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    internal class ToastReference(Guid id, RenderFragment toastInstance)
    {
        public Guid Id { get; set; } = id;

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public RenderFragment ToastInstance { get; set; } = toastInstance;
    }
}
