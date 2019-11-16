import { fetchData } from "./fetchData.js";
import { createElement } from "./createElement.js";

function formatTemperature(low, high) {
  return `${low}&deg;/${high}&deg;`;
}

function displayCurrentConditions(resObj) {
  html.message().textContent = "";
  html.currentDiv().innerHTML = currentDivLabel;

  const { forecast, name } = resObj;
  const symbolContent = weatherSymbolsMap[forecast.condition];
  const temperatureContent = formatTemperature(forecast.low, forecast.high);

  const wrapperDiv = createElement("div", ["forecasts"]);
  const symbol = createElement("span", ["condition", "symbol"], symbolContent);
  const wrapperSpan = createElement("span", ["condition"]);
  const townName = createElement("span", ["forecast-data"], name);
  const temperature = createElement("span", ["forecast-data"], temperatureContent);
  const condition = createElement("span", ["forecast-data"], forecast.condition);

  wrapperSpan.append(townName, temperature, condition);
  wrapperDiv.append(symbol, wrapperSpan);

  html.currentDiv().appendChild(wrapperDiv);
}

function displayThreeDayForecast(resObj) {
  html.upcomingDiv().innerHTML = upcomingDivLabel;

  const wrapperDiv = createElement("div", ["forecast-info"]);

  resObj.forecast.forEach(x => {
    const wrapperSpan = createElement("span", ["upcoming"]);
    const symbol = createElement("span", ["symbol"], weatherSymbolsMap[x.condition]);
    const temperature = createElement("span", ["forecast-data"], formatTemperature(x.low, x.high));
    const condition = createElement("span", ["forecast-data"], x.condition);

    wrapperSpan.append(symbol, temperature, condition);
    wrapperDiv.appendChild(wrapperSpan);
  });

  html.upcomingDiv().appendChild(wrapperDiv);
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
const currentDivLabel = `<div class="label">Current conditions</div>`;
const upcomingDivLabel = `<div class="label">Three-day forecast</div>`;

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
