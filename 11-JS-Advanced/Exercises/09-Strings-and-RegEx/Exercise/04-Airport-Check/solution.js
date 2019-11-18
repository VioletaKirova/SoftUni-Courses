function solve() {
  const [text, infoType] = document.getElementById("string").value.split(",");

  let namePattern = /( [A-Z][A-Za-z]*-[A-Z][A-Za-z]* )|( [A-Z][A-Za-z]*-[A-Z][A-Za-z]*\.-[A-Z][A-Za-z]* )/gm;
  let airportPattern = / [A-Z]{3}\/[A-Z]{3} /gm;
  let flightNumberPattern = / [A-Z]{1,3}[0-9]{1,5} /gm;
  let companyNamePattern = /- [A-Z][A-Za-z]*\*[A-Z][A-Za-z]* /gm;

  let nameMatch = text.match(namePattern);
  let name =
    nameMatch !== null
      ? nameMatch[0]
          .split("-")
          .join(" ")
          .trim()
      : "";

  let airportMatch = text.match(airportPattern);
  let airport =
    airportMatch !== null
      ? airportMatch[0]
          .split("/")
          .join(" to ")
          .trim()
      : "";

  let flightNumberMatch = text.match(flightNumberPattern);
  let flightNumber =
    flightNumberMatch !== null ? flightNumberMatch[0].trim() : "";

  let companyNameMatch = text.match(companyNamePattern);
  let companyName =
    companyNameMatch !== null
      ? companyNameMatch[0]
          .replace("*", " ")
          .substring(2)
          .trim()
      : "";

  let outputMap = {
    name: `Mr/Ms, ${name}, have a nice flight!`,
    flight: `Your flight number ${flightNumber} is from ${airport}.`,
    company: `Have a nice flight with ${companyName}.`,
    all: `Mr/Ms, ${name}, your flight number ${flightNumber} is from ${airport}. Have a nice flight with ${companyName}.`
  };

  document.getElementById("result").innerHTML = outputMap[infoType.trim()];
  document.getElementById("string").value = "";
}
