using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapRow : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("row")
            .AddClass("row-cols-auto", RowColsAuto)
            .AddClass($"row-cols-{RowCols}", RowCols > 0 && !RowColsAuto)
            .AddClass($"row-cols-{Breakpoint}-{BreakpointRowCols}", BreakpointRowCols > 0 && Breakpoint != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public int RowCols { get; set; }

        [Parameter]
        public bool RowColsAuto { get; set; }

        [Parameter]
        public Size? Breakpoint { get; set; }

        [Parameter]
        public int BreakpointRowCols { get; set; }
    }
}
