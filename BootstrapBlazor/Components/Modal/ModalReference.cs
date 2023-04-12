using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public class ModalReference
    {
        private readonly TaskCompletionSource<ModalResult> _resultCompletion = new(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly Action<ModalResult> _closed;
        private readonly ModalService _modalService;

        internal Guid InstanceId { get; }
        internal RenderFragment ModalInstance { get; }
        internal ModalInstance? ModalInstanceRef { get; set; }

        public ModalReference(Guid modalInstanceId, RenderFragment modalInstance, ModalService modalService)
        {
            InstanceId = modalInstanceId;
            ModalInstance = modalInstance;
            _closed = HandleClosed;
            _modalService = modalService;
        }

        public void Close() => _modalService.Close(this);

        public void Close(ModalResult result) => _modalService.Close(this, result);

        public Task<ModalResult> Result => _resultCompletion.Task;

        internal void Dismiss(ModalResult result) => _closed.Invoke(result);

        private void HandleClosed(ModalResult obj) => _resultCompletion.TrySetResult(obj);
    }
}
