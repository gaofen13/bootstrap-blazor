using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace BootstrapBlazor
{
    public partial class BootstrapTr<TItem> : BootstrapComponentBase
    {
        private string Classname =>
            new ClassBuilder()
            .AddClass("table-active", Checked)
            .AddClass($"table-{Color}", Color != null)
            .AddClass(Class)
            .Build();

        private bool Checked => Table?.SelectedItems?.Contains(Item) == true;

        [CascadingParameter]
        public ITable<TItem>? Table { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        [NotNull]
        public TItem? Item { get; set; }

        private void OnCheckedChanged(ChangeEventArgs args)
        {
            if (args.Value == null)
            {
                return;
            }
            if ((bool)args.Value)
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
