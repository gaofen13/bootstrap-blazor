using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor.Shared.Shared
{
    public partial class ModalContentExample : ComponentBase
    {
        [Inject]
        private ModalService? ModalService { get; set; }

        private void OnConfirm()
        {
            ModalService?.Close(ModalResult.Ok("点击了确定"));
        }

        private void OnCancel()
        {
            ModalService?.Close(ModalResult.Cancel("点击了取消"));
        }
    }
}