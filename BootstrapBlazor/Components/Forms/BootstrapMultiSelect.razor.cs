using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace BootstrapBlazor
{
    public partial class BootstrapMultiSelect<TValue> : BootstrapInputBase<TValue>
    {
        private string Classname =>
          new ClassBuilder("form-select")
            .AddClass($"form-select-{Size}", Size != null)
            .AddClass("is-invalid", IsValid == false)
            .AddClass("is-valid", IsValid == true)
            .AddClass(Class)
            .Build();

        [Parameter]
        public int Height { get; set; }

        [Parameter]
        public bool AutoFocus { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
            => this.TryParseSelectableValueFromString(value, out result, out validationErrorMessage);

        private void SetValueAsStringArray(string?[]? value)
        {
            Value = BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var result)
                ? result
                : default;
        }
    }
}
