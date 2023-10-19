﻿//Hides loader after 3 seconds and shows circle pagination
var loader = document.querySelector('.loader');
var welcomeCircle = document.querySelector('.welcome-navigation');
setTimeout(function () {
    loader.style.display = 'none';
    welcomeCircle.style.display = 'block';
}, 1000);

//Pagination function and select current content
$(document).ready(function () {
    const buttonsWrapper = document.querySelector(".nav-pagination");
    const slides = document.querySelector(".circles");
    const contentWidth = 375; // Adjust this value according to your content width

    // Initialize the "current" class based on the initial scroll position
    const updateCurrentButton = () => {
        const scrollPosition = slides.scrollLeft;
        const activeButtonIndex = Math.floor(scrollPosition / contentWidth);

        Array.from(buttonsWrapper.children).forEach((item, index) => {
            if (index === activeButtonIndex) {
                item.classList.add("current");
            } else {
                item.classList.remove("current");
            }
        });
    };

    // Initial update
    updateCurrentButton();

    // Listen for scroll events on the content element
    slides.addEventListener("scroll", updateCurrentButton);

    buttonsWrapper.addEventListener("click", e => {
        if (e.target.nodeName === "BUTTON") {
            Array.from(buttonsWrapper.children).forEach(item =>
                item.classList.remove("current")
            );
            let scrollAmount = 0;
            if (e.target.classList.contains("first")) {
                scrollAmount = 0;
                e.target.classList.add("current");
            } else if (e.target.classList.contains("second")) {
                scrollAmount = 415; // Adjust the pixel value according to your content width
                e.target.classList.add("current");
            } else if (e.target.classList.contains('third')) {
                scrollAmount = 830; // Adjust the pixel value according to your content width
                e.target.classList.add("current");
            }

            slides.scrollLeft = scrollAmount;
           
        }
    });
});