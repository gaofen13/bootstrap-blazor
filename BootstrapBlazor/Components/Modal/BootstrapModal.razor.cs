using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapModal : BootstrapComponentBase
    {
        private string BodyClassname =>
          new ClassBuilder("modal-body")
            .AddClass(Class)
            .Build();

        private bool IsInline => ModalContainer == null;

        [Inject] private ModalService ModalService { get; set; } = default!;

        [CascadingParameter] private BootstrapModalContainer? ModalContainer { get; set; }

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

        public ModalReference Show()
        {
            var parameters = new ComponentParameters
            {
                { nameof(Title), Title },
                { nameof(Options), Options },
                { nameof(ChildContent), ChildContent },
                { nameof(ActionsContent), ActionsContent }
            };
            return ModalService.Show<BootstrapModal>(parameters);
        }

        public void Close()
        {
            ModalService.Close(ModalResult.Cancel());
        }
    }
}
