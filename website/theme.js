/* Prunel website: light or dark mode.
   By default the site follows the mode of the system (Windows, phone...), through the
   CSS media query prefers-color-scheme. The theme button lets the visitor force the other
   mode; the choice is kept in this browser (localStorage) for the next visits.
   Choosing again the mode of the system removes the saved choice, so the site follows the
   system again.
   This script is loaded in <head>, before the page is drawn, so that a saved choice is
   applied without a flash of the wrong colours. The button texts are written in the HTML
   pages (data-dark and data-light attributes), not here. */
(function () {
  var storageKey = "prunel-theme";
  var root = document.documentElement;
  var systemDark = window.matchMedia ? window.matchMedia("(prefers-color-scheme: dark)") : null;

  function readChoice() {
    try {
      var value = window.localStorage.getItem(storageKey);
      return value === "dark" || value === "light" ? value : null;
    } catch (e) {
      return null; // storage blocked: follow the system only
    }
  }

  function saveChoice(value) {
    try {
      if (value) {
        window.localStorage.setItem(storageKey, value);
      } else {
        window.localStorage.removeItem(storageKey);
      }
    } catch (e) {
      // storage blocked: the choice lasts until the page is closed
    }
  }

  function systemTheme() {
    return systemDark && systemDark.matches ? "dark" : "light";
  }

  function currentTheme() {
    return root.getAttribute("data-theme") || systemTheme();
  }

  function applyChoice(value) {
    if (value) {
      root.setAttribute("data-theme", value);
    } else {
      root.removeAttribute("data-theme");
    }
  }

  applyChoice(readChoice());

  function setUpButton() {
    var button = document.getElementById("theme-switch");
    if (!button) {
      return;
    }
    var label = button.querySelector(".theme-label");
    var icon = button.querySelector(".theme-icon");

    // The button shows the mode it switches to.
    function refresh() {
      var toDark = currentTheme() === "light";
      label.textContent = toDark ? button.getAttribute("data-dark") : button.getAttribute("data-light");
      icon.textContent = toDark ? "☾" : "☀"; // moon or sun
    }

    button.hidden = false;
    refresh();

    button.addEventListener("click", function () {
      var next = currentTheme() === "dark" ? "light" : "dark";
      var choice = next === systemTheme() ? null : next;
      saveChoice(choice);
      applyChoice(choice);
      refresh();
    });

    // The system mode can change while the page is open (Windows automatic mode, for example).
    if (systemDark) {
      var onChange = function () { refresh(); };
      if (systemDark.addEventListener) {
        systemDark.addEventListener("change", onChange);
      } else if (systemDark.addListener) {
        systemDark.addListener(onChange);
      }
    }
  }

  if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", setUpButton);
  } else {
    setUpButton();
  }
})();
