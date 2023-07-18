export function changeTheme(darkModeEnabled) {
    const className = "dark";
    let body = document.body;

    if (darkModeEnabled)
        body.classList.add(className);
    else
        body.classList.remove(className);
}

export function goToAnchorLink(elementId) {
    let elem = document.getElementById(elementId);

    if (elem) {
        elem.scrollIntoView();
        window.location.hash = elementId;
    }
}