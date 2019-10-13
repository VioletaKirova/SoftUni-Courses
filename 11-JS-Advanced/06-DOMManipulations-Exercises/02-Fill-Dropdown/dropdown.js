function addItem() {
    let text = document.getElementById("newItemText");
    let value = document.getElementById("newItemValue");
    let menu = document.getElementById("menu");

    if(text.value !== "" && value.value !== ""){
        let option = document.createElement("option");
        option.innerHTML = text.value;
        option.value = value.value;

        menu.appendChild(option);

        text.value = "";
        value.value = "";
    }
}