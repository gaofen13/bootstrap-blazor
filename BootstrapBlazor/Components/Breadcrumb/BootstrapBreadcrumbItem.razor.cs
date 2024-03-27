using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapBreadcrumbItem
    {
        private string Classname =>
            new ClassBuilder("breadcrumb-item")
            .AddClass("active", Actived)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Actived { get; set; }

        [Parameter]
        public string? Href { get; set; }
    }
}