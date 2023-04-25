using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapNavbar : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("navbar")
            .AddClass("fixed-top", Placement == NavbarPlacement.FixedTop)
            .AddClass("fixed-bottom", Placement == NavbarPlacement.FixedBottom)
            .AddClass("sticky-top", Placement == NavbarPlacement.StickyTop)
            .AddClass("sticky-bottom", Placement == NavbarPlacement.StickyBottom)
            .AddClass($"navbar-expand-{ExpandBreakpoint}", ExpandBreakpoint != null)
            .AddClass($"bg-{BgColor}", BgColor != null)
            .AddClass("navbar-dark", IsDarkBg)
            .AddClass(Class)
            .Build();

        [Parameter]
        public Size? ExpandBreakpoint { get; set; }

        [Parameter]
        public Color? BgColor { get; set; }

        [Parameter]
        public bool IsDarkBg { get; set; }

        [Parameter]
        public NavbarPlacement? Placement { get; set; }
    }

    public enum NavbarPlacement
    {
        FixedTop,
        FixedBottom,
        StickyTop,
        StickyBottom
    }
}
