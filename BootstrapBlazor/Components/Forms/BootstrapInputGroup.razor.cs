using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapInputGroup : BootstrapComponentBase
    {
        private bool? _isValid;
        private string? _invalidText;

        private string Classname =>
          new ClassBuilder("input-group has-validation")
            .AddClass("flex-nowrap", Nowrap)
            .AddClass($"input-group-{Size}", Size != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Nowrap { get; set; }

        [Parameter]
        public Size? Size { get; set; }

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
            if (_isValid != false)
            {
                _isValid = false;
                if (string.IsNullOrWhiteSpace(InvalidText))
                {
                    _invalidText = error;
                }
                StateHasChanged();
            }
        }

        public void SetValid()
        {
            if (_isValid != true)
            {
                _isValid = true;
                StateHasChanged();
            }
        }
    }
}
