function solve() {
  const symbolsMap = {
    "!": 1,
    "%": 2,
    "#": 3,
    $: 4
  };

  let text = JSON.parse(document.getElementById("array").value);
  let key = text.shift();

  let output = document.getElementById("result");

  let pattern = new RegExp(`(^|\\s)(${key}\\s+)([A-Z!%$#]{8,})([\\s\\.,]|$)`, "gim");

  text.forEach(line => {
    while (word = pattern.exec(line)) {
      if (word[3].toLocaleUpperCase() === word[3]) {
        let decodedWord = Array.from(word[3])
          .map(char => {
            return symbolsMap[char] !== undefined ? symbolsMap[char] : char;
          })
          .join("")
          .toLocaleLowerCase();

          line = line.replace(word[3], decodedWord);
      }
    }
    const p = document.createElement("p");
    p.innerHTML = line;
    output.appendChild(p);

    document.getElementById("array").value = "";
  });
}
