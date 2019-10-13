function toggle() {
    let button = document.querySelector("span.button");
    let text = document.querySelector("#extra");

    if(button.innerHTML === "More"){
        button.innerHTML = "Less";
        text.style.display = "block";
    } else {
        button.innerHTML = "More";
        text.style.display = "none";
    }
}