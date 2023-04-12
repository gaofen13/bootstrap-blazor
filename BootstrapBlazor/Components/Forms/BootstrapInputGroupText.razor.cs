using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBlazor
{
    public partial class BootstrapInputGroupText
    {
        private string Classname =>
          new ClassBuilder("input-group-text")
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Text { get; set; }
    }
}
