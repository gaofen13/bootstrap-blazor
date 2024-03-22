using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapNavbarCollaspeNav : BootstrapComponentBase
    {
        private bool _show;

        private string Classname =>
          new ClassBuilder("navbar-collapse")
            .AddClass(Class)
            .Build();

        private string NavClassname =>
            new ClassBuilder("navbar-nav")
            .AddClass("navbar-nav-scroll", Scrolling)
            .Build();

        [Parameter]
#pragma warning disable BL0007 // Component parameters should be auto properties
        public bool Show
#pragma warning restore BL0007 // Component parameters should be auto properties
        {
            get => _show;
            set
            {
                if (_show != value)
                {
                    _show = value;
                    ShowChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<bool> ShowChanged { get; set; }

        [Parameter]
        public bool Scrolling { get; set; }

        [Parameter]
        public bool AutoClose { get; set; }
    }
}
