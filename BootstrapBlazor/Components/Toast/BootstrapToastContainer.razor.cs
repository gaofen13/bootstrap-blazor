using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BootstrapBlazor
{
    public partial class BootstrapToastContainer : BootstrapComponentBase
    {
        private string ContainerClass =>
          new ClassBuilder("toast-container position-fixed")
            .AddClass($"{HorizontalPosition}-0")
            .AddClass($"{VerticalPosition}-0")
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

        private List<ToastInstance> ToastList { get; set; } = new();

        private Queue<ToastInstance> ToastWaitingQueue { get; set; } = new();

        protected override void OnInitialized()
        {
            ToastService.OnShow += ShowToast;
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
                var toastInstance = ToastList.SingleOrDefault(x => x.Id == toastId);

                if (toastInstance is not null)
                {
                    ToastList.Remove(toastInstance);
                    StateHasChanged();
                }

                if (ToastWaitingQueue.Any())
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

                if (ToastWaitingQueue.Any())
                {
                    ShowEnqueuedToast();
                }
            });
        }

        private void ShowToast(Color level, RenderFragment message, string? title, ToastOptions? options)
        {
            InvokeAsync(() =>
            {
                var toast = new ToastInstance(options ?? GlobalOptions) { ToastLevel = level, MessageContent = message, Title = title };

                if (ToastList.Count < MaxItemsShown)
                {
                    ToastList.Add(toast);
                    StateHasChanged();
                }
                else
                {
                    ToastWaitingQueue.Enqueue(toast);
                }
            });

        }

        private void ShowToast(Type contentComponent, Color level, ToastParameters? parameters, ToastOptions? options)
        {
            InvokeAsync(() =>
            {
                var childContent = new RenderFragment(builder =>
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

                var toast = new ToastInstance(childContent, options ?? GlobalOptions) { ToastLevel = level };

                if (ToastList.Count < MaxItemsShown)
                {
                    ToastList.Add(toast);
                    StateHasChanged();
                }
                else
                {
                    ToastWaitingQueue.Enqueue(toast);
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
