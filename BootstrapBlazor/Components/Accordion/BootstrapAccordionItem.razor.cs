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

        private string CollapseClassname =>
            new ClassBuilder("accordion-collapse collapse")
            .AddClass("show", Open)
            .Build();

        private string CollapseStylelist =>
            new StyleBuilder("display", "grid")
            .AddStyle("overflow", "hidden")
            .AddStyle("height", "0", !Open)
            .AddStyle("transition", "all 0.35s ease")
            .AddStyle("grid-auto-rows", Open ? "1fr" : "0fr")
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
            Accordion?.AddItem(this);
            base.OnInitialized();
        }

        private void OnToggleItem()
        {
            if (Open)
            {
                CloseItem();
            }
            else
            {
                if (Accordion?.MultiOpen == false)
                {
                    Accordion.CloseAllItems();
                }
                OpenItem();
            }
        }

        private void OpenItem()
        {
            Open = true;
            _ = OpenChanged.InvokeAsync(true);
            StateHasChanged();
        }

        internal void CloseItem()
        {
            Open = false;
            _ = OpenChanged.InvokeAsync(false);
            StateHasChanged();
        }

        void IDisposable.Dispose()
        {
            Accordion?.RemoveItem(this);
            GC.SuppressFinalize(this);
        }
    }
}
