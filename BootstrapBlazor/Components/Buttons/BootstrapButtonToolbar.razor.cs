using BootstrapBlazor.Utilities;

namespace BootstrapBlazor
{
    public partial class BootstrapButtonToolbar : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("btn-toolbar")
            .AddClass(Class)
            .Build();
    }
}
