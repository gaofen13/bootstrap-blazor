using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public class ModalReference
    {
        private readonly TaskCompletionSource<ModalResult> _resultCompletion = new(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly Action<ModalResult> _closed;

        internal RenderFragment ModalContent { get; }

        public ModalReference(RenderFragment modalContent)
        {
            ModalContent = modalContent;
            _closed = HandleClosed;
        }

        public Task<ModalResult> Result => _resultCompletion.Task;

        internal void Dismiss(ModalResult result) => _closed.Invoke(result);

        private void HandleClosed(ModalResult obj) => _resultCompletion.TrySetResult(obj);
    }
}
