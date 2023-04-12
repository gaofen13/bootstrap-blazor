using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapButtonGroup : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("btn-group")
            .AddClass("btn-group-vertical", Vertical)
            .AddClass($"btn-group-{Size}", Size != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public Size? Size { get; set; }

        [Parameter]
        public bool Vertical { get; set; }
    }
}
