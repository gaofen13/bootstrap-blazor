using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapHeadTr<TItem> : BootstrapComponentBase
    {
        private bool Checked => SelectedItems?.Count() == Items?.Count();

        [CascadingParameter]
        public ITable<TItem>? Table { get; set; }

        [Parameter]
        public IEnumerable<TItem>? SelectedItems { get; set; }

        [Parameter]
        public bool MultiSelection { get; set; }

        [Parameter]
        public IEnumerable<TItem>? Items { get; set; }

        private void OnCheckedChanged(bool @checked)
        {
            if (@checked)
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
