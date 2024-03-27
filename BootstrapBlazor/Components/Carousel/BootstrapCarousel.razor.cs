using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapCarousel
    {
        private readonly HashSet<BootstrapCarouselItem> _items = [];

        private BootstrapCarouselItem? _activedItem;

        private Timer? _timer;

        private string Classname =>
            new ClassBuilder("carousel slide")
            .AddClass("carousel-fade", Crossfade)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Crossfade { get; set; }

        [Parameter]
        public bool ShowIndicators { get; set; }

        [Parameter]
        public bool Autoplaying { get; set; }

        [Parameter]
        public int Interval { get; set; } = 5000;

        protected override void OnInitialized()
        {
            if (Autoplaying && Interval > 0)
            {
                _timer = new Timer(TimerElapsed);
                Start();
            }
        }

        private void TimerElapsed(object? state)
        {
            InvokeAsync(() =>
            {
                OnClickNext();
                StateHasChanged();
            });
        }

        internal void Add(BootstrapCarouselItem item)
        {
            _items.Add(item);
            if (ShowIndicators)
            {
                StateHasChanged();
            }
        }

        internal void Remove(BootstrapCarouselItem item)
        {
            _items.Remove(item);
            if (ShowIndicators)
            {
                StateHasChanged();
            }
        }

        internal void InitActivedItem(BootstrapCarouselItem item)
        {
            _activedItem = item;
        }

        internal void ActiveItemChanged(BootstrapCarouselItem item, bool next)
        {
            _activedItem?.ToggleActive(false, next ? BootstrapCarouselItem.SlideMode.slider_left_out : BootstrapCarouselItem.SlideMode.slider_right_out);
            _activedItem = item;
            _activedItem.ToggleActive(true, next ? BootstrapCarouselItem.SlideMode.slider_right_in : BootstrapCarouselItem.SlideMode.slider_left_in);
        }

        private bool IsNextItem(BootstrapCarouselItem item)
        {
            var currentIndex = Array.IndexOf([.. _items], _activedItem);
            var itemIndex = Array.IndexOf([.. _items], item);
            if (currentIndex < _items.Count - 1)
            {
                return itemIndex > currentIndex;
            }
            else
            {
                return itemIndex == 0;
            }
        }

        private void OnClickPrev()
        {
            var currentIndex = Array.IndexOf([.. _items], _activedItem);
            if (currentIndex != -1)
            {
                BootstrapCarouselItem prevItem;
                if (currentIndex == 0)
                {
                    prevItem = _items.ElementAt(_items.Count - 1);
                }
                else
                {
                    prevItem = _items.ElementAt(currentIndex - 1);
                };
                ActiveItemChanged(prevItem, false);
            }
        }

        private void OnClickNext()
        {
            var currentIndex = Array.IndexOf([.. _items], _activedItem);
            if (currentIndex != -1)
            {
                BootstrapCarouselItem nextItem;
                if (currentIndex == _items.Count - 1)
                {
                    nextItem = _items.ElementAt(0);
                }
                else
                {
                    nextItem = _items.ElementAt(currentIndex + 1);
                };
                ActiveItemChanged(nextItem, true);
            }
        }

        private void Start()
        {
            _timer?.Change(Interval, Interval);
        }

        private void Stop()
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        void IDisposable.Dispose()
        {
            Stop();
            _timer?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}