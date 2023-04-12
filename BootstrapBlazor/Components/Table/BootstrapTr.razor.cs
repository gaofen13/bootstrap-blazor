using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace BootstrapBlazor
{
    public partial class BootstrapTr<TItem> : BootstrapComponentBase
    {
        private string TrClass =>
            new ClassBuilder()
            .AddClass("table-active", Checked)
            .AddClass($"table-{Color}", Color != null)
            .AddClass(Class)
            .Build();

        private bool Checked => SelectedItems?.Contains(Item) == true;

        [CascadingParameter]
        public ITable<TItem>? Table { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public bool MultiSelection { get; set; }

        [Parameter]
        public IEnumerable<TItem>? SelectedItems { get; set; }

        [Parameter]
        [NotNull]
        public TItem? Item { get; set; }

        private void OnCheckedChanged(bool @checked)
        {
            if (@checked)
            {
                Table?.AddSelectedItem(Item);
            }
            else
            {
                Table?.RemoveSelectedItem(Item);
            }
        }
    }
}
