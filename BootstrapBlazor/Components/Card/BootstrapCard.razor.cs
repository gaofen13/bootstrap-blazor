using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapCard : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("card")
            .AddClass(Class)
            .Build();

        [Parameter]
        public RenderFragment? CardHeader { get; set; }

        [Parameter]
        public RenderFragment? CardBody { get; set; }

        [Parameter]
        public RenderFragment? CardFooter { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? Subtitle { get; set; }
    }
}
