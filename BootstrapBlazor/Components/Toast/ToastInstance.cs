using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    internal class ToastInstance
    {
        public ToastInstance(ToastOptions settings)
        {
            Options = settings;
        }

        public ToastInstance(RenderFragment messageContent, ToastOptions settings)
        {
            MessageContent = messageContent;
            Options = settings;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public ToastOptions Options { get; set; }

        public Color ToastLevel { get; set; }

        public string? Title { get; set; }

        public RenderFragment? MessageContent { get; set; }
    }
}
