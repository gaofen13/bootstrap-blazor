using BootstrapBlazor.Utilities;

namespace BootstrapBlazor
{
    public partial class BootstrapProgressStack : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("progress-stacked")
            .AddClass(Class)
            .Build();
    }
}
