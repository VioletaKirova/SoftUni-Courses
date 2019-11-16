import { fetchData } from "./fetchData.js";

function createElem(tag) {
  return document.createElement(tag);
}

function formatTemperature(low, high) {
  return `${low}&deg;/${high}&deg;`;
}

function displayCurrentConditions(resObj) {
  html.message().textContent = "";
  html.currentDiv().innerHTML = `<div class="label">Current conditions</div>`;

  const parentDiv = createElem("div");
  parentDiv.classList.add("forecasts");

  const symbol = createElem("span");
  symbol.classList.add("condition");
  symbol.classList.add("symbol");
  symbol.innerHTML = weatherSymbolsMap[resObj.forecast.condition];

  const conditionSpan = createElem("span");
  conditionSpan.classList.add("condition");

  const townName = createElem("span");
  townName.classList.add("forecast-data");
  townName.textContent = resObj.name;

  const temperature = createElem("span");
  temperature.classList.add("forecast-data");
  temperature.innerHTML = formatTemperature(
    resObj.forecast.low,
    resObj.forecast.high
  );

  const condition = createElem("span");
  condition.classList.add("forecast-data");
  condition.textContent = resObj.forecast.condition;

  conditionSpan.appendChild(townName);
  conditionSpan.appendChild(temperature);
  conditionSpan.appendChild(condition);

  parentDiv.appendChild(symbol);
  parentDiv.appendChild(conditionSpan);

  html.currentDiv().appendChild(parentDiv);
}

function displayThreeDayForecast(resObj) {
  html.upcomingDiv().innerHTML = `<div class="label">Three-day forecast</div>`;

  const parentDiv = createElem("div");
  parentDiv.classList.add("forecast-info");

  resObj.forecast.forEach(x => {
    const upcomingSpan = createElem("span");
    upcomingSpan.classList.add("upcoming");

    const symbol = createElem("span");
    symbol.classList.add("symbol");
    symbol.innerHTML = weatherSymbolsMap[x.condition];

    const temperature = createElem("span");
    temperature.classList.add("forecast-data");
    temperature.innerHTML = formatTemperature(x.low, x.high);

    const condition = createElem("span");
    condition.classList.add("forecast-data");
    condition.textContent = x.condition;

    upcomingSpan.appendChild(symbol);
    upcomingSpan.appendChild(temperature);
    upcomingSpan.appendChild(condition);

    parentDiv.appendChild(upcomingSpan);
  });

  html.upcomingDiv().appendChild(parentDiv);
}

async function getForecast() {
  try {
    html.forecastDiv().style.display = "block";
    const locationName = html.locationInput().value;

    if (locationName === "") {
      throw new Error("Location name is required!");
    }

    const locations = await fetchData(`${baseUrl}locations.json`);
    const location = locations.find(x => x.name === locationName);

    if (location === undefined) {
      throw new Error(`Location with name ${locationName} is not available!`);
    }

    const currentConditions = await fetchData(
      `${baseUrl}forecast/today/${location.code}.json`
    );

    const threeDayForecast = await fetchData(
      `${baseUrl}forecast/upcoming/${location.code}.json`
    );

    displayCurrentConditions(currentConditions);
    displayThreeDayForecast(threeDayForecast);
  } catch (err) {
    html.message().textContent = err.message;
  }
}

const baseUrl = "https://judgetests.firebaseio.com/";

const html = {
  button: () => document.getElementById("submit"),
  locationInput: () => document.getElementById("location"),
  forecastDiv: () => document.getElementById("forecast"),
  currentDiv: () => document.getElementById("current"),
  upcomingDiv: () => document.getElementById("upcoming"),
  message: () => document.getElementById("message")
};

const weatherSymbolsMap = {
  Sunny: "&#x2600;",
  "Partly sunny": "&#x26C5;",
  Overcast: "&#x2601;",
  Rain: "&#x2614;",
  Degrees: "&#176;"
};

html.button().addEventListener("click", getForecast);
