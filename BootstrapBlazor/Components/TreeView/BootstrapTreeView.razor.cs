using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapTreeView<TValue> : BootstrapComponentBase
    {
        private BootstrapTreeViewItem<TValue>? _activedItem;

        private string Classname =>
            new ClassBuilder("treeview list-group")
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool MultiSelection { get; set; }

        [Parameter]
        public TValue? SelectedValue { get; set; }

        [Parameter]
        public EventCallback<TValue?> SelectedValueChanged { get; set; }

        [Parameter]
        public IEnumerable<TValue?> SelectedValues { get; set; } = [];

        [Parameter]
        public EventCallback<IEnumerable<TValue?>> SelectedValuesChanged { get; set; }

        internal async Task OnCheckedItemsChangedAsync(BootstrapTreeViewItem<TValue> item)
        {
            var selectedValues = SelectedValues.ToList();
            if (item.Checked)
            {
                if (selectedValues.Contains(item.Value))
                {
                    return;
                }
                selectedValues.Add(item.Value);
            }
            else
            {
                selectedValues.Remove(item.Value);
            }
            SelectedValues = selectedValues;
            await SelectedValuesChanged.InvokeAsync(SelectedValues);
        }

        internal async Task SetActivedItemAsync(BootstrapTreeViewItem<TValue> item)
        {
            if (item.Actived)
            {
                _activedItem?.SetActive(false);
                _activedItem = item;
            }
            else
            {
                _activedItem = null;
            }
            SelectedValue = _activedItem is null ? default : _activedItem.Value;
            await SelectedValueChanged.InvokeAsync(SelectedValue);
        }
    }
}