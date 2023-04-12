using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace BootstrapBlazor
{
    public partial class BootstrapRadioGroup<TValue> : BootstrapInputBase<TValue>
    {
        private BootstrapRadio<TValue>? _checkedRadio;

        private readonly string _defaultGroupName = Guid.NewGuid().ToString("N");

        public string RadioName => Name ?? _defaultGroupName;

        private string Classname =>
          new ClassBuilder("form-control")
            .AddClass("is-invalid", IsValid == false)
            .AddClass("is-valid", IsValid == true)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Vertical { get; set; }

        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
            => this.TryParseSelectableValueFromString(value, out result, out validationErrorMessage);

        public void OnCheckedRadioChanged(BootstrapRadio<TValue> radio)
        {
            _checkedRadio = radio;
            if (!EqualityComparer<TValue>.Default.Equals(radio.Value, Value))
            {
                Value = radio.Value;
            }
        }
    }
}
