using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapListGroup : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("list-group")
            .AddClass("list-group-numbered", Numbered)
            .AddClass($"list-group-horizontal{(HorizontalBreakpoint == null ? "" : $"-{HorizontalBreakpoint}")}", Horizontal)
            .AddClass("list-group-flush", Flush)
            .AddClass(Class)
            .Build();

        private string HtmlTag { get; set; } = "ul";

        [Parameter]
        public bool Actionable { get; set; }

        [Parameter]
        public bool Numbered { get; set; }

        [Parameter]
        public bool Horizontal { get; set; }

        [Parameter]
        public Size? HorizontalBreakpoint { get; set; }

        [Parameter]
        public bool Flush { get; set; }

        protected override void OnInitialized()
        {
            if (Actionable)
            {
                HtmlTag = "div";
            }
            base.OnInitialized();
        }
    }
}
