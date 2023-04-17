using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapModal : BootstrapComponentBase
    {
        private ModalOptions _options = new();
        private bool _clickBackgroundCancel;

        private string Classname =>
          new ClassBuilder("modal fade")
            .AddClass("show", ModalInstance != null || Visible)
            .AddClass(Class)
            .Build();

        private string Stylelist =>
            new StyleBuilder()
            .AddStyle("display", "block", ModalInstance != null || Visible)
            .AddStyle(Style)
            .Build();

        private string DialogClassname =>
            new ClassBuilder("modal-dialog")
            .AddClass("modal-dialog-scrollable", _options.Scrollable)
            .AddClass("modal-dialog-centered ", _options.Centered)
            .AddClass("modal-fullscreen", _options.Fullscreen)
            .AddClass($"modal-{_options.Size}")
            .Build();

        private string BodyClassname =>
          new ClassBuilder("modal-body")
            .AddClass(Class)
            .Build();

        [CascadingParameter] private BootstrapModalContainer? ModalContainer { get; set; }

        [CascadingParameter] private ModalInstance? ModalInstance { get; set; }

        [Parameter] public ModalOptions? Options { get; set; }

        [Parameter, EditorRequired] public string? Title { get; set; }

        [Parameter] public bool Visible { get; set; }

        [Parameter] public EventCallback<bool> VisibleChanged { get; set; }

        [Parameter] public RenderFragment? ActionsContent { get; set; }

        protected override void OnInitialized()
        {
            _clickBackgroundCancel = Options?.StaticBackdrop == false || ModalContainer?.GlobalOptions?.StaticBackdrop == false;
            var options = Options ?? ModalContainer?.GlobalOptions;
            if (options is not null)
            {
                _options = options;
            }
            base.OnInitialized();
        }

        private async Task OnClickCloseBtn()
        {
            await CancelAsync();
        }

        private async Task OnClickBackgroundAsync()
        {
            if (_clickBackgroundCancel)
            {
                await CancelAsync();
            }
        }

        private async Task CancelAsync()
        {
            if (ModalInstance != null)
            {
                ModalInstance.Cancel();
            }
            else
            {
                Visible = false;
                await VisibleChanged.InvokeAsync(Visible);
            }
        }
    }
}
