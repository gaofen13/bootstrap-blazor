using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapDropdownItem : BootstrapComponentBase
    {
        private string Classname =>
            new ClassBuilder("dropdown-item")
            .AddClass("disabled", Disabled)
            .AddClass("active", Active)
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Href { get; set; }

        [Parameter]
        public bool Active { get; set; }

        [Parameter]
        public bool Disabled { get; set; }
    }
}
