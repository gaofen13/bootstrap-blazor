namespace BootstrapBlazor
{
    public class ModalOptions
    {
        public bool Centered { get; set; }
        public bool Scrollable { get; set; }
        public bool ShowCloseBtn { get; set; }
        public bool Fullscreen { get; set; }
        public Size Size { get; set; } = Size.md;
        public bool ClickBackgroundCancel { get; set; }
    }
}
