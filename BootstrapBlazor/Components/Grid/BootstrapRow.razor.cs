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
            .AddClass($"row-cols-{XsBreakpoint?.ToDescriptionString()}", XsBreakpoint != null)
            .AddClass($"row-cols-{MdBreakpoint?.ToDescriptionString()}", MdBreakpoint != null)
            .AddClass($"row-cols-{SmBreakpoint?.ToDescriptionString()}", SmBreakpoint != null)
            .AddClass($"row-cols-{LgBreakpoint?.ToDescriptionString()}", LgBreakpoint != null)
            .AddClass($"row-cols-{XlBreakpoint?.ToDescriptionString()}", XlBreakpoint != null)
            .AddClass($"row-cols-{XxlBreakpoint?.ToDescriptionString()}", XxlBreakpoint != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public RowColumns? RowColumns { get; set; }

        [Parameter]
        public Breakpoint.Xs? XsBreakpoint { get; set; }

        [Parameter]
        public Breakpoint.Sm? SmBreakpoint { get; set; }

        [Parameter]
        public Breakpoint.Md? MdBreakpoint { get; set; }

        [Parameter]
        public Breakpoint.Lg? LgBreakpoint { get; set; }

        [Parameter]
        public Breakpoint.Xl? XlBreakpoint { get; set; }

        [Parameter]
        public Breakpoint.Xxl? XxlBreakpoint { get; set; }
    }
}
