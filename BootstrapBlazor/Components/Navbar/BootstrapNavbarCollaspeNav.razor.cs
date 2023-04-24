using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapNavbarCollaspeNav : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("collapse navbar-collapse")
            .AddClass("show", Show)
            .AddClass(Class)
            .Build();

        private string NavClassname =>
            new ClassBuilder("navbar-nav")
            .AddClass("navbar-nav-scroll", Scrolling)
            .Build();

        [Parameter]
        public bool Show { get; set; }

        [Parameter]
        public bool Scrolling { get; set; }
    }
}
