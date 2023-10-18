//Hides loader after 3 seconds and shows circle pagination
var loader = document.querySelector('.loader');
var welcomeCircle = document.querySelector('.welcome-navigation');
setTimeout(function () {
    loader.style.display = 'none';
    welcomeCircle.style.display = 'block';
}, 3000);

//Pagination function and select current content
$(document).ready(function () {
    const buttonsWrapper = document.querySelector(".circle-pagination");
    const slides = document.querySelector(".circles");

    buttonsWrapper.addEventListener("click", e => {
        if (e.target.nodeName === "BUTTON") {
            Array.from(buttonsWrapper.children).forEach(item =>
                item.classList.remove("current")
            );
            if (e.target.classList.contains("first")) {
                1
                slides.style.transform = "translateX(-0%)";
                e.target.classList.add("current");
            } else if (e.target.classList.contains("second")) {
                slides.style.transform = "translateX(-380px)";
                e.target.classList.add("current");
            } else if (e.target.classList.contains('third')) {
                slides.style.transform = 'translateX(-755px)';
                e.target.classList.add('current');
            }
        }
    });
});