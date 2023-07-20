import { changeTheme } from "./app.js"


console.log(4);

// If dark mode is enbaled, then it activates dark mode for loading page
if (localStorage.darkMode || window.matchMedia('(prefers-color-scheme: dark)').matches) {
    console.log(6);
    changeTheme(true);
}