using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapHeadTr<TItem> : BootstrapComponentBase
    {
        private bool Checked => Table?.SelectedItems?.Count() == Table?.Items?.Count();

        [CascadingParameter]
        public ITable<TItem>? Table { get; set; }

        private void OnCheckedChanged(ChangeEventArgs args)
        {
            if (args.Value == null)
            {
                return;
            }
            if ((bool)args.Value)
            {
                Table?.SelectAllItems();
            }
            else
            {
                Table?.ClearSelectedItems();
            }
        }
    }
}
