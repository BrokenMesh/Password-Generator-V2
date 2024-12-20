export function addClickOutsideListener(elementId, dotNetRef) {
    document.addEventListener("click", (event) => {
        const targetElement = document.getElementById(elementId);
        if (targetElement && !targetElement.contains(event.target)) {
            dotNetRef.invokeMethodAsync("OnOutsideClick");
        }
    });
}

export function removeClickOutsideListener(elementId) {
    const handler = window[elementId + "_clickHandler"];
    if (handler) {
        document.removeEventListener("click", handler);
        delete window[elementId + "_clickHandler"];
    }
}