using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBlazor
{
    public partial class BootstrapAlert : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("alert")
            .AddClass($"alert-{AlertLevel}")
            .AddClass("alert-dismissible", ShowCloseBtn)
            .AddClass(Class)
            .Build();

        [Parameter]
        public Color AlertLevel { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? Message { get; set; }

        [Parameter]
        public RenderFragment? IconContent { get; set; }

        [Parameter]
        public bool ShowCloseBtn { get; set; }

        [Parameter]
        public EventCallback OnClickCloseBtn { get; set; }
    }
}
