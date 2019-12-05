import { getSessionInfo, partials } from "../common.js";
import { post, get, put, del } from "../requester.js";

export function getCreate(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/cause/create.hbs");
}

export function postCreate(ctx) {
  getSessionInfo(ctx);

  const { cause, pictureUrl, neededFunds, description } = ctx.params;
  const data = {
    cause,
    donors: [],
    pictureUrl,
    neededFunds,
    description,
    collectedFunds: 0
  };

  post("appdata", "causes", data, "Kinvey")
    .then(() => {
      ctx.redirect("#/all");
    })
    .catch(console.error);
}

export function getAll(ctx) {
  getSessionInfo(ctx);

  get("appdata", "causes", "Kinvey").then(data => {
    ctx.causes = data;

    this.loadPartials(partials).partial("./templates/cause/all.hbs");
  });
}

export function getDetails(ctx) {
  getSessionInfo(ctx);

  get("appdata", `causes/${ctx.params.id}`, "Kinvey").then(data => {
    ctx.cause = data;
    ctx.isCreator = data._acl.creator == ctx.userId;

    this.loadPartials(partials).partial("./templates/cause/details.hbs");
  });
}

export function postDonate(ctx) {
  getSessionInfo(ctx);

  const { id, currentDonation } = ctx.params;

  if (typeof Number(currentDonation) === "number") {
    get("appdata", `causes/${id}`, "Kinvey").then(data => {
      data.donors.push(ctx.username);
      data.collectedFunds += Number(currentDonation);

      put("appdata", `causes/${id}`, data, "Kinvey").then(() => {
        ctx.redirect(`#/details/${id}`);
      });
    });
  } else {
    alert("Donation input is invalid!");
  }
}

export function processDelete(ctx) {
  del("appdata", `causes/${ctx.params.id}`, "Kinvey").then(() => {
    ctx.redirect("#/all");
  });
}
