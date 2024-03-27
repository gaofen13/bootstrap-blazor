using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapCarouselItem
    {
        private bool _actived;

        private SlideMode _slideMode;

        private string Classname =>
            new ClassBuilder("carousel-item")
            .AddClass("slider-left-in", Carousel?.Crossfade==false && _slideMode == SlideMode.slider_left_in)
            .AddClass("slider-right-in", Carousel?.Crossfade==false && _slideMode == SlideMode.slider_right_in)
            .AddClass("slider-left-out", Carousel?.Crossfade==false && _slideMode == SlideMode.slider_left_out)
            .AddClass("slider-right-out", Carousel?.Crossfade==false && _slideMode == SlideMode.slider_right_out)
            .AddClass("active", _actived)
            .AddClass(Class)
            .Build();

        [CascadingParameter]
        private BootstrapCarousel? Carousel { get; set; }

        [Parameter]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Parameter]
        public bool Default { get; set; }

        [Parameter]
        public RenderFragment? CaptionContent { get; set; }

        protected override void OnInitialized()
        {
            Carousel?.Add(this);
            if (Default)
            {
                _actived = true;
                Carousel?.InitActivedItem(this);
            }
            base.OnInitialized();
        }

        internal void ToggleActive(bool actived, SlideMode slideMode)
        {
            _slideMode = slideMode;
            _actived = actived;
            StateHasChanged();
        }

        void IDisposable.Dispose()
        {
            Carousel?.Remove(this);
            GC.SuppressFinalize(this);
        }

        internal enum SlideMode
        {
            none,
            slider_left_in,
            slider_right_in,
            slider_left_out,
            slider_right_out,
        }
    }
}