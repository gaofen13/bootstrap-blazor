using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace BootstrapBlazor
{
    public partial class BootstrapCheckbox : BootstrapInputBase<bool>
    {
        private string Classname =>
          new ClassBuilder("form-check-input")
            .AddClass("is-invalid", IsValid == false)
            .AddClass("is-valid", IsValid == true)
            .AddClass(Class)
            .Build();

        private string ContainerClass =>
          new ClassBuilder("form-check")
            .AddClass("is-invalid", IsValid == false)
            .AddClass("is-valid", IsValid == true)
            .AddClass("form-switch", IsSwitch)
            .Build();

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public bool IsSwitch { get; set; }

        protected override bool TryParseValueFromString(string? value, out bool result, [NotNullWhen(false)] out string? validationErrorMessage) => throw new NotSupportedException($"This component does not parse string inputs. Bind to the '{nameof(Value)}' property, not '{nameof(CurrentValueAsString)}'.");
    }
}
