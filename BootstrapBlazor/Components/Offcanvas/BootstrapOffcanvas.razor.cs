using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapOffcanvas : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("offcanvas")
            .AddClass("show", Show)
            .AddClass($"offcanvas-{Placement}")
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Show { get; set; }

        [Parameter]
        public EventCallback<bool> ShowChanged { get; set; }

        [Parameter]
        public bool ShowBackdrop { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool ShowCloseButton { get; set; }

        [Parameter]
        public Placement Placement { get; set; }

        private void Close()
        {
            if (Show)
            {
                Show = false;
                _ = ShowChanged.InvokeAsync(false);
            }
        }

        private void OnClickBackdrop()
        {
            Close();
        }
    }
}