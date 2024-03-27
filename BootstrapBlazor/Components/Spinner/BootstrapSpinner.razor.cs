using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapSpinner
    {
        private string Classname =>
            new ClassBuilder("spinner-border")
            .AddClass($"spinner-{(Growing ? "grow" : "border")}-sm", Small)
            .AddClass($"text-{Color}", Color is not null)
            .AddClass("spinner-grow", Growing)
            .AddClass(Class)
            .Build();

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public bool Small { get; set; }

        [Parameter]
        public bool Growing { get; set; }
    }
}