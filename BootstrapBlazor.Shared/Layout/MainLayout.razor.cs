using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace BootstrapBlazor.Shared.Layout
{
    public partial class MainLayout
    {
        private bool darkTheme;
        private bool showNavMenu;
        private bool showMenu;
        private int _windowWidth;
        private string? _navbarHeight;
        private BootstrapNavbar? _navbar;
        private IJSObjectReference? _jsModule;
        private DotNetObjectReference<MainLayout>? _objectReference;

        private string OffcanvasTop => ShowBackdrop ? "0" : _navbarHeight ?? "0";

        private string OffcanvasHeight => ShowBackdrop ? "100vh" : $"calc(100vh - {_navbarHeight})";

        private bool ShowBackdrop => _windowWidth < 992;

        private string ThemeType => darkTheme ? "dark" : "light";

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
                     "./_content/BootstrapBlazor.Shared/Layout/MainLayout.razor.js");
                await _jsModule!.InvokeVoidAsync("AddWindowWidthListener", _objectReference, _navbar!.Element);
                var width = await _jsModule!.InvokeAsync<int>("GetWindowWidth");
                _navbarHeight = await _jsModule!.InvokeAsync<string>("GetElementHeight", _navbar!.Element);
                UpdateOffcanvas(width);
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

        private void OnSwipeOffcanvas(SwipeDirection direction)
        {
            if(direction==SwipeDirection.RightToLeft)
            {
                showMenu = false;
            }
        }

        private void OnThemeChanged(bool theme)
        {
            if (darkTheme != theme)
            {
                darkTheme = theme;
                StateHasChanged();
            }
        }
    }
}
