namespace BootstrapBlazor
{
    public class ModalOptions
    {
        public bool Centered { get; set; }
        public bool Scrollable { get; set; } = true;
        public bool ShowCloseBtn { get; set; }
        public bool Fullscreen { get; set; }
        public Size Size { get; set; } = Size.md;
        public bool StaticBackdrop { get; set; }
    }
}
