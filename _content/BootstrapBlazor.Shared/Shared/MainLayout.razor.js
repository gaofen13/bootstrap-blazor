let windowEventListeners = {};

export function AddWindowWidthListener(objReference, element) {
    let eventListener = () => { UpdateOffcanvas(objReference); UpdateNavbarHeight(objReference, element); }
    window.addEventListener("resize", eventListener);
    windowEventListeners[objReference] = eventListener;
}

export function RemoveWindowWidthListener(objReference) {
    window.removeEventListener("resize", windowEventListeners[objReference]);
}

function UpdateOffcanvas(objReference) {
    objReference.invokeMethodAsync("UpdateOffcanvas", window.innerWidth);
}

function UpdateNavbarHeight(objReference, element) {
    objReference.invokeMethodAsync("UpdateNavbarHeight", GetElementHeight(element));
}

export function GetWindowWidth() {
    return window.innerWidth;
}

export function GetElementHeight(element) {
    return window.getComputedStyle(element).getPropertyValue("height");
}