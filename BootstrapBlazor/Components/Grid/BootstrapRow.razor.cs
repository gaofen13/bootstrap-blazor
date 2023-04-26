using BootstrapBlazor.Extensions;
using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapRow : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("row")
            .AddClass($"row-{RowColumns?.ToDescriptionString()}", RowColumns != null)
            .AddClass($"row-cols-{BreakpointXs?.ToDescriptionString()}", BreakpointXs != null)
            .AddClass($"row-cols-{MdBreakpoint?.ToDescriptionString()}", MdBreakpoint != null)
            .AddClass($"row-cols-{BreakpointSm?.ToDescriptionString()}", BreakpointSm != null)
            .AddClass($"row-cols-{BreakpointLg?.ToDescriptionString()}", BreakpointLg != null)
            .AddClass($"row-cols-{BreakpointXl?.ToDescriptionString()}", BreakpointXl != null)
            .AddClass($"row-cols-{BreakpointXxl?.ToDescriptionString()}", BreakpointXxl != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public RowColumns? RowColumns { get; set; }

        [Parameter]
        public Breakpoint.Xs? BreakpointXs { get; set; }

        [Parameter]
        public Breakpoint.Sm? BreakpointSm { get; set; }

        [Parameter]
        public Breakpoint.Md? MdBreakpoint { get; set; }

        [Parameter]
        public Breakpoint.Lg? BreakpointLg { get; set; }

        [Parameter]
        public Breakpoint.Xl? BreakpointXl { get; set; }

        [Parameter]
        public Breakpoint.Xxl? BreakpointXxl { get; set; }
    }
}
