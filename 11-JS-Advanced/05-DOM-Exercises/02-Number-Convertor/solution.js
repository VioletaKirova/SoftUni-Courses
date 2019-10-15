function solve() {
  const operationsMap = {
    binary: x => x.toString(2),
    hexadecimal: x => x.toString(16).toUpperCase()
  };

  let optionsParent = document.getElementById("selectMenuTo");

  let binaryOption = document.createElement("option");
  binaryOption.value = "binary";
  binaryOption.innerHTML = "Binary";

  let hexadecimalOption = document.createElement("option");
  hexadecimalOption.value = "hexadecimal";
  hexadecimalOption.innerHTML = "Hexadecimal";

  optionsParent.appendChild(binaryOption);
  optionsParent.appendChild(hexadecimalOption);

  function convert() {
    let selectedOption = document.getElementById("selectMenuTo");
    let input = document.getElementById("input");

    if (selectedOption.value !== "" && input.value !== "") {
      let result = operationsMap[selectedOption.value](Number(input.value));
      let output = document.getElementById("result");
      output.value = result;
    }
  }

  document
    .querySelector("#container button")
    .addEventListener("click", convert);
}
