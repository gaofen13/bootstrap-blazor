using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapDropdown : BootstrapComponentBase
    {
        private string Classname =>
            new ClassBuilder("btn-group dropdown")
            .AddClass(Class)
            .Build();

        private string Stylelist =>
            new StyleBuilder("display", "inline-block")
            .AddStyle(Style)
            .Build();

        private string BtnClassname =>
            new ClassBuilder("btn")
            .AddClass($"btn-{Size}")
            .AddClass("dropdown-toggle", !SplitButton)
            .AddClass($"btn-{ButtonColor}", ButtonColor != null)
            .Build();

        private string SplitBtnClassname =>
            new ClassBuilder("btn dropdown-toggle dropdown-toggle-split")
            .AddClass($"btn-{ButtonColor}", ButtonColor != null)
            .AddClass($"btn-{Size}")
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
        public string? ButtonText { get; set; }

        [Parameter]
        public string? HeaderText { get; set; }

        [Parameter]
        public RenderFragment? ActiveContent { get; set; }

        [Parameter]
        public RenderFragment? MenuContent { get; set; }

        [Parameter]
        public bool SplitButton { get; set; }

        [Parameter]
        public bool DarkMenu { get; set; }

        [Parameter]
        public Size Size { get; set; } = Size.md;

        [Parameter]
        public Color? ButtonColor { get; set; }

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

        private void OnclickTextButton()
        {
            if (!SplitButton)
            {
                Toggle();
            }
        }

        private void Toggle()
        {
            Show = !Show;
        }
    }
}
