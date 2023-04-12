using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapColumn : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder()
            .AddClass("col", Col)
            .AddClass($"col-{Colspan}", Colspan > 0)
            .AddClass($"col-{Breakpoint}", Breakpoint != null)
            .AddClass($"col-{Breakpoint}-{BreakpointColspan}", BreakpointColspan > 0 && Breakpoint != null)
            .AddClass($"offset-{Breakpoint}-{Offset}", Offset > 0 && Breakpoint != null)
            .AddClass(Class)
            .Build();

        /// <summary>
        /// Default true, add class .col
        /// </summary>
        [Parameter]
        public bool Col { get; set; } = true;

        [Parameter]
        public int Colspan { get; set; }

        [Parameter]
        public Size? Breakpoint { get; set; }

        [Parameter]
        public int BreakpointColspan { get; set; }

        [Parameter]
        public int Offset { get; set; }
    }
}
