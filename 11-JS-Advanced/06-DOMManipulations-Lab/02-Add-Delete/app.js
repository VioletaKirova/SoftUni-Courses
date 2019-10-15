function addItem() {
  function deleteItem(evt) {
    evt.target.parentElement.parentElement.removeChild(
      evt.target.parentElement
    );
  }

  let ul = document.getElementById("items");
  let input = document.getElementById("newText");

  if (input.value !== "") {
    let li = document.createElement("li");
    li.innerHTML = input.value;

    let link = document.createElement("a");
    link.innerHTML = "[Delete]";
    link.href = "#";
    li.appendChild(link);

    ul.appendChild(li);
  }

  [...document.querySelectorAll("a")].forEach(l =>
    l.addEventListener("click", deleteItem)
  );

  input.value = "";
}
