using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public class ToastService
    {
        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        public event Action<Type, ToastParameters?, ToastOptions?>? OnShowComponent;

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
            => ShowToast(Color.info, message, title, _infoIcon, options);

        /// <summary>
        /// Shows a success toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowSuccess(string message, string title = "成功", ToastOptions? options = null)
            => ShowToast(Color.success, message, title, _successIcon, options);

        /// <summary>
        /// Shows a warning toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowWarning(string message, string title = "警告", ToastOptions? options = null)
            => ShowToast(Color.warning, message, title, _warningIcon, options);

        /// <summary>
        /// Shows a error toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowError(string message, string title = "错误", ToastOptions? options = null)
            => ShowToast(Color.danger, message, title, _dangerIcon, options);

        /// <summary>
        /// Shows a toast using the supplied settings
        /// </summary>
        /// <param name="level">Toast level to display</param>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowToast(Color color, string message, string? title = null, RenderFragment? iconContent = null, ToastOptions? options = null)
            => ShowToast<BootstrapToast>(SetParameters(color, message, title, iconContent), options);

        private static ToastParameters SetParameters(Color? color, string? message, string? title, RenderFragment? iconContent)
        {
            var res = new ToastParameters();
            if (color != null)
            {
                res.Add("Color", color);
            }
            if (!string.IsNullOrWhiteSpace(message))
            {
                res.Add("Message", message);
            }
            if (!string.IsNullOrWhiteSpace(title))
            {
                res.Add("Title", title);
            }
            if (iconContent != null)
            {
                res.Add("IconContent", iconContent);
            }
            return res;
        }

        public void ShowToast<TComponent>(ToastParameters? parameters = null, ToastOptions? options = null) where TComponent : IComponent
            => ShowToast(typeof(TComponent), parameters, options);

        public void ShowToast<TComponent>(ToastParameters? parameters = null) where TComponent : IComponent
            => ShowToast(typeof(TComponent), parameters);

        public void ShowToast<TComponent>(ToastOptions? options = null) where TComponent : IComponent
            => ShowToast(typeof(TComponent), null, options);

        public void ShowToast<TComponent>() where TComponent : IComponent
            => ShowToast(typeof(TComponent));

        public void ShowToast(Type toastComponent, ToastParameters? parameters = null, ToastOptions? options = null)
        {
            if (!typeof(IComponent).IsAssignableFrom(toastComponent))
            {
                throw new ArgumentException($"{toastComponent.FullName} must be a Blazor Component");
            }
            OnShowComponent?.Invoke(toastComponent, parameters, options);
        }

        /// <summary>
        /// Removes all toasts
        /// </summary>
        public void ClearAll() => OnClearAll?.Invoke();

        private readonly RenderFragment _infoIcon = builder => builder.AddContent(0, (MarkupString)"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" fill=\"currentColor\" class=\"me-2\" viewBox=\"0 0 16 16\">\r\n        <path d=\"M8 16A8 8 0 1 0 8 0a8 8 0 0 0 0 16zm.93-9.412-1 4.705c-.07.34.029.533.304.533.194 0 .487-.07.686-.246l-.088.416c-.287.346-.92.598-1.465.598-.703 0-1.002-.422-.808-1.319l.738-3.468c.064-.293.006-.399-.287-.47l-.451-.081.082-.381 2.29-.287zM8 5.5a1 1 0 1 1 0-2 1 1 0 0 1 0 2z\" />\r\n        </svg>");
        private readonly RenderFragment _warningIcon = builder => builder.AddContent(0, (MarkupString)"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" fill=\"currentColor\" class=\"me-2\" viewBox=\"0 0 16 16\">\r\n        <path d=\"M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8 4a.905.905 0 0 0-.9.995l.35 3.507a.552.552 0 0 0 1.1 0l.35-3.507A.905.905 0 0 0 8 4zm.002 6a1 1 0 1 0 0 2 1 1 0 0 0 0-2z\" />\r\n        </svg>");
        private readonly RenderFragment _dangerIcon = builder => builder.AddContent(0, (MarkupString)"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" fill=\"currentColor\" class=\"me-2\" viewBox=\"0 0 16 16\">\r\n        <path d=\"M4.978.855a.5.5 0 1 0-.956.29l.41 1.352A4.985 4.985 0 0 0 3 6h10a4.985 4.985 0 0 0-1.432-3.503l.41-1.352a.5.5 0 1 0-.956-.29l-.291.956A4.978 4.978 0 0 0 8 1a4.979 4.979 0 0 0-2.731.811l-.29-.956z\" />\r\n        <path d=\"M13 6v1H8.5v8.975A5 5 0 0 0 13 11h.5a.5.5 0 0 1 .5.5v.5a.5.5 0 1 0 1 0v-.5a1.5 1.5 0 0 0-1.5-1.5H13V9h1.5a.5.5 0 0 0 0-1H13V7h.5A1.5 1.5 0 0 0 15 5.5V5a.5.5 0 0 0-1 0v.5a.5.5 0 0 1-.5.5H13zm-5.5 9.975V7H3V6h-.5a.5.5 0 0 1-.5-.5V5a.5.5 0 0 0-1 0v.5A1.5 1.5 0 0 0 2.5 7H3v1H1.5a.5.5 0 0 0 0 1H3v1h-.5A1.5 1.5 0 0 0 1 11.5v.5a.5.5 0 1 0 1 0v-.5a.5.5 0 0 1 .5-.5H3a5 5 0 0 0 4.5 4.975z\" />\r\n        </svg>");
        private readonly RenderFragment _successIcon = builder => builder.AddContent(0, (MarkupString)"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" fill=\"currentColor\" class=\"me-2\" viewBox=\"0 0 16 16\">\r\n        <path d=\"M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-3.97-3.03a.75.75 0 0 0-1.08.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-.01-1.05z\" />\r\n        </svg>");
    }
}
