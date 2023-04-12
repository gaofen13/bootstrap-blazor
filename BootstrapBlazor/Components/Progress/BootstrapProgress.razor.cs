using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapProgress : BootstrapComponentBase
    {
        private int _value;

        private string Classname =>
          new ClassBuilder("progress-bar")
            .AddClass($"bg-{Color}", Color != null)
            .AddClass("progress-bar-striped", Striped)
            .AddClass("progress-bar-animated", Animated)
            .AddClass(Class)
            .Build();

        private string Stylelist =>
            new StyleBuilder()
            .AddStyle("width", $"{_value}%")
            .AddStyle(Style)
            .Build();

        [Parameter]
#pragma warning disable BL0007 // Component parameters should be auto properties
        public int Value
#pragma warning restore BL0007 // Component parameters should be auto properties
        {
            get => _value;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new NotSupportedException("The Value parameter should be between 0 and 100");
                }
                _value = value;
            }
        }

        [Parameter]
        public bool Striped { get; set; }

        [Parameter]
        public bool Animated { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public bool ShowLabel { get; set; }
    }
}
