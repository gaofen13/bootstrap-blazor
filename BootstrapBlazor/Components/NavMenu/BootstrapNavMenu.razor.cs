using BootstrapBlazor.Utilities;

namespace BootstrapBlazor
{
    public partial class BootstrapNavMenu
    {
        private string Classname =>
            new ClassBuilder("navmenu")
            .AddClass(Class)
            .Build();
    }
}