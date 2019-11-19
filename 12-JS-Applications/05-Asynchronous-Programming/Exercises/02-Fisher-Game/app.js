import { fetchData } from "../01-Forecaster/fetchData.js";

function clearAddCatchInput() {
  html.anglerInput().value = "";
  html.weightInput().value = "";
  html.speciesInput().value = "";
  html.locationInput().value = "";
  html.baitInput().value = "";
  html.captureTimeInput().value = "";
}

function validateAddCatchInput() {
  return (
    html.anglerInput().value === "" ||
    html.weightInput().value === "" ||
    html.speciesInput().value === "" ||
    html.locationInput().value === "" ||
    html.baitInput().value === "" ||
    html.captureTimeInput().value === ""
  );
}

function showErrorMessage(message) {
  const messageObj = JSON.parse(message);
  html.message().textContent = `Error: ${messageObj.status} ${messageObj.statusText}`;

  return html.message().textContent;
}

function checkInputData(condition) {
  if (condition) {
    const errObj = {
      status: "Incorrect input!",
      statusText: "Please fill in all fields!"
    };

    showErrorMessage(JSON.stringify(errObj));
  }

  return !condition;
}

function createElem(tag) {
  return document.createElement(tag);
}

function createField(labelName, type, className, value) {
  return `<label>${labelName}</label>\n<input type="${type}" class="${className}" value="${value}" />\n<hr>`;
}

function clone(selector) {
  return document.querySelector(selector).cloneNode(true);
}

async function loadCatches() {
  html.catchesDiv().innerHTML = "";
  html.message().textContent = "";

  const catchFields = new Array(6);
  let catches;

  try {
    catches = await fetchData(`${baseUrl}.json`);
  } catch (err) {
    showErrorMessage(err.message);
  }

  if (catches !== undefined) {
    Object.entries(catches).forEach(x => {
      const wrapperDiv = createElem("div");
      wrapperDiv.classList.add("catch");
      wrapperDiv.setAttribute("data-id", x[0]);

      catchFields[0] = createField("Angler", "text", "angler", x[1].angler);
      catchFields[1] = createField("Weight", "number", "weight", Number(x[1].weight));
      catchFields[2] = createField("Species", "text", "species", x[1].species);
      catchFields[3] = createField("Location", "text", "location", x[1].location);
      catchFields[4] = createField("Bait", "text", "bait", x[1].bait);
      catchFields[5] = createField("Capture Time", "number", "captureTime", Number(x[1].captureTime));

      wrapperDiv.innerHTML = `${catchFields.join("\n")}`;
      wrapperDiv.append(updateBtn.cloneNode(true), deleteBtn.cloneNode(true));
      html.catchesDiv().appendChild(wrapperDiv);
    });
  }
}

async function updateCatch(evt) {
  const element = evt.target.parentNode;
  const catchId = element.getAttribute("data-id");

  let bodyObj = {};

  Array.from(element.children)
    .filter(x => x.tagName == "INPUT")
    .forEach(x => {
      bodyObj[x.className] = x.value;
    });

  const validationResult = checkInputData(
    Object.values(bodyObj).some(x => x === "")
  );

  if (validationResult === false) {
    const p = createElem("p");
    p.textContent = html.message().textContent;
    element.insertBefore(p, element.children[0]);

    return;
  }

  const headers = {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(bodyObj)
  };

  try {
    await fetch(`${baseUrl}/${catchId}.json`, headers);
  } catch (err) {
    showErrorMessage(err.message);
  }

  loadCatches();
}

async function deleteCatch(evt) {
  const catchId = evt.target.parentNode.getAttribute("data-id");

  const headers = {
    method: "DELETE"
  };

  try {
    await fetch(`${baseUrl}/${catchId}.json`, headers);
  } catch (err) {
    showErrorMessage(err.message);
  }

  loadCatches();
}

async function addCatch() {
  if (checkInputData(validateAddCatchInput()) === false) {
    return;
  }

  const catchInputValues = {
    angler: html.anglerInput().value,
    weight: html.weightInput().value,
    species: html.speciesInput().value,
    location: html.locationInput().value,
    bait: html.baitInput().value,
    captureTime: html.captureTimeInput().value
  };

  const headers = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(catchInputValues)
  };

  try {
    await fetch(`${baseUrl}.json`, headers);
    clearAddCatchInput();
  } catch (err) {
    showErrorMessage(err.message);
  }

  loadCatches();
}

const html = {
  catchesDiv: () => document.getElementById("catches"),
  anglerInput: () => document.getElementById("anglerInput"),
  weightInput: () => document.getElementById("weightInput"),
  speciesInput: () => document.getElementById("speciesInput"),
  locationInput: () => document.getElementById("locationInput"),
  baitInput: () => document.getElementById("baitInput"),
  captureTimeInput: () => document.getElementById("captureTimeInput"),
  message: () => document.getElementById("message")
};

const baseUrl = "https://fisher-game.firebaseio.com/catches";

const actions = {
  loadBtn: loadCatches,
  addBtn: addCatch,
  update: updateCatch,
  delete: deleteCatch
};

const updateBtn = clone("button.update");
const deleteBtn = clone("button.delete");

html.catchesDiv().innerHTML = "";

document.addEventListener("click", function(e) {
  if (actions[e.target.id] !== undefined) {
    actions[e.target.id](e);
  } else if (actions[e.target.className] !== undefined) {
    actions[e.target.className](e);
  }
});
