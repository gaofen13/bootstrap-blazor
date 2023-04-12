using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapFormField : BootstrapComponentBase
    {
        private bool? _isValid;
        private string? _invalidText;

        private string Classname =>
          new ClassBuilder("row")
            .AddClass(Class)
            .Build();

        private string LabelClassname =>
            new ClassBuilder("col-form-label")
            .AddClass(LabelClass)
            .Build();

        [Parameter]
        public string? ForId { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public string? LabelClass { get; set; }

        [Parameter]
        public string? InvalidText { get; set; }

        [Parameter]
        public string? ValidText { get; set; }

        protected override void OnInitialized()
        {
            if (!string.IsNullOrWhiteSpace(InvalidText))
            {
                _invalidText = InvalidText;
            }
        }

        public void SetInvalid(string? error)
        {
            if (_isValid!=false)
            {
                _isValid = false;
                if (string.IsNullOrWhiteSpace(InvalidText))
                {
                    _invalidText = error;
                }
            }
        }

        public void SetValid()
        {
            if (_isValid!=true)
            {
                _isValid = true;
            }
        }
    }
}
