using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    internal class ToastReference
    {
        public ToastReference(Guid id, RenderFragment toastInstance)
        {
            Id = id;
            ToastInstance = toastInstance;
        }

        public Guid Id { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public RenderFragment ToastInstance { get; set; }
    }
}
