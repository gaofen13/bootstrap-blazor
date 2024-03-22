let windowEventListeners = {};

export function AddWindowWidthListener(objReference) {
    let eventListener = () => { UpdateOffcanvas(objReference); }
    window.addEventListener("resize", eventListener);
    windowEventListeners[objReference] = eventListener;
}

export function RemoveWindowWidthListener(objReference) {
    window.removeEventListener("resize", windowEventListeners[objReference]);
}

function UpdateOffcanvas(objReference) {
    objReference.invokeMethodAsync("UpdateOffcanvas", window.innerWidth);
}

export function GetWindowWidth() {
    return window.innerWidth;
}

export function GetElementHeight(element) {
    return window.getComputedStyle(element).getPropertyValue("height");
}