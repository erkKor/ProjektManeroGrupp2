//Hides loader after 3 seconds and shows circle pagination
var loader = document.querySelector('.loader');
var welcomeCircle = document.querySelector('.welcome-navigation');
setTimeout(function () {
    loader.style.display = 'none';
    welcomeCircle.style.display = 'block';
}, 3000);

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

//Toggle dropdown menu in selected-category controller
function toggleDropdown() {
    document.getElementById("myDropdown").classList.toggle("show");
}



//Update quantity in ShoppingCart without reload
$(document).ready(function () {
    $(".increment-btn").click(function (event) {
        event.preventDefault();
        var itemId = $(this).data('item-id');
        updateQuantity(itemId, 'increment');
    });

    $(".decrement-btn").click(function (event) {
        event.preventDefault();
        var itemId = $(this).data('item-id');
        updateQuantity(itemId, 'decrement');
    });

    function updateQuantity(itemId, action) {
        $.ajax({
            type: 'POST',
            url: '/ShoppingCart/UpdateQuantity',
            data: { itemId: itemId, action: action },
            success: function (data) {
                $("span[data-item-id='" + itemId + "']").text(data.newQuantity);
            },
            error: function () {
                alert('Failed to update quantity.');
            }
        });
    }
});

// Validation of Forms 
const validateEmail = (event) => {
    const regExEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
    const xMark = document.getElementById("x-mark")
    const checkMark = document.getElementById("check-mark")

    if (regExEmail.test(event.target.value)) {
        checkMark.classList.remove("i-hide")
        xMark.classList.add("i-hide")

    }
    else {
        xMark.classList.remove("i-hide")
        checkMark.classList.add("i-hide")
    }
}

const validateFirstName = (event) => {
    const regExName = /^[A-Z][a-zA-Z]*$/
    const xMark = document.getElementById("x-mark-FirstName")
    const checkMark = document.getElementById("check-mark-FirstName")

    if (regExName.test(event.target.value)) {
        checkMark.classList.remove("i-hide")
        xMark.classList.add("i-hide")

    }
    else {
        xMark.classList.remove("i-hide")
        checkMark.classList.add("i-hide")
    }
}

const validateLastName = (event) => {
    const regExName = /^[A-Z][a-zA-Z]*$/
    const xMark = document.getElementById("x-mark-LastName")
    const checkMark = document.getElementById("check-mark-LastName")

    if (regExName.test(event.target.value)) {
        checkMark.classList.remove("i-hide")
        xMark.classList.add("i-hide")

    }
    else {
        xMark.classList.remove("i-hide")
        checkMark.classList.add("i-hide")
    }
}

