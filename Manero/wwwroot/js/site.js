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


//$(document).ready(function () {
//    $('#addToCartForm').submit(function (e) {
//        e.preventDefault(); // Prevent the default form submission
//        $.ajax({
//            url: this.action,
//            type: this.method,
//            data: $(this).serialize(),
//            success: function (data) {
//                $('#cartTable tbody').html(data); // Update the cart items section
//            }
//        });
//    });
//});


//$(document).ready(function () {
//    $('#addToCartForm').submit(function (e) {
//        e.preventDefault(); // Prevent default form submission

//        // Collect product details
//        var productId = $('#productId').val(); // Get product ID

//        // You can fetch other details similarly or by other methods

//        // Create a JavaScript object to represent the CartItem
//        var cartItem = {
//            id: productId,
//            // Add other properties here: name, price, quantity, etc.
//            // Fetch these values from the form or from your model
//        };

//        // Send the CartItem to the server using AJAX
//        $.ajax({
//            url: this.action,
//            type: this.method,
//            contentType: 'application/json',
//            data: JSON.stringify(cartItem),
//            success: function (response) {
//                // Handle success if needed
//            }
//        });
//    });
//});

//$(document).ready(function () {
//    $('#addToCartForm').submit(function (e) {
//        e.preventDefault(); // Prevent default form submission

//        var formData = @Html.Raw(Json.Serialize(Model)); // Serialize the model to JSON

//        $.ajax({
//            url: this.action,
//            type: this.method,
//            contentType: 'application/json',
//            data: JSON.stringify(formData), // Send serialized model as JSON
//            success: function (response) {
//                // Handle success if needed
//            }
//        });
//    });
//});