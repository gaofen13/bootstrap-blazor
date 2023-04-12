using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapButton : BootstrapButtonBase
    {
        private string Classname =>
          new ClassBuilder("btn")
            .AddClass($"btn-{Color}", !Outline)
            .AddClass($"btn-outline-{Color}", Outline)
            .AddClass($"btn-{Size}", Size != null)
            .AddClass("btn-disabled", Disabled)
            .AddClass("btn-outline", Outline)
            .AddClass("text-nowrap", TextNowrap)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool StopPropagation { get; set; } = true;

        [Parameter]
        public Size? Size { get; set; }

        [Parameter]
        public bool Outline { get; set; }

        [Parameter]
        public bool TextNowrap { get; set; }
    }
}
