const email = document.getElementById("email");

email.addEventListener("input", (event) => {
    debugger
    if (email.validity.typeMismatch) {
        email.setCustomValidity("Voer een geldig emailadres in!");
        email.reportValidity();
    } else {
        email.setCustomValidity("");
    }
});

   