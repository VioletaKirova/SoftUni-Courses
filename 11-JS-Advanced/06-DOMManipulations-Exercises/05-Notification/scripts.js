function notify(message) {
    function hideMessage(){
        output.style.display = "none";
    }

    let output = document.querySelector("#notification");
    output.innerHTML = message;
    output.style.display = "block";

    setTimeout(hideMessage, 2000);
}