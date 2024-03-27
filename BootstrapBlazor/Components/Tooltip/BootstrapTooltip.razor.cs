using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapTooltip
    {
        private bool _show;

        private string Classname =>
            new ClassBuilder("tooltip show")
            .AddClass($"bs-tooltip-{Placement}")
            .AddClass(Class)
            .Build();

        [Parameter]
        public Placement Placement { get; set; } = Placement.top;

        [Parameter]
        public string? Message { get; set; }

        [Parameter]
        public RenderFragment? MessageContent { get; set; }
    }
}