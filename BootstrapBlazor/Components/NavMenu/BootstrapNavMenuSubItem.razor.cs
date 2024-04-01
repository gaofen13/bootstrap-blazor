using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapNavMenuSubItem
    {
        private string Classname =>
            new ClassBuilder("navmenu-sub list-unstyled")
            .AddClass("navmenu-sub-open", Open)
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? TitleContent { get; set; }

        [Parameter]
        public bool Open { get; set; }
    }
}