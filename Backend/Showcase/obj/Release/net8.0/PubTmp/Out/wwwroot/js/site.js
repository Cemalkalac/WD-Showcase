var tablinks = document.getElementsByClassName("tab-links");
var tabcontents = document.getElementsByClassName("tab-contents");

function opentab(tabname) {
    for (tablink of tablinks) {
        tablink.classList.remove("active-link");
    }
    for (tabcontent of tabcontents) {
        tabcontent.classList.remove("active-tab");
    }
    event.currentTarget.classList.add("active-link");
    document.getElementById(tabname).classList.add("active-tab");
}

var headerText = document.getElementById('header-text');
var header = document.querySelector('header');

var urlWithoutDomain = window.location.pathname;

if (urlWithoutDomain != "/" && urlWithoutDomain != "/home") {
    headerText.style.display = "none";
    header.style.width = "unset";
    header.style.height = "unset";
    header.style.backgroundImage = "none";
}