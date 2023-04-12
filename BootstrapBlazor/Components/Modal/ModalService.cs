using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public class ModalService
    {
        internal event Action<ModalReference>? OnModalInstanceAdded;
        internal event Action<ModalReference, ModalResult>? OnModalCloseRequested;

        /// <summary>
        /// Shows the modal with the component type using the specified <paramref name="title"/>,
        /// passing the specified <paramref name="parameters"/>.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        public ModalReference Show<T>(string title, ModalOptions? options = null, ModalParameters? parameters = null) where T : IComponent
            => Show(typeof(T), title, options, parameters);

        /// <summary>
        /// Shows the modal with the component type using the specified title.
        /// </summary>
        /// <param name="title">Modal title.</param>
        public ModalReference Show<T>(string title, ModalParameters parameters) where T : IComponent
            => Show<T>(title, null, parameters);

        /// <summary>
        /// Shows the modal with the component type using the specified title.
        /// </summary>
        /// <param name="title">Modal title.</param>
        public ModalReference Show<T>(string title, ModalOptions options) where T : IComponent
            => Show<T>(title, options, null);

        /// <summary>
        /// Shows the modal with the component type using the specified title.
        /// </summary>
        /// <param name="contentComponent">Type of component to display.</param>
        /// <param name="title">Modal title.</param>
        public ModalReference Show(Type contentComponent, string title, ModalParameters parameters)
            => Show(contentComponent, title, null, parameters);

        /// <summary>
        /// Shows the modal with the component type using the specified title.
        /// </summary>
        /// <param name="contentComponent">Type of component to display.</param>
        /// <param name="title">Modal title.</param>
        public ModalReference Show(Type contentComponent, string title, ModalOptions options)
            => Show(contentComponent, title, options, null);

        /// <summary>
        /// Shows the modal with the component type using the specified <paramref name="title"/>,
        /// passing the specified <paramref name="parameters"/> and setting a custom CSS style.
        /// </summary>
        /// <param name="contentComponent">Type of component to display.</param>
        /// <param name="title">Modal title.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        /// <param name="options">Options to configure the modal.</param>
        public ModalReference Show(Type contentComponent, string title, ModalOptions? options = null, ModalParameters? parameters = null)
        {
            if (!typeof(IComponent).IsAssignableFrom(contentComponent))
            {
                throw new ArgumentException($"{contentComponent.FullName} must be a Blazor Component");
            }

            ModalReference? modalReference = null;
            var modalInstanceId = Guid.NewGuid();
            var modalContent = new RenderFragment(builder =>
            {
                var i = 0;
                builder.OpenComponent(i++, contentComponent);
                if (parameters is not null)
                {
                    foreach (var (name, value) in parameters.Parameters)
                    {
                        builder.AddAttribute(i++, name, value);
                    }
                }
                builder.CloseComponent();
            });
            var modalInstance = new RenderFragment(builder =>
            {
                builder.OpenComponent<ModalInstance>(0);
                builder.SetKey("ModalInstance_" + modalInstanceId);
                builder.AddAttribute(1, "InstanceId", modalInstanceId);
                builder.AddAttribute(2, "Visible", true);
                builder.AddAttribute(3, "Options", options);
                builder.AddAttribute(4, "Title", title);
                builder.AddAttribute(5, "ChildContent", modalContent);
                builder.AddComponentReferenceCapture(6, compRef => modalReference!.ModalInstanceRef = (ModalInstance)compRef);
                builder.CloseComponent();
            });
            modalReference = new ModalReference(modalInstanceId, modalInstance, this);

            OnModalInstanceAdded?.Invoke(modalReference);

            return modalReference;
        }

        internal void Close(ModalReference modal) => Close(modal, ModalResult.Ok());

        internal void Close(ModalReference modal, ModalResult result) => OnModalCloseRequested?.Invoke(modal, result);
    }
}
