function growingWord() {
  let colorMap = {
    blue: "blue",
    green: "green",
    red: "red"
  };

  let paragraph = document
    .getElementById("exercise")
    .getElementsByTagName("p")[0];

  if (paragraph.style.fontSize === "") {
    paragraph.style.fontSize = "2px";
    paragraph.style.color = colorMap.blue;
  } else {
    paragraph.style.fontSize =
      Number(paragraph.style.fontSize.replace("px", "")) * 2 + "px";

    paragraph.style.color =
      paragraph.style.color === colorMap.blue
        ? colorMap.green
        : paragraph.style.color === colorMap.green
        ? colorMap.red
        : colorMap.blue;
  }
}
