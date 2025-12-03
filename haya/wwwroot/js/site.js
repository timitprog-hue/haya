(function () {

    /* ========== THEME TOGGLE (dark / light) ========== */

    function initThemeToggle() {
        const root = document.documentElement;
        const btn = document.getElementById("themeToggle");
        const icon = document.getElementById("themeToggleIcon");
        const text = document.getElementById("themeToggleText");

        if (!btn || !icon || !text) return;

        const stored = localStorage.getItem("haya-theme");
        if (stored === "light" || stored === "dark") {
            root.setAttribute("data-theme", stored);
        }

        function applyTheme(theme) {
            root.setAttribute("data-theme", theme);
            localStorage.setItem("haya-theme", theme);

            if (theme === "light") {
                icon.textContent = "☀️";
                text.textContent = "Light";
            } else {
                icon.textContent = "🌙";
                text.textContent = "Dark";
            }
        }

        // initial
        applyTheme(root.getAttribute("data-theme") || stored || "dark");

        btn.addEventListener("click", () => {
            const current = root.getAttribute("data-theme") || "dark";
            applyTheme(current === "dark" ? "light" : "dark");
        });
    }

    /* ========== LANGUAGE TOGGLE (ID / EN) ========== */

    function initLangToggle() {
        const root = document.documentElement;
        const buttons = document.querySelectorAll(".lang-toggle-btn");
        if (!buttons.length) return;

        const idNodes = document.querySelectorAll(".lang-id");
        const enNodes = document.querySelectorAll(".lang-en");

        function applyLang(lang) {
            root.setAttribute("data-lang", lang);
            localStorage.setItem("haya-lang", lang);

            idNodes.forEach((el) => {
                el.style.display = lang === "id" ? "" : "none";
            });
            enNodes.forEach((el) => {
                el.style.display = lang === "en" ? "" : "none";
            });

            buttons.forEach((btn) => {
                if (btn.dataset.lang === lang) {
                    btn.classList.add("active");
                } else {
                    btn.classList.remove("active");
                }
            });
        }

        const stored = localStorage.getItem("haya-lang");
        const initial = stored === "en" ? "en" : "id";
        applyLang(initial);

        buttons.forEach((btn) => {
            btn.addEventListener("click", () => {
                const lang = btn.dataset.lang === "en" ? "en" : "id";
                applyLang(lang);
            });
        });
    }

    /* ========== SCROLL REVEAL ANIMATION ========== */

    function initScrollReveal() {
        const elements = document.querySelectorAll(".reveal-scroll");
        if (!elements.length) return;

        if (!("IntersectionObserver" in window)) {
            // Fallback: kalau browser jadul, langsung tampil semua
            elements.forEach((el) => el.classList.add("is-visible"));
            return;
        }

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
                threshold: 0.2
            }
        );

        elements.forEach((el) => observer.observe(el));
    }

    /* ========== NAVBAR SCROLL EFFECT (shadow + solid) ========== */

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

        handleScroll();
        window.addEventListener("scroll", handleScroll);
    }

    /* ========== SMOOTH NAV CLICK (one page) ========== */

    function initSmoothNavLinks() {
        const links = document.querySelectorAll(".nav-link-scroll");
        if (!links.length) return;

        links.forEach((link) => {
            link.addEventListener("click", (e) => {
                const targetId = link.getAttribute("href");
                if (!targetId || !targetId.startsWith("#")) return;

                const section = document.querySelector(targetId);
                if (!section) return;

                e.preventDefault();

                // pakai scrollIntoView + scroll-margin-top di CSS
                section.scrollIntoView({ behavior: "smooth", block: "start" });

                // close navbar collapse di mobile kalau ada
                const navbarCollapse = document.getElementById("mainNavbar");
                if (navbarCollapse && navbarCollapse.classList.contains("show")) {
                    const bsCollapse = bootstrap.Collapse.getInstance(navbarCollapse);
                    if (bsCollapse) {
                        bsCollapse.hide();
                    }
                }
            });
        });
    }

    /* ========== NAV SCROLLSPY (highlight menu sesuai section) ========== */

    function initScrollSpy() {
        const sections = document.querySelectorAll("section[id]");
        const navLinks = document.querySelectorAll(".nav-link-scroll");
        if (!sections.length || !navLinks.length) return;

        const linkMap = {};
        navLinks.forEach((link) => {
            const target = link.dataset.target;
            if (target) {
                linkMap[target] = link;
            }
        });

        function clearActive() {
            navLinks.forEach((l) => l.classList.remove("active"));
        }

        // Kalau IntersectionObserver ada, pakai itu
        if ("IntersectionObserver" in window) {
            const observer = new IntersectionObserver(
                (entries) => {
                    entries.forEach((entry) => {
                        const id = entry.target.id;
                        if (!id || !linkMap[id]) return;

                        if (entry.isIntersecting) {
                            clearActive();
                            linkMap[id].classList.add("active");
                        }
                    });
                },
                {
                    threshold: 0.45
                }
            );

            sections.forEach((sec) => observer.observe(sec));
        } else {
            // Fallback: pakai scroll event manual
            function onScroll() {
                let currentId = null;
                const offset = 120;

                sections.forEach((sec) => {
                    const rect = sec.getBoundingClientRect();
                    if (rect.top <= offset && rect.bottom > offset) {
                        currentId = sec.id;
                    }
                });

                if (currentId && linkMap[currentId]) {
                    clearActive();
                    linkMap[currentId].classList.add("active");
                }
            }

            window.addEventListener("scroll", onScroll);
            onScroll();
        }
    }

    /* ========== INIT SEMUA ========== */

    document.addEventListener("DOMContentLoaded", function () {
        initThemeToggle();
        initLangToggle();
        initScrollReveal();
        initNavbarScroll();
        initSmoothNavLinks();
        initScrollSpy();
    });

})();
