using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace BootstrapBlazor
{
    public partial class BootstrapTextArea : BootstrapInputBase<string?>
    {
        private string Classname =>
          new ClassBuilder("form-control")
            .AddClass("is-invalid", IsValid == false)
            .AddClass("is-valid", IsValid == true)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool AutoFocus { get; set; }

        [Parameter]
        public string? Placeholder { get; set; }

        [Parameter]
        public int Rows { get; set; } = 5;

        protected override bool TryParseValueFromString(string? value, out string? result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
