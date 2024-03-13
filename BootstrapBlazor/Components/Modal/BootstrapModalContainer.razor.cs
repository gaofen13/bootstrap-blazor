using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BootstrapBlazor
{
    public partial class BootstrapModalContainer : BootstrapComponentBase
    {
        private ModalOptions? _modalOptions;
        private ModalReference? _modal;

        [Inject] private NavigationManager? NavigationManager { get; set; }
        [Inject] private ModalService ModalService { get; set; } = default!;
        [Parameter] public ModalOptions GlobalOptions { get; set; } = new();

        public ModalOptions? ModalOptions
        {
            get => _modalOptions;
            set
            {
                _modalOptions = value;
                StateHasChanged();
            }
        }

        private string Classname =>
          new ClassBuilder("modal fade")
            .AddClass("show", _modal != null)
            .AddClass(Class)
            .Build();

        private string Stylelist =>
            new StyleBuilder()
            .AddStyle("display", "block")
            .AddStyle("visibility", "hidden", _modal == null)
            .AddStyle(Style)
            .Build();

        private string DialogClassname =>
            new ClassBuilder("modal-dialog")
            .AddClass("modal-dialog-scrollable", _modalOptions == null ? GlobalOptions.Scrollable : _modalOptions.Scrollable)
            .AddClass("modal-dialog-centered ", _modalOptions == null ? GlobalOptions.Centered : _modalOptions.Centered)
            .AddClass("modal-fullscreen", _modalOptions == null ? GlobalOptions.Fullscreen : _modalOptions.Fullscreen)
            .AddClass($"modal-{(_modalOptions == null ? GlobalOptions.Size : _modalOptions.Size)}")
            .Build();

        protected override void OnInitialized()
        {
            if (ModalService == null)
            {
                throw new InvalidOperationException($"{GetType()} requires a cascading parameter of type {nameof(ModalService)}.");
            }

            ModalService.OnModalInstanceUpdate += Update;
            ModalService.OnModalCloseRequested += CloseInstance;
            NavigationManager!.LocationChanged += CancelModal;
        }

        internal void CloseInstance(ModalResult result)
        {
            if (_modal != null)
            {
                _modal.Dismiss(result);
                _modal = null;
                _modalOptions = null;
                StateHasChanged();
            }
        }

        private void CancelModal(object? sender, LocationChangedEventArgs e)
        {
            CloseInstance(ModalResult.Cancel());
        }

        private void Update(ModalReference modalReference)
        {
            CloseInstance(ModalResult.Cancel());
            _modal = modalReference;
            StateHasChanged();
        }

        private void OnClickBackground()
        {
            if (ModalOptions == null ? GlobalOptions?.StaticBackdrop == false : !ModalOptions.StaticBackdrop)
            {
                CloseInstance(ModalResult.Cancel());
            }
        }
    }
}
