using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BootstrapBlazor
{
    public partial class BootstrapTreeViewItem<TValue> : BootstrapComponentBase
    {
        private bool _opened;

        private bool _actived;

        private bool _checked;

        public bool Actived => _actived;

        public bool Checked => _checked;

        private bool HasChildren => ChildContent is not null;

        private string Classname =>
            new ClassBuilder("treeview-item")
            .AddClass("treeview-item-open", _opened)
            .AddClass(Class)
            .Build();

        private string TitleClassname =>
            new ClassBuilder("treeview-item-title list-group-item list-group-item-action")
            .AddClass("active", Actived)
            .Build();

        [CascadingParameter]
        private BootstrapTreeView<TValue> Root { get; set; } = default!;

        [CascadingParameter]
        private BootstrapTreeViewItem<TValue>? Parent { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public TValue? Value { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Root.MultiSelection)
            {
                if (Root.SelectedValues.Contains(Value))
                {
                    _checked = true;
                    if (Parent is not null)
                    {
                        await Parent.OpenAsync();
                    }
                }
            }
            else
            {
                if (Value?.Equals(Root.SelectedValue) == true)
                {
                    _actived = true;
                    await Root.SetActivedItemAsync(this);
                    if (Parent is not null)
                    {
                        await Parent.OpenAsync();
                    }
                }
            }
        }

        private void OnOpenChanged(MouseEventArgs args)
        {
            if (HasChildren)
            {
                _opened = !_opened;
            }
        }

        private async void OnCheckedChanged(bool @checked)
        {
            _checked = !_checked;
            await Root.OnCheckedItemsChangedAsync(this);
        }

        private async Task OnClickItemAsync(MouseEventArgs args)
        {
            if (!Root.MultiSelection)
            {
                SetActive(!_actived);
                await Root.SetActivedItemAsync(this);
            }
        }

        internal void SetActive(bool actived)
        {
            if (_actived != actived)
            {
                _actived = actived;
                StateHasChanged();
            }
        }

        public async Task OpenAsync()
        {
            if (!_opened)
            {
                _opened = true;
                await InvokeAsync(StateHasChanged);
                if (Parent != null)
                {
                    await Parent.OpenAsync();
                }
            }
        }
    }
}