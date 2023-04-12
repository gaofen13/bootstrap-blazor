using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapModal : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("modal-body")
            .AddClass(Class)
            .Build();

        [Parameter]
        public RenderFragment? ActionsContent { get; set; }
    }
}
