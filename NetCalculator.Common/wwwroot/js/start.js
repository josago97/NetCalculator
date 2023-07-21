import { changeTheme } from "./app.js"

// If dark mode is enbaled, then it activates dark mode for loading page
if (localStorage.darkMode === "true" || window.matchMedia("(prefers-color-scheme: dark)").matches) {
    changeTheme(true);
}