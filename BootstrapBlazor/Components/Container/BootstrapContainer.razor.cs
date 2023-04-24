using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapContainer : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder($"container{(Fluid ? "-fluid" : "")}")
            .AddClass($"container-{Breakpoint}", Breakpoint != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Fluid { get; set; }

        [Parameter]
        public Size? Breakpoint { get; set; }
    }
}
