using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapBadge : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("badge")
            .AddClass($"text-bg-{Color}")
            .AddClass("rounded-pill", !Indicator && Pill)
            .AddClass("p-2 border border-light rounded-circle", Indicator)
            .AddClass("position-absolute translate-middle", HorizontalPosition != null || VerticalPosition != null)
            .AddClass("start-0", HorizontalPosition == BootstrapBlazor.HorizontalPosition.start)
            .AddClass("start-50", HorizontalPosition == BootstrapBlazor.HorizontalPosition.center)
            .AddClass("start-100", HorizontalPosition == BootstrapBlazor.HorizontalPosition.end)
            .AddClass("top-0", VerticalPosition == BootstrapBlazor.VerticalPosition.top)
            .AddClass("top-50", VerticalPosition == BootstrapBlazor.VerticalPosition.middle)
            .AddClass("top-100", VerticalPosition == BootstrapBlazor.VerticalPosition.bottom)
            .AddClass(Class)
            .Build();

        [Parameter]
        public Color Color { get; set; }

        [Parameter]
        public bool Pill { get; set; }

        [Parameter]
        public bool Indicator { get; set; }

        [Parameter]
        public HorizontalPosition? HorizontalPosition { get; set; }

        [Parameter]
        public VerticalPosition? VerticalPosition { get; set; }
    }
}
