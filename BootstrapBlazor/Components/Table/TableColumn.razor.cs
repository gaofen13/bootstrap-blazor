using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class TableColumn : BootstrapComponentBase
    {
        protected string Classname =>
            new ClassBuilder()
            .AddClass("mdui-table-col-numeric", AlignRight)
            .Build();

        [CascadingParameter(Name = "RenderMode")]
        public RenderMode Mode { get; set; }

        [Parameter]
        public bool Visible { get; set; } = true;

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool AlignRight { get; set; }

        [Parameter]
        public RenderFragment? TitleContent { get; set; }

        public enum RenderMode
        {
            Head,
            Body
        }
    }
}
