using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBlazor
{
    public partial class BootstrapNavItem : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("nav-item")
            .AddClass(Class)
            .Build();

        private string LinkClassname =>
            new ClassBuilder("nav-link")
            .AddClass("disabled", Disabled)
            .AddClass("active", Active)
            .Build();

        [Parameter]
        public bool Active { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string? Href { get; set; }
    }
}
