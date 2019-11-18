function solve() {
  function createParagraph(parent, value) {
    let p = document.createElement("p");
    p.innerHTML = value;
    parent.appendChild(p);
  }

  function getSpecificCoordinates(coordinates, direction) {
    return [...coordinates]
      .filter(x => x.toLocaleLowerCase().startsWith(direction))
      .slice(-1)[0];
  }

  function getCoordinatesNumberString(coordinates) {
    return coordinates.match(numberPattern)[0];
  }

  function decodeCoordinatesNumber(string) {
    return `${string.match(/\d{2}/gm)[0]}.${string.match(/\d{6}/gm)[0]}`;
  }

  function decodeMessage(key, string) {
    return string.substring(key.length, string.length - key.length);
  }

  const key = document.getElementById("string").value;
  const text = document.getElementById("text").value;
  let output = document.getElementById("result");

  const coordinatesPattern = /(north|east)(.*?)(\d{2})([^,]*?),([^,]*?)(\d{6})/gim;
  const numberPattern = /(\d{2})([^,]*?),([^,]*?)(\d{6})/gim;
  const messagePattern = `${key}(.+)${key}`;

  let coordinates = text.match(coordinatesPattern);
  let northCoordinates = getSpecificCoordinates(coordinates, "north");
  let eastCoordinates = getSpecificCoordinates(coordinates, "east");

  let decodedNorthNumber = decodeCoordinatesNumber(
    getCoordinatesNumberString(northCoordinates)
  );
  let decodedEasthNumber = decodeCoordinatesNumber(
    getCoordinatesNumberString(eastCoordinates)
  );

  let messageStr = text.match(new RegExp(messagePattern, "gm"))[0];
  let decodedMessage = decodeMessage(key, messageStr);

  createParagraph(output, `${decodedNorthNumber} N`);
  createParagraph(output, `${decodedEasthNumber} E`);
  createParagraph(output, `Message: ${decodedMessage}`);

  document.getElementById("string").value = "";
  document.getElementById("text").value = "";
}
