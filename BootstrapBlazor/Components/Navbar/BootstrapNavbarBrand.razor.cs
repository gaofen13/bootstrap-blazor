using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapNavbarBrand : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("navbar-brand")
            .AddClass(Class)
            .Build();

        [Parameter]
        public string HtmlTag { get; set; } = "span";

        [Parameter]
        public string? Href { get; set; }

        protected override void OnInitialized()
        {
            if (Href != null)
            {
                HtmlTag = "a";
            }
            base.OnInitialized();
        }
    }
}
