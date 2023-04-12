using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapTable : BootstrapComponentBase
    {
        protected string Classname =>
          new ClassBuilder("table")
            .AddClass($"table-{Color}", Color != null)
            .AddClass("table-hover", Hoverable)
            .AddClass("table-striped", Striped)
            .AddClass("table-bordered", Bordered)
            .AddClass("table-striped-columns", StripedColumns)
            .AddClass($"border-{BorderColor}", BorderColor != null)
            .AddClass("table-responsive", Responsive)
            .AddClass("table-borderless", Borderless)
            .AddClass("table-sm", Compacted)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Hoverable { get; set; }

        [Parameter]
        public bool Striped { get; set; }

        [Parameter]
        public bool StripedColumns { get; set; }

        [Parameter]
        public bool Bordered { get; set; }

        [Parameter]
        public bool Borderless { get; set; }

        [Parameter]
        public bool Compacted { get; set; }

        [Parameter]
        public bool Responsive { get; set; }

        [Parameter]
        public Color? BorderColor { get; set; }

        [Parameter]
        public Color? Color { get; set; }
    }
}
