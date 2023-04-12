using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapAlertLink : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("alert-link")
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Href { get; set; }
    }
}
