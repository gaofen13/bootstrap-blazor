using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapRadio<TValue> : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("form-check-input")
            .AddClass(Class)
            .Build();

        private string ContainerClass =>
          new ClassBuilder("form-check")
            .AddClass("form-check-inline", RadioGroup?.Vertical != true)
            .Build();

        [CascadingParameter]
        private BootstrapRadioGroup<TValue>? RadioGroup { get; set; }

        [Parameter]
        public string? Id { get; set; }

        [Parameter]
        public string? Name { get; set; }

        [Parameter]
        public bool Checked { get; set; }

        [Parameter]
        public TValue? Value { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string? Label { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (RadioGroup != null)
            {
                Checked = EqualityComparer<TValue>.Default.Equals(Value, RadioGroup.Value);
            }
        }

        private void OnRadioChanged(ChangeEventArgs args)
        {
            RadioGroup?.OnCheckedRadioChanged(this);
        }
    }
}
