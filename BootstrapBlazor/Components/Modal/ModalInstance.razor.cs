using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BootstrapBlazor
{
    public partial class ModalInstance : BootstrapComponentBase
    {
        [CascadingParameter] private BootstrapModalContainer? ModalContainer { get; set; }

        [Parameter] public Guid InstanceId { get; set; }

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
    }
}
