using BootstrapBlazor.Generators;
using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor.Shared.Components
{
    public partial class ExampleSnippet
    {
        private bool _showCode;

        private string Classname =>
            new ClassBuilder("example")
            .AddClass("example-showcode", _showCode || FixCode)
            .AddClass("example-show", !HideExample)
            .Build();

        [Parameter]
        public string Label { get; set; } = "Example";

        [Parameter, EditorRequired]
        public Type Component { get; set; } = default!;

        [Parameter]
        public IDictionary<string, object>? ComponentParameters { get; set; }

        [Parameter]
        public bool FixCode { get; set; }

        [Parameter]
        public bool HideExample { get; set; }

        [Parameter]
        public string Language { get; set; } = "language-cshtml-razor";

        private string? CodeContents { get; set; }

        protected override void OnInitialized()
        {
            SetCodeContents();
            base.OnInitialized();
        }

        protected void SetCodeContents()
        {
            try
            {
                CodeContents = DemoSnippets.GetRazor(Component.Name);
            }
            catch
            {
                //Do Nothing
            }
        }

        private void ToggleCode()
        {
            if (HideExample || FixCode)
            {
                return;
            }
            _showCode = !_showCode;
        }
    }
}