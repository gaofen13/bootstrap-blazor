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
            .AddClass($"{ColSize?.ToDescriptionString()}")
            .AddClass($"col-{XsBreakpoint?.ToDescriptionString()}", XsBreakpoint != null)
            .AddClass($"col-{SmBreakpoint?.ToDescriptionString()}", SmBreakpoint != null)
            .AddClass($"col-{MdBreakpoint?.ToDescriptionString()}", MdBreakpoint != null)
            .AddClass($"col-{LgBreakpoint?.ToDescriptionString()}", LgBreakpoint != null)
            .AddClass($"col-{XlBreakpoint?.ToDescriptionString()}", XlBreakpoint != null)
            .AddClass($"col-{XxlBreakpoint?.ToDescriptionString()}", XxlBreakpoint != null)
            .AddClass($"offset-{OffsetXsBreakpoint?.ToDescriptionString()}", OffsetXsBreakpoint != null)
            .AddClass($"offset-{OffsetSmBreakpoint?.ToDescriptionString()}", OffsetSmBreakpoint != null)
            .AddClass($"offset-{OffsetMdBreakpoint?.ToDescriptionString()}", OffsetMdBreakpoint != null)
            .AddClass($"offset-{OffsetLgBreakpoint?.ToDescriptionString()}", OffsetLgBreakpoint != null)
            .AddClass($"offset-{OffsetXlBreakpoint?.ToDescriptionString()}", OffsetXlBreakpoint != null)
            .AddClass($"offset-{OffsetXxlBreakpoint?.ToDescriptionString()}", OffsetXxlBreakpoint != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool DefaultCol { get; set; }

        [Parameter]
        public ColSize? ColSize { get; set; }

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

        [Parameter]
        public Breakpoint.Xs? OffsetXsBreakpoint { get; set; }

        [Parameter]
        public Breakpoint.Sm? OffsetSmBreakpoint { get; set; }

        [Parameter]
        public Breakpoint.Md? OffsetMdBreakpoint { get; set; }

        [Parameter]
        public Breakpoint.Lg? OffsetLgBreakpoint { get; set; }

        [Parameter]
        public Breakpoint.Xl? OffsetXlBreakpoint { get; set; }

        [Parameter]
        public Breakpoint.Xxl? OffsetXxlBreakpoint { get; set; }
    }
}
