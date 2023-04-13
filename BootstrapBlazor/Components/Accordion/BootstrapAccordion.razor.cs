using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapAccordion : BootstrapComponentBase
    {
        private readonly List<BootstrapAccordionItem> _items = new();

        private string Classname =>
          new ClassBuilder("accordion")
            .AddClass("accordion-flush", Flush)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Flush { get; set; }

        [Parameter]
        public bool MultiOpen { get; set; }

        public void AddAccordionItem(BootstrapAccordionItem item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }

        public void RemoveAccordionItem(BootstrapAccordionItem item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
            }
        }

        public void ToggleItem(BootstrapAccordionItem item)
        {
            if (!MultiOpen & !item.Open)
            {
                foreach (var openedItem in _items.Where(i => i.Open))
                {
                    openedItem.Toggle();
                }
            }
            item.Toggle();
        }
    }
}
