import { get, post } from "./requester.js";
import { getVenueTemplate, getConfirmationTemplate } from "./templates.js";

const actions = {
  getVenues: async function() {
    const dateInput = html.dateInput();

    let venueIds;

    if (dateInput !== null && dateInput.value !== "") {
      try {
        venueIds = await post(
          "rpc",
          `custom/calendar?query=${dateInput.value}`
        );
      } catch (err) {
        console.log(err.message);
      }
    }

    this.displayVenues(venueIds);
  },
  displayVenues: async function(ids) {
    let venues = [];

    for (let i = 0; i < ids.length; i++) {
      const venue = await this.getVenue(ids[i]);
      venues.push(venue);
    }

    venues = venues.map(v => {
      return getVenueTemplate(
        v._id,
        v.name,
        v.price,
        v.description,
        v.startingHour
      );
    });

    html.wrapperDiv().innerHTML = venues.join("");
  },
  getVenue: async function(id) {
    let venue;

    try {
      venue = await get("appdata", `venues/${id}`);
    } catch (err) {
      console.log(err.message);
    }

    return venue;
  },
  info: function(e) {
    const venueId = e.target.dataset.target;
    const details = document
      .getElementById(venueId)
      .querySelector(".venue-details");

    details.style.display =
      details.style.display === "block" ? "none" : "block";
  },
  purchase: function(e) {
    const id = e.target.dataset.target;
    const venue = document.getElementById(id);
    const name = venue.querySelector(".venue-name").textContent;
    const quantity = venue.querySelector(".quantity").value;
    const price = venue.querySelector(".venue-price").textContent.split(" ")[0];

    html.wrapperDiv().innerHTML = getConfirmationTemplate(
      id,
      name,
      Number(quantity),
      Number(price)
    );
  },
  confirm: async function(e) {
    const id = e.target.dataset.target;
    const quantity = e.target.dataset.value;

    let fragment;

    try {
      fragment = await post(
        "rpc",
        `custom/purchase?venue=${id}&qty=${quantity}`
      );
    } catch (err) {
      console.log(err.message);
    }

    html.wrapperDiv().innerHTML = `You may print this page as your ticket${fragment.html}`;
  }
};

const html = {
  dateInput: () => document.getElementById("venueDate"),
  wrapperDiv: () => document.getElementById("venue-info")
};

function handleEvent(e) {
  if (actions[e.target.id] !== undefined) {
    actions[e.target.id]();
  } else if (actions[e.target.className] !== undefined) {
    actions[e.target.className](e);
  }
}

document.addEventListener("click", handleEvent);
