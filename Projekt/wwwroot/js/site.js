function HideShow() {
    if (document.getElementById("hidenseek").hidden) {
        document.getElementById("hidenseek").hidden = false;
    }
    else {
        document.getElementById("hidenseek").hidden = true;
    }
}

var klk = 0;
function Pctklik() {
    klk += 1;
    if (klk == 5) {
        document.getElementById("changebg").style.backgroundColor = "lightblue";
    }
    document.getElementById("pctklk").innerHTML = `Počet kliknutí: ${klk}`
}