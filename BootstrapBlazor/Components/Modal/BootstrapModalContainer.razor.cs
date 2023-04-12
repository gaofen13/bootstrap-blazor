using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Collections.ObjectModel;

namespace BootstrapBlazor
{
    public partial class BootstrapModalContainer
    {
        [Inject] private NavigationManager? NavigationManager { get; set; }
        [Inject] private ModalService ModalService { get; set; } = default!;
        [Parameter] public ModalOptions? GlobalOptions { get; set; }

        private readonly Collection<ModalReference> _modals = new();
        private bool _haveActiveModals;

        protected override void OnInitialized()
        {
            if (ModalService == null)
            {
                throw new InvalidOperationException($"{GetType()} requires a cascading parameter of type {nameof(ModalService)}.");
            }

            ModalService.OnModalInstanceAdded += Update;
            ModalService.OnModalCloseRequested += CloseInstance;
            NavigationManager!.LocationChanged += CancelModals;
        }

        internal void CloseInstance(ModalReference? modal, ModalResult result)
        {
            if (modal?.ModalInstanceRef != null)
            {
                // Gracefully close the modal
                modal.ModalInstanceRef.Close(result);
                if (!_modals.Any())
                {
                    ClearBodyStyles();
                }
            }
            else
            {
                DismissInstance(modal, result);
            }
        }

        internal void DismissInstance(Guid id, ModalResult result)
        {
            var reference = GetModalReference(id);
            DismissInstance(reference, result);
        }

        internal void DismissInstance(ModalReference? modal, ModalResult result)
        {
            if (modal != null)
            {
                modal.Dismiss(result);
                _modals.Remove(modal);
                if (!_modals.Any())
                {
                    ClearBodyStyles();
                }
                StateHasChanged();
            }
        }

        private void CancelModals(object? sender, LocationChangedEventArgs e)
        {
            foreach (var modalReference in _modals.ToList())
            {
                modalReference.Dismiss(ModalResult.Cancel());
            }

            _modals.Clear();
            ClearBodyStyles();
            StateHasChanged();
        }

        private void Update(ModalReference modalReference)
        {
            _modals.Add(modalReference);

            if (!_haveActiveModals)
            {
                _haveActiveModals = true;
            }

            StateHasChanged();
        }

        private ModalReference? GetModalReference(Guid id) => _modals.SingleOrDefault(x => x.InstanceId == id);

        private void ClearBodyStyles()
        {
            _haveActiveModals = false;
        }
    }
}
