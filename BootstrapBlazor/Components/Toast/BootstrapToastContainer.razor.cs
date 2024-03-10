using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Reflection.Metadata;

namespace BootstrapBlazor
{
    public partial class BootstrapToastContainer : BootstrapComponentBase
    {
        private string ContainerClass =>
          new ClassBuilder("toast-container position-fixed")
            .AddClass("start-0", HorizontalPosition == HorizontalPosition.start)
            .AddClass("start-50 translate-middle-x", HorizontalPosition == HorizontalPosition.center && VerticalPosition != VerticalPosition.middle)
            .AddClass("end-0", HorizontalPosition == HorizontalPosition.end)
            .AddClass("top-0", VerticalPosition == VerticalPosition.top)
            .AddClass("top-50 translate-middle-y", VerticalPosition == VerticalPosition.middle && HorizontalPosition != HorizontalPosition.center)
            .AddClass("bottom-0", VerticalPosition == VerticalPosition.bottom)
            .AddClass("start-50 top-50 translate-middle", VerticalPosition == VerticalPosition.middle && HorizontalPosition == HorizontalPosition.center)
            .AddClass(Class)
            .Build();

        [Inject]
        private ToastService ToastService { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        [Parameter]
        public bool ClearToastsOnNavigation { get; set; }

        [Parameter]
        public int MaxItemsShown { get; set; } = 10;

        [Parameter]
        public HorizontalPosition HorizontalPosition { get; set; } = HorizontalPosition.end;

        [Parameter]
        public VerticalPosition VerticalPosition { get; set; } = VerticalPosition.bottom;

        [Parameter]
        public ToastOptions GlobalOptions { get; set; } = new();

        private List<ToastReference> ToastList { get; set; } = [];

        private Queue<ToastReference> ToastWaitingQueue { get; set; } = new();

        protected override void OnInitialized()
        {
            ToastService.OnShowComponent += ShowToast;
            ToastService.OnClearAll += ClearAll;

            if (ClearToastsOnNavigation)
            {
                NavigationManager.LocationChanged += ClearToasts;
            }
        }

        public void RemoveToast(Guid toastId)
        {
            InvokeAsync(() =>
            {
                var toast = ToastList.Find(t => t.Id == toastId);

                if (toast != null)
                {
                    ToastList.Remove(toast);
                    StateHasChanged();
                }

                if (ToastWaitingQueue.Count > 0)
                {
                    ShowEnqueuedToast();
                }
            });
        }

        private void ClearToasts(object? sender, LocationChangedEventArgs args)
        {
            InvokeAsync(() =>
            {
                ToastList.Clear();
                StateHasChanged();

                if (ToastWaitingQueue.Count > 0)
                {
                    ShowEnqueuedToast();
                }
            });
        }

        private void ShowToast(Type contentComponent, ComponentParameters? parameters, ToastOptions? options)
        {
            InvokeAsync(() =>
            {
                var toastContent = new RenderFragment(builder =>
                {
                    var i = 0;
                    builder.OpenComponent(i++, contentComponent);
                    if (parameters is not null)
                    {
                        foreach (var parameter in parameters.Parameters)
                        {
                            builder.AddAttribute(i++, parameter.Key, parameter.Value);
                        }
                    }
                    builder.CloseComponent();
                });

                var toastReference = new ToastReference(toastContent, options);

                if (ToastList.Count < MaxItemsShown)
                {
                    ToastList.Add(toastReference);
                    StateHasChanged();
                }
                else
                {
                    ToastWaitingQueue.Enqueue(toastReference);
                }
            });
        }

        private void ShowEnqueuedToast()
        {
            InvokeAsync(() =>
            {
                var toast = ToastWaitingQueue.Dequeue();

                ToastList.Add(toast);

                StateHasChanged();
            });
        }

        private void ClearAll()
        {
            InvokeAsync(() =>
            {
                ToastList.Clear();
                StateHasChanged();
            });
        }
    }
}
