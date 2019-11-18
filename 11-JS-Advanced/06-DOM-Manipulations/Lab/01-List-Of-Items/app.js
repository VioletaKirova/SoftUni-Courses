function addItem() {
  let ul = document.getElementById("items");
  let input = document.getElementById("newItemText");

  if (input.value !== "") {
    let li = document.createElement("li");
    li.innerHTML = input.value;
    ul.appendChild(li);
  }

  input.value = "";
}
