$(document).ready(function () {
    $('.radio').change(function () {
        $('.radio').not(this).prop('disabled', this.checked);
    });
});


// Start de timer wanneer de pagina geladen is
document.addEventListener("DOMContentLoaded", function () {
    startTimer(30); // Stel de timer in op 30 seconden (of een andere gewenste tijd)
});

// Timer functie die elke seconde wordt aangeroepen
function startTimer(duration) {
    var timerElement = document.getElementById("timer");
    var timer = duration;
    var interval = setInterval(function () {
        timerElement.textContent = timer + " seconden resterend";
        if (--timer < 0) {
            clearInterval(interval); // Stop de timer wanneer deze afloopt
            startNewRound(); // Start een nieuwe ronde na het aflopen van de timer
        }
    }, 1000);
}

// Functie om een nieuwe ronde te starten
function startNewRound() {
    // Voer hier de logica uit om een nieuwe ronde te starten, bijvoorbeeld een AJAX-verzoek naar de GameController
    // Laad een nieuwe afspeellijst en vernieuw de weergave
}