using BootstrapBlazor.Extensions;
using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapColumn : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder()
            .AddClass("col", DefaultCol)
            .AddClass($"{ColumnSize?.ToDescriptionString()}")
            .AddClass($"col-{BreakpointXs?.ToDescriptionString()}", BreakpointXs != null)
            .AddClass($"col-{BreakpointSm?.ToDescriptionString()}", BreakpointSm != null)
            .AddClass($"col-{BreakpointMd?.ToDescriptionString()}", BreakpointMd != null)
            .AddClass($"col-{BreakpointLg?.ToDescriptionString()}", BreakpointLg != null)
            .AddClass($"col-{BreakpointXl?.ToDescriptionString()}", BreakpointXl != null)
            .AddClass($"col-{BreakpointXxl?.ToDescriptionString()}", BreakpointXxl != null)
            .AddClass($"offset-{(int?)OffsetColumnSize}", OffsetColumnSize != null)
            .AddClass($"offset-{OffsetBreakpointXs?.ToDescriptionString()}", OffsetBreakpointXs != null)
            .AddClass($"offset-{OffsetBreakpointSm?.ToDescriptionString()}", OffsetBreakpointSm != null)
            .AddClass($"offset-{OffsetBreakpointMd?.ToDescriptionString()}", OffsetBreakpointMd != null)
            .AddClass($"offset-{OffsetBreakpointLg?.ToDescriptionString()}", OffsetBreakpointLg != null)
            .AddClass($"offset-{OffsetBreakpointXl?.ToDescriptionString()}", OffsetBreakpointXl != null)
            .AddClass($"offset-{OffsetBreakpointXxl?.ToDescriptionString()}", OffsetBreakpointXxl != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool DefaultCol { get; set; }

        [Parameter]
        public ColumnSize? ColumnSize { get; set; }

        [Parameter]
        public Breakpoint.Xs? BreakpointXs { get; set; }

        [Parameter]
        public Breakpoint.Sm? BreakpointSm { get; set; }

        [Parameter]
        public Breakpoint.Md? BreakpointMd { get; set; }

        [Parameter]
        public Breakpoint.Lg? BreakpointLg { get; set; }

        [Parameter]
        public Breakpoint.Xl? BreakpointXl { get; set; }

        [Parameter]
        public Breakpoint.Xxl? BreakpointXxl { get; set; }

        [Parameter]
        public ColumnSize? OffsetColumnSize { get; set; }

        [Parameter]
        public Breakpoint.Xs? OffsetBreakpointXs { get; set; }

        [Parameter]
        public Breakpoint.Sm? OffsetBreakpointSm { get; set; }

        [Parameter]
        public Breakpoint.Md? OffsetBreakpointMd { get; set; }

        [Parameter]
        public Breakpoint.Lg? OffsetBreakpointLg { get; set; }

        [Parameter]
        public Breakpoint.Xl? OffsetBreakpointXl { get; set; }

        [Parameter]
        public Breakpoint.Xxl? OffsetBreakpointXxl { get; set; }
    }
}
