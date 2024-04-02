using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BootstrapBlazor
{
    public partial class BootstrapPaginationItem : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("page-item")
            .AddClass("active", Actived)
            .AddClass("disabled", Disabled)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Actived { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
    }
}
