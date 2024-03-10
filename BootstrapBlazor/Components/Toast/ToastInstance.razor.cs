using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class ToastInstance
    {
        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public ToastOptions? Options { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
