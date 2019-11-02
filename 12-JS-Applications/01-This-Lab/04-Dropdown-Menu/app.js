function solve() {
  function changeColor() {
    box.style.backgroundColor = this.textContent;
    box.style.color = "black";
  }

  function showMenu() {
    if (dropdown.style.display === "" || dropdown.style.display === "none") {
      dropdown.style.display = "block";
    } else {
      dropdown.style.display = "none";
      box.style.backgroundColor = "black";
      box.style.color = "white";
    }
  }

  let dropdown = document.querySelector("#dropdown-ul");
  let box = document.querySelector("#box");
  let button = document.querySelector("#dropdown");
  let listItems = Array.from(document.querySelectorAll("li"));

  button.addEventListener("click", showMenu);
  listItems.forEach(li => li.addEventListener("click", changeColor));
}
