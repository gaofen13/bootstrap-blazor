using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BootstrapBlazor
{
    public partial class BootstrapNavMenuItem
    {
        private string Classname =>
            new ClassBuilder("navmenu-item list-unstyled")
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Href { get; set; }

        [Parameter]
        public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;
    }
}