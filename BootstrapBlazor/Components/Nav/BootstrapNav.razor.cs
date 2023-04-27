using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapNav
    {
        private string Classname =>
          new ClassBuilder("nav")
            .AddClass("nav-tabs", IsTab)
            .AddClass("nav-pills", Pills)
            .AddClass("nav-fill", Fill)
            .AddClass("nav-justified", Justified)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool IsTab { get; set; }

        [Parameter]
        public bool Pills { get; set; }

        [Parameter]
        public bool Fill { get; set; }

        [Parameter]
        public bool Justified { get; set; }
    }
}
