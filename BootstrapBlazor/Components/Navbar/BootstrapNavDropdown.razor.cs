using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBlazor
{
    public partial class BootstrapNavDropdown : BootstrapComponentBase
    {
        private string Classname =>
            new ClassBuilder("nav-item dropdown")
            .AddClass(Class)
            .Build();

        private string MenuClassname =>
            new ClassBuilder("dropdown-menu")
            .AddClass("show", Show)
            .AddClass($"text-{TextAlignment}")
            .AddClass($"{ItemAlignment}-0", ItemAlignment != HorizontalPosition.center)
            .AddClass("start-50 translate-middle-x", ItemAlignment == HorizontalPosition.center)
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
        public HorizontalPosition ItemAlignment { get; set; } = HorizontalPosition.start;

        [Parameter]
        public HorizontalPosition TextAlignment { get; set; } = HorizontalPosition.start;

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

        private void OnclickActivator()
        {
            Show = !Show;
        }
    }
}
