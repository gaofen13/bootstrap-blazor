using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapModal : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("modal fade")
            .AddClass("show", Visible)
            .AddClass(Class)
            .Build();

        private string Stylelist =>
            new StyleBuilder()
            .AddStyle("display", "block")
            .AddStyle("visibility", "hidden", !Visible)
            .AddStyle(Style)
            .Build();

        private string DialogClassname =>
            new ClassBuilder("modal-dialog")
            .AddClass("modal-dialog-scrollable", Options?.Scrollable)
            .AddClass("modal-dialog-centered ", Options?.Centered)
            .AddClass("modal-fullscreen", Options?.Fullscreen)
            .AddClass($"modal-{Options?.Size}", Options != null)
            .Build();

        private string BodyClassname =>
          new ClassBuilder("modal-body")
            .AddClass(Class)
            .Build();

        private bool IsInline => ModalContainer == null;

        [Inject] private ModalService? ModalService { get; set; }

        [CascadingParameter] private BootstrapModalContainer? ModalContainer { get; set; }

        [Parameter] public bool Visible { get; set; }

        [Parameter] public EventCallback<bool> VisibleChanged { get; set; }

        [Parameter] public ModalOptions? Options { get; set; }

        [Parameter, EditorRequired] public string? Title { get; set; }

        [Parameter] public RenderFragment? ActionsContent { get; set; }

        protected override void OnInitialized()
        {
            if (Options is not null && ModalContainer is not null)
            {
                ModalContainer.ModalOptions = Options;
            }
            base.OnInitialized();
        }

        private void Close()
        {
            if (IsInline)
            {
                Visible = false;
                VisibleChanged.InvokeAsync(false);
            }
            else
            {
                ModalService?.Close(ModalResult.Cancel());
            }
        }

        private void OnClickBackground()
        {
            if (Options?.StaticBackdrop != true)
            {
                Close();
            }
        }
    }
}
