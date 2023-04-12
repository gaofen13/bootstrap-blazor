using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BootstrapBlazor
{
    public partial class ModalInstance : BootstrapComponentBase
    {
        private ModalOptions _options = new();
        private bool _clickBackgroundCancel;

        private string Classname =>
          new ClassBuilder("modal")
            .AddClass("show", Visible)
            .AddClass(Class)
            .Build();

        private string DialogClassname =>
            new ClassBuilder()
            .AddClass("modal-dialog-scrollable", _options.Scrollable)
            .AddClass("modal-dialog-centered ", _options.Centered)
            .AddClass("modal-fullscreen", _options.Fullscreen)
            .AddClass($"modal-{_options.Size}")
            .Build();

        private string Stylelist =>
            new StyleBuilder()
            .AddStyle("display", "block")
            .AddStyle(Style)
            .Build();

        [CascadingParameter] private BootstrapModalContainer? ModalContainer { get; set; }

        [Parameter] public ModalOptions? Options { get; set; }
        [Parameter, EditorRequired] public string? Title { get; set; }
        [Parameter] public RenderFragment? BodyContent { get; set; }
        [Parameter] public RenderFragment? FooterContent { get; set; }
        [Parameter] public bool Visible { get; set; }
        [Parameter] public EventCallback<bool> VisibleChanged { get; set; }
        [Parameter] public Guid InstanceId { get; set; }

        protected override void OnInitialized()
        {
            _clickBackgroundCancel = Options?.ClickBackgroundCancel == true || ModalContainer?.GlobalOptions?.ClickBackgroundCancel == true;
            var options = Options ?? ModalContainer?.GlobalOptions;
            if (options is not null)
            {
                _options = options;
            }
            base.OnInitialized();
        }

        private void OnClickCloseBtn(MouseEventArgs args)
        {
            Cancel();
        }

        /// <summary>
        /// Closes the modal with a default Ok result />.
        /// </summary>
        public void Close() => Close(ModalResult.Ok());

        /// <summary>
        /// Closes the modal with the specified <paramref name="modalResult"/>.
        /// </summary>
        /// <param name="modalResult"></param>
        public void Close(ModalResult modalResult)
        {
            ModalContainer?.DismissInstance(InstanceId, modalResult);
        }

        /// <summary>
        /// Closes the modal and returns a cancelled ModalResult.
        /// </summary>
        public void Cancel() => Close(ModalResult.Cancel());

        /// <summary>
        /// Closes the modal returning the specified <paramref name="payload"/> in a cancelled ModalResult.
        /// </summary>
        public void Cancel<TPayload>(TPayload payload) => Close(ModalResult.Cancel(payload));

        private async Task OnClickBackgroundAsync()
        {
            if (_clickBackgroundCancel)
            {
                Cancel();
                if (Visible)
                {
                    Visible = false;
                    await VisibleChanged.InvokeAsync(Visible);
                }
            }
        }
    }
}
