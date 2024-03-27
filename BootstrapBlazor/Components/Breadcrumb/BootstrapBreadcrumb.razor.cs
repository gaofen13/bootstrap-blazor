using BootstrapBlazor.Utilities;

namespace BootstrapBlazor
{
    partial class BootstrapBreadcrumb
    {
        private string Classname =>
            new ClassBuilder("breadcrumb")
            .AddClass(Class)
            .Build();
    }
}