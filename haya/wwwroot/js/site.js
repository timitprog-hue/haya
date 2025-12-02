(function () {
    const THEME_KEY = "theme-preference";
    const LANG_KEY = "lang-preference";

    /* ========== THEME ========== */

    function getStoredTheme() {
        const stored = localStorage.getItem(THEME_KEY);
        if (stored === "dark" || stored === "light") return stored;

        // fallback: ikut sistem
        return window.matchMedia &&
            window.matchMedia("(prefers-color-scheme: dark)").matches
            ? "dark"
            : "light";
    }

    function applyTheme(theme) {
        const root = document.documentElement;
        root.setAttribute("data-theme", theme);

        const icon = document.getElementById("themeToggleIcon");
        const text = document.getElementById("themeToggleText");

        if (icon && text) {
            if (theme === "dark") {
                icon.textContent = "🌙";
                text.textContent = "Dark";
            } else {
                icon.textContent = "☀️";
                text.textContent = "Light";
            }
        }
    }

    function initThemeToggle() {
        const current = getStoredTheme();
        applyTheme(current);

        const toggleBtn = document.getElementById("themeToggle");
        if (!toggleBtn) return;

        toggleBtn.addEventListener("click", function () {
            const activeTheme =
                document.documentElement.getAttribute("data-theme") || "dark";
            const nextTheme = activeTheme === "dark" ? "light" : "dark";

            localStorage.setItem(THEME_KEY, nextTheme);
            applyTheme(nextTheme);
        });
    }


    /* ========== LANGUAGE ========== */

    function getStoredLang() {
        const stored = localStorage.getItem(LANG_KEY);
        if (stored === "id" || stored === "en") return stored;
        return "id"; // default
    }

    function applyLang(lang) {
        const root = document.documentElement;
        root.setAttribute("data-lang", lang);

        // update lang attribute untuk SEO
        root.setAttribute("lang", lang === "id" ? "id" : "en");

        const buttons = document.querySelectorAll(".lang-toggle-btn");
        buttons.forEach((btn) => {
            if (btn.dataset.lang === lang) {
                btn.classList.add("active");
            } else {
                btn.classList.remove("active");
            }
        });
    }

    function initLangToggle() {
        const current = getStoredLang();
        applyLang(current);

        const buttons = document.querySelectorAll(".lang-toggle-btn");
        if (!buttons.length) return;

        buttons.forEach((btn) => {
            btn.addEventListener("click", function () {
                const lang = this.dataset.lang || "id";
                localStorage.setItem(LANG_KEY, lang);
                applyLang(lang);
            });
        });
    }

    /* ========== SCROLL REVEAL ========== */

    function initScrollReveal() {
        const elements = document.querySelectorAll(".reveal-scroll");
        if (!elements.length) return;

        const observer = new IntersectionObserver(
            (entries) => {
                entries.forEach((entry) => {
                    if (entry.isIntersecting) {
                        entry.target.classList.add("is-visible");
                        observer.unobserve(entry.target);
                    }
                });
            },
            {
                threshold: 0.15,
            }
        );

        elements.forEach((el) => observer.observe(el));
    }

    /* ========== NAVBAR SCROLL EFFECT ========== */

    function initNavbarScroll() {
        const navbar = document.querySelector(".navbar-glass");
        if (!navbar) return;

        function handleScroll() {
            if (window.scrollY > 10) {
                navbar.classList.add("navbar-scrolled");
            } else {
                navbar.classList.remove("navbar-scrolled");
            }
        }

        // langsung cek saat load
        handleScroll();

        window.addEventListener("scroll", handleScroll);
    }


    document.addEventListener("DOMContentLoaded", function () {
        initThemeToggle();
        initLangToggle();
        initScrollReveal();
        initNavbarScroll();
    });

})();
