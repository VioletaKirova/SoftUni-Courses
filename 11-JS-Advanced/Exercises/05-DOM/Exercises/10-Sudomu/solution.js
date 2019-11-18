// Score: 84/100

function solve() {
  function getRowValue(row) {
    return row.sort((a, b) => a - b).join("");
  }

  function checkMatrix() {
    for (let i = 0; i < matrix.length; i++) {
      let rowValue = getRowValue([...matrix[i]]);
      let colAsRowValue = getRowValue([...matrix].map(x => x[i]));

      if (rowValue !== correctValue || colAsRowValue !== correctValue) {
        return false;
      }
    }

    return true;
  }

  function getResult() {
    for (let i = 0; i < rows.length; i++) {
      matrix.push(
        Array.from(rows[i].children).map(x => x.firstElementChild.value)
      );
    }

    if (checkMatrix()) {
      table.style.border = "2px solid green";
      result.style.color = "green";
      result.innerHTML = "You solve it! Congratulations!";
    } else {
      table.style.border = "2px solid red";
      result.style.color = "red";
      result.innerHTML = "NOP! You are not done yet...";
    }

    matrix = [];
  }

  function clear() {
    inputs.forEach(x => (x.value = ""));
    table.style.border = "none";
    result.innerHTML = "";
  }

  let buttons = document.querySelectorAll("tfoot tr td button");
  let rows = [...document.querySelectorAll("tr")].slice(2);
  let inputs = document.querySelectorAll("input");
  let table = document.querySelector("table");
  let result = document.querySelector("#check p");

  let matrix = [];

  let correctValue = rows.reduce((a, b, i) => (a += i + 1), "");

  buttons[0].addEventListener("click", getResult);
  buttons[1].addEventListener("click", clear);
}
