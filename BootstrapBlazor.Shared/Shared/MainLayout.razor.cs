using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace BootstrapBlazor.Shared.Shared
{
    public partial class MainLayout
    {
        private bool showMenu;
        private int _windowWidth;
        private IJSObjectReference? _jsModule;
        private DotNetObjectReference<MainLayout>? _objectReference;

        private bool ShowBackdrop => _windowWidth < 992;

        [Inject]
        private IJSRuntime JSRuntime { get; set; } = default!;

        [Inject]
        private NavigationManager? Navigation { get; set; }

        protected override void OnInitialized()
        {
            Navigation!.LocationChanged += OnLoactionChanged;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _objectReference = DotNetObjectReference.Create(this);
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import",
                     "./_content/BootstrapBlazor.Shared/Shared/MainLayout.razor.js");
                await _jsModule!.InvokeVoidAsync("AddWindowWidthListener", _objectReference);
                var width = await _jsModule!.InvokeAsync<int>("GetWindowWidth");
                UpdateOffcanvas(width);
                StateHasChanged();
            }
        }

        [JSInvokable]
        public void UpdateOffcanvas(int width)
        {
            _windowWidth = width;
            if (width >= 992)
            {
                if (!showMenu)
                {
                    showMenu = true;
                    StateHasChanged();
                }
            }
            else
            {
                if (showMenu)
                {
                    showMenu = false;
                    StateHasChanged();
                }
            }
        }

        private void OnLoactionChanged(object? sender, LocationChangedEventArgs args)
        {
            if (_windowWidth < 992 && showMenu)
            {
                showMenu = false;
                StateHasChanged();
            }
        }

        private void ToggleMenu()
        {
            showMenu = !showMenu;
        }
    }
}
