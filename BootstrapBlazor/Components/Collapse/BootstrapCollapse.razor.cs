using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapCollapse : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("collapse")
            .AddClass("show", Open)
            .AddClass(Class)
            .Build();

        private string BodyClassname =>
            new ClassBuilder("collapse-body")
            .AddClass(BodyClass)
            .Build();

        [Parameter]
        public bool Open { get; set; }

        [Parameter]
        public string? BodyClass { get; set; }
    }
}
