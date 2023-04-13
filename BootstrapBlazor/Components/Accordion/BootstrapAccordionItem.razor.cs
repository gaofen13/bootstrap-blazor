using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapAccordionItem : BootstrapComponentBase, IDisposable
    {
        private string Classname =>
          new ClassBuilder("accordion-item")
            .AddClass(Class)
            .Build();

        private string HeaderClassname =>
            new ClassBuilder("accordion-button")
            .AddClass("collapsed", !Open)
            .Build();

        private string BodyClassname =>
            new ClassBuilder("accordion-collapse collapse")
            .AddClass("show", Open)
            .Build();

        private string BodyStylelist =>
            new StyleBuilder("transition", "opacity 0.35s ease")
            .AddStyle("opacity", Open ? "1" : "0")
            .AddStyle("height", "0", !Open)
            .AddStyle("display", "block")
            .Build();

        [CascadingParameter]
        private BootstrapAccordion? Accordion { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool Open { get; set; }

        [Parameter]
        public EventCallback<bool> OpenChanged { get; set; }

        protected override void OnInitialized()
        {
            Accordion?.AddAccordionItem(this);
            base.OnInitialized();
        }

        public void Toggle()
        {
            Open = !Open;
            _ = OpenChanged.InvokeAsync(Open);
            StateHasChanged();
        }

        void IDisposable.Dispose()
        {
            Accordion?.RemoveAccordionItem(this);
            GC.SuppressFinalize(this);
        }
    }
}
