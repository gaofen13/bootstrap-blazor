using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BootstrapBlazor
{
    public partial class BootstrapNavbarToggler : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("navbar-toggler")
            .AddClass(Class)
            .Build();

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
    }
}
