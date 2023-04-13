using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor.Shared.Shared
{
    public partial class ModalContentExample : ComponentBase
    {
        [CascadingParameter]
        private ModalInstance ModalInstance { get; set; } = default!;

        private void OnConfirm()
        {
            ModalInstance.Close(ModalResult.Ok("点击了确定"));
        }

        private void OnCancel()
        {
            ModalInstance.Cancel("点击了取消");
        }
    }
}