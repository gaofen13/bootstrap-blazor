using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapNavDropdown : BootstrapComponentBase
    {
        private string Classname =>
            new ClassBuilder("nav-item dropdown")
            .AddClass(Class)
            .Build();

        private string ToggleClassname =>
            new ClassBuilder("nav-link dropdown-toggle")
            .AddClass("show", Show)
            .Build();

        private string MenuClassname =>
            new ClassBuilder("dropdown-menu")
            .AddClass("show", Show)
            .AddClass("end-0", AlignEnd)
            .AddClass("text-end", AlignEnd)
            .AddClass("dropdown-menu-dark", DarkMenu)
            .AddClass($"dropdown-menu-xs-{BreakpointXsAlignment}", BreakpointXsAlignment != null)
            .AddClass($"dropdown-menu-sm-{BreakpointSmAlignment}", BreakpointSmAlignment != null)
            .AddClass($"dropdown-menu-md-{BreakpointMdAlignment}", BreakpointMdAlignment != null)
            .AddClass($"dropdown-menu-lg-{BreakpointLgAlignment}", BreakpointLgAlignment != null)
            .AddClass($"dropdown-menu-xl-{BreakpointXlAlignment}", BreakpointXlAlignment != null)
            .AddClass($"dropdown-menu-xxl-{BreakpointXxlAlignment}", BreakpointXxlAlignment != null)
            .Build();

        [Parameter]
        public bool Show { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? HeaderText { get; set; }

        [Parameter]
        public RenderFragment? MenuContent { get; set; }

        [Parameter]
        public bool DarkMenu { get; set; }

        [Parameter]
        public bool AlignEnd { get; set; }

        [Parameter]
        public HorizontalPosition? BreakpointXsAlignment { get; set; }

        [Parameter]
        public HorizontalPosition? BreakpointSmAlignment { get; set; }

        [Parameter]
        public HorizontalPosition? BreakpointMdAlignment { get; set; }

        [Parameter]
        public HorizontalPosition? BreakpointLgAlignment { get; set; }

        [Parameter]
        public HorizontalPosition? BreakpointXlAlignment { get; set; }

        [Parameter]
        public HorizontalPosition? BreakpointXxlAlignment { get; set; }

        private void Toggle()
        {
            Show = !Show;
        }
    }
}
