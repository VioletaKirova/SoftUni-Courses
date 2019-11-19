function solve() {
  let sentences = document
    .getElementById("input")
    .innerHTML.split(".")
    .filter(x => x !== "");

  let output = document.getElementById("output");

  for (let i = 0; i < sentences.length; i += 3) {
    let p = document.createElement("p");

    for (let j = 0; j < 3; j++) {
      if (j + i < sentences.length) {
        p.innerHTML += sentences[i + j] + ".";
      }
    }

    output.appendChild(p);
  }
}
