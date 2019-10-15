function deleteByEmail() {
  let input = document.querySelector("input");
  let rows = [...document.querySelectorAll("tr")];

  let result = document.getElementById("result");
  result.innerHTML = "";

  if (input.value !== "") {
    for (let i = 0; i < rows.length; i++) {
      if (rows[i].innerHTML.includes(input.value)) {
        rows[i].parentElement.removeChild(rows[i]);
        input.value = "";
        return;
      }
    }
  }

  result.innerHTML = "Not found.";
}
