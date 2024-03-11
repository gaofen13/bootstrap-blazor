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

        private static string CollapseClassname =>
            new ClassBuilder("accordion-collapse")
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
