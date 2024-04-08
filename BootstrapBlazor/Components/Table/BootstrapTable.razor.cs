using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapTable<TItem> : ITable<TItem>
    {
        private IEnumerable<TItem> _items = [];
        private List<TItem> _selectedItems = [];

        private string Classname =>
          new ClassBuilder("table")
            .AddClass($"table-{Color}", Color != null)
            .AddClass("table-hover", Hoverable)
            .AddClass("table-striped", Striped)
            .AddClass("table-bordered", Bordered)
            .AddClass("table-striped-columns", StripedColumns)
            .AddClass($"border-{BorderColor}", BorderColor != null)
            .AddClass("table-responsive", Responsive)
            .AddClass("table-borderless", Borderless)
            .AddClass("table-sm", Compacted)
            .AddClass(Class)
            .Build();

        private static TItem DefaultValue
        {
            get
            {
                TItem? item = default;
                if (item == null)
                {
                    return Activator.CreateInstance<TItem>();
                }
                else
                {
                    return item;
                }
            }
        }

        [Parameter]
        public bool Hoverable { get; set; }

        [Parameter]
        public bool Striped { get; set; }

        [Parameter]
        public bool StripedColumns { get; set; }

        [Parameter]
        public bool Bordered { get; set; }

        [Parameter]
        public bool Borderless { get; set; }

        [Parameter]
        public bool Compacted { get; set; }

        [Parameter]
        public bool Responsive { get; set; }

        [Parameter]
        public Color? BorderColor { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
#pragma warning disable BL0007 // Component parameters should be auto properties
        public IEnumerable<TItem>? Items
#pragma warning restore BL0007 // Component parameters should be auto properties
        {
            get => _items;
            set
            {
                if (!EqualityComparer<IEnumerable<TItem>>.Default.Equals(value, _items))
                {
                    _items = value ?? [];
                    ClearSelectedItems();
                }
            }
        }

        [Parameter]
        public bool MultiSelection { get; set; }

        [Parameter]
#pragma warning disable BL0007 // Component parameters should be auto properties
        public IEnumerable<TItem> SelectedItems
#pragma warning restore BL0007 // Component parameters should be auto properties
        {
            get => _selectedItems;
            set
            {
                if (!EqualityComparer<IEnumerable<TItem>>.Default.Equals(value, _selectedItems))
                {
                    _selectedItems = value?.ToList() ?? [];
                    _ = SelectedItemsChanged.InvokeAsync(_selectedItems);
                }
            }
        }

        [Parameter]
        public EventCallback<IEnumerable<TItem>> SelectedItemsChanged { get; set; }

        [Parameter, EditorRequired]
        public RenderFragment<TItem>? Columns { get; set; }

        [Parameter]
        public RenderFragment? THeadContent { get; set; }

        public void AddSelectedItem(TItem item)
        {
            if (!_selectedItems.Contains(item))
            {
                _selectedItems.Add(item);
                _ = SelectedItemsChanged.InvokeAsync(_selectedItems);
            }
        }

        public void RemoveSelectedItem(TItem item)
        {
            if (_selectedItems.Contains(item))
            {
                _selectedItems.Remove(item);
                _ = SelectedItemsChanged.InvokeAsync(_selectedItems);
            }
        }

        public void SelectAllItems()
        {
            SelectedItems = _items;
        }

        public void ClearSelectedItems()
        {
            SelectedItems = [];
        }
    }
}
