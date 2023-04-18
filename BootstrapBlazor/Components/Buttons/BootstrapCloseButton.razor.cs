using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BootstrapBlazor
{
    public partial class BootstrapCloseButton : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("btn-close")
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
    }
}
