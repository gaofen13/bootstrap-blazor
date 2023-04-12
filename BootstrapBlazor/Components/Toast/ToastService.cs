using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public class ToastService
    {
        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        public event Action<Color, RenderFragment, string?, ToastOptions?>? OnShow;

        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        public event Action<Type, Color, ToastParameters?, ToastOptions?>? OnShowComponent;

        /// <summary>
        /// A event that will be invoked when clearing all toasts
        /// </summary>
        public event Action? OnClearAll;

        /// <summary>
        /// Shows a information toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowInfo(string message, string title = "信息", ToastOptions? options = null)
            => ShowToast(Color.info, message, title, options);

        /// <summary>
        /// Shows a information toast 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowInfo(RenderFragment message, string title = "信息", ToastOptions? options = null)
            => ShowToast(Color.info, message, title, options);

        /// <summary>
        /// Shows a success toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowSuccess(string message, string title = "成功", ToastOptions? options = null)
            => ShowToast(Color.success, message, title, options);

        /// <summary>
        /// Shows a success toast 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowSuccess(RenderFragment message, string title = "成功", ToastOptions? options = null)
            => ShowToast(Color.success, message, title, options);

        /// <summary>
        /// Shows a warning toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowWarning(string message, string title = "警告", ToastOptions? options = null)
            => ShowToast(Color.warning, message, title, options);

        /// <summary>
        /// Shows a warning toast 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowWarning(RenderFragment message, string title = "警告", ToastOptions? options = null)
            => ShowToast(Color.warning, message, title, options);

        /// <summary>
        /// Shows a error toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowError(string message, string title = "错误", ToastOptions? options = null)
            => ShowToast(Color.danger, message, title, options);

        /// <summary>
        /// Shows a error toast 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowError(RenderFragment message, string title = "错误", ToastOptions? options = null)
            => ShowToast(Color.danger, message, title, options);

        /// <summary>
        /// Shows a toast using the supplied settings
        /// </summary>
        /// <param name="level">Toast level to display</param>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowToast(Color level, string message, string? title = null, ToastOptions? options = null)
            => ShowToast(level, builder => builder.AddContent(0, message), title, options);

        /// <summary>
        /// Shows a toast using the supplied settings
        /// </summary>
        /// <param name="level">Toast level to display</param>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowToast(Color level, RenderFragment message, string? title = null, ToastOptions? options = null)
            => OnShow?.Invoke(level, message, title, options);

        public void ShowToast<TComponent>(Color level, ToastParameters? parameters = null, ToastOptions? options = null) where TComponent : IComponent
            => ShowToast(typeof(TComponent), level, parameters, options);

        public void ShowToast<TComponent>(Color level, ToastParameters? parameters = null) where TComponent : IComponent
            => ShowToast(typeof(TComponent), level, parameters);

        public void ShowToast<TComponent>(Color level, ToastOptions? options = null) where TComponent : IComponent
            => ShowToast(typeof(TComponent), level, null, options);

        public void ShowToast<TComponent>(Color level) where TComponent : IComponent
            => ShowToast(typeof(TComponent), level);

        public void ShowToast(Type toastComponent, Color level, ToastParameters? parameters = null, ToastOptions? options = null)
        {
            if (!typeof(IComponent).IsAssignableFrom(toastComponent))
            {
                throw new ArgumentException($"{toastComponent.FullName} must be a Blazor Component");
            }
            OnShowComponent?.Invoke(toastComponent, level, parameters, options);
        }

        /// <summary>
        /// Removes all toasts
        /// </summary>
        public void ClearAll() => OnClearAll?.Invoke();
    }
}
