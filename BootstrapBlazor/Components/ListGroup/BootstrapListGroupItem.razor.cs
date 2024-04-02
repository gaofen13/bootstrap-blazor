using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BootstrapBlazor
{
    public partial class BootstrapListGroupItem : BootstrapComponentBase
    {
        private string Classname =>
          new ClassBuilder("list-group-item")
            .AddClass($"list-group-item-{Color}", Color != null)
            .AddClass("list-group-item-action", Href != null || ListGroup?.Actionable == true)
            .AddClass("disabled", Disabled)
            .AddClass("active", Active)
            .AddClass(Class)
            .Build();

        private string HtmlTag { get; set; } = "li";

        [CascadingParameter]
        private BootstrapListGroup? ListGroup { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool Active { get; set; }

        [Parameter]
        public string? Href { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        protected override void OnInitialized()
        {
            if (Href != null)
            {
                HtmlTag = "a";
            }
            else if (ListGroup?.Actionable == true)
            {
                HtmlTag = "button";
            }
            base.OnInitialized();
        }
    }
}
