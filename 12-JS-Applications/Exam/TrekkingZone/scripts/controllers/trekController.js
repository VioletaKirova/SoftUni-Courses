import {
  getSessionInfo,
  partials,
  errorNotify,
  showNotification
} from "../common.js";
import { get, post, put, del } from "../requester.js";

export function getCreate(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/trek/create.hbs");
}

export function postCreate(ctx) {
  getSessionInfo(ctx);

  const { location, dateTime, description, imageURL } = ctx.params;

  if (
    location &&
    dateTime &&
    description &&
    imageURL &&
    location.length >= 6 &&
    description.length >= 10
  ) {
    const data = {
      name: location,
      dateTime,
      description,
      imageURL,
      likes: 0,
      organizer: ctx.username
    };

    post("appdata", "treks", data, "Kinvey")
      .then(() => {
        showNotification("success", "Trek created successfully!");
        setTimeout(() => ctx.redirect("#/"), 2000);
      })
      .catch(console.error);
  } else {
    errorNotify(
      "All fields are required.\nLocation must be at least 6 characters long.\nDescription must be at least 10 characters long."
    );
  }
}

export function getDetails(ctx) {
  getSessionInfo(ctx);

  const id = ctx.params.id;

  get("appdata", `treks/${id}`, "Kinvey")
    .then(data => {
      ctx.trek = data;

      if (data._acl.creator == ctx.userId) {
        ctx.isCreator = true;
      } else {
        ctx.isCreator = false;
      }

      this.loadPartials(partials).partial("./templates/trek/details.hbs");
    })
    .catch(console.error);
}

export function getEdit(ctx) {
  getSessionInfo(ctx);

  const id = ctx.params.id;

  get("appdata", `treks/${id}`, "Kinvey")
    .then(data => {
      ctx.trek = data;

      this.loadPartials(partials).partial("./templates/trek/edit.hbs");
    })
    .catch(console.error);
}

export function postEdit(ctx) {
  getSessionInfo(ctx);

  const {
    id,
    location,
    dateTime,
    description,
    imageURL,
    likes,
    organizer
  } = ctx.params;

  if (
    location &&
    dateTime &&
    description &&
    imageURL &&
    location.length >= 6 &&
    description.length >= 10
  ) {
    const data = {
      name: location,
      dateTime,
      description,
      imageURL,
      likes: Number(likes),
      organizer
    };

    put("appdata", `treks/${id}`, data, "Kinvey")
      .then(() => {
        showNotification("success", "Trek edited successfully!");
        setTimeout(() => ctx.redirect(`#/details/${id}`), 2000);
      })
      .catch(console.error);
  } else {
    errorNotify(
      "All fields are required.\nLocation must be at least 6 characters long.\nDescription must be at least 10 characters long."
    );
  }
}

export function processDelete(ctx) {
  const id = ctx.params.id;

  del("appdata", `treks/${id}`, "Kinvey")
    .then(() => {
      showNotification("success", "You closed the trek successfully!");
      setTimeout(() => ctx.redirect("#/"), 2000);
    })
    .catch(console.error);
}

export function processLike(ctx) {
  const id = ctx.params.id;

  get("appdata", `treks/${id}`, "Kinvey")
    .then(data => {
      data.likes++;

      put("appdata", `treks/${id}`, data, "Kinvey")
        .then(() => {
          showNotification("success", "You liked the trek successfully!");
          setTimeout(() => ctx.redirect(`#/details/${id}`), 2000);
        })
        .catch(console.error);
    })
    .catch(console.error);
}
