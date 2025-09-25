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

document.getElementById("txtar").addEventListener("input", (event) => {
        var txt = document.getElementById("txtar").value;
        document.getElementById("txtch").innerHTML = `Počet znakov: ${txt.length}`;
        if (txt.length >= 20) {
            document.getElementById("txtar").style.border = "1px solid green";
        }
        else {
            document.getElementById("txtar").style.border = "1px solid red";
        }
    });

function AddToList() {
	var predmet = document.getElementById("predmet").value;
	document.getElementById("predmety").value += `${predmet},`;
	predmety = document.getElementById("predmety").value;
	var iny = predmety;
	var zoznam = [];
	for(let i = 0; i < predmety.length; i++){
		if (iny[i] == ","){
			zoznam.push(iny.substring(0, i))
			iny = iny.substring(i)[1]
		}
    }
	zoznam.forEach(pred => document.getElementById("subjects").innerHTML += `<p>${pred}</p>`);
}