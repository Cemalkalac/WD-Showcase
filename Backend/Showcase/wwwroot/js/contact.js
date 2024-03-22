const email = document.querySelector("#email");

if (document.querySelector("input")) {
    email.addEventListener("input", (event) => {
        if (email.validity.typeMismatch) {
            email.setCustomValidity("Voer een geldig emailadres in!");
            email.reportValidity();
        } else {
            email.setCustomValidity("");
        }
    });
}

const subject = document.querySelector("#onderwerp");

if (document.querySelector("input")) {
    subject.addEventListener("input", (event) => {
        if (subject.value.length > 200) {
            subject.value = subject.value.slice(0, 200);
            subject.setCustomValidity("Maximaal aantal karakters is 200!");
        } else {
            subject.setCustomValidity("");
        }
        subject.reportValidity();
    });
}


const message = document.querySelector("#message");

if (document.querySelector("input")) {
    message.addEventListener("input", (event) => {
        if (message.value.length > 600) {
            message.value = message.value.slice(0, 600);
            message.setCustomValidity("Maximaal aantal karakters is 600!");
        } else {
            message.setCustomValidity("");
        }
        message.reportValidity();
    });
}