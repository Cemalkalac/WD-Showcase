document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("contactForm").addEventListener("submit", function (event) {
        var response = grecaptcha.getResponse();
        if (response.length === 0) {
            event.preventDefault();
            alert("Maak alsutblieft de recaptcha.");
        }
    });
});