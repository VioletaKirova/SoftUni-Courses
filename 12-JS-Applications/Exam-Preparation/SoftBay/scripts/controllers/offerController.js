import {
  getSessionInfo,
  partials,
  showNotification,
  errorNotify
} from "../common.js";
import { get, post, put, del } from "../requester.js";

export function getCreate(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/offer/create.hbs");
}

export function postCreate(ctx) {
  getSessionInfo(ctx);

  const { product, description, price, pictureUrl } = ctx.params;

  if (product && description && price && pictureUrl) {
    const data = {
      product,
      price,
      description,
      imageUrl: pictureUrl
    };

    post("appdata", "offers", data, "Kinvey")
      .then(() => {
        showNotification("success", "You successfully created an offer!");
        setTimeout(() => ctx.redirect("#/all"), 2000);
      })
      .catch(err => {
        console.log(err);
        errorNotify("Something went wrong.");
      });
  } else {
    errorNotify("Please fill in all fields.");
  }
}

export function getAll(ctx) {
  getSessionInfo(ctx);

  get("appdata", "offers", "Kinvey")
    .then(data => {
      data.forEach((x, i) => {
        x.number = i;

        if (x._acl.creator === ctx.userId) {
          x.isCreator = true;
        } else {
          x.isCreator = false;
        }
      });

      ctx.offers = data;

      this.loadPartials(partials).partial("./templates/offer/all.hbs");
    })
    .catch(console.error);
}

export function getEdit(ctx) {
  getSessionInfo(ctx);

  const id = ctx.params.id;

  get("appdata", `offers/${id}`, "Kinvey")
    .then(data => {
      ctx.offer = data;

      this.loadPartials(partials).partial("./templates/offer/edit.hbs");
    })
    .catch(console.error);
}

export function postEdit(ctx) {
  const id = ctx.params.id;
  const { product, description, price, pictureUrl } = ctx.params;

  if (product && description && price && pictureUrl) {
    const data = {
      product,
      price,
      description,
      imageUrl: pictureUrl
    };

    put("appdata", `offers/${id}`, data, "Kinvey")
      .then(() => {
        showNotification("success", "You successfully edited the offer!");
        setTimeout(() => ctx.redirect(`#/details/${id}`), 2000);
      })
      .catch(err => {
        console.log(err);
        errorNotify("Something went wrong.");
      });
  } else {
    errorNotify("Please fill in all fields.");
  }
}

export function getDetails(ctx) {
  getSessionInfo(ctx);

  const id = ctx.params.id;

  get("appdata", `offers/${id}`, "Kinvey")
    .then(data => {
      ctx.offer = data;

      this.loadPartials(partials).partial("./templates/offer/details.hbs");
    })
    .catch(console.error);
}

export function getDelete(ctx) {
  getSessionInfo(ctx);

  const id = ctx.params.id;

  get("appdata", `offers/${id}`, "Kinvey")
    .then(data => {
      ctx.offer = data;

      this.loadPartials(partials).partial("./templates/offer/delete.hbs");
    })
    .catch(console.error);
}

export function postDelete(ctx) {
  const id = ctx.params.id;

  del("appdata", `offers/${id}`, "Kinvey")
    .then(() => {
      showNotification("success", "You successfully deleted the offer!");
      setTimeout(() => ctx.redirect("#/all"), 2000);
    })
    .catch(err => {
      console.log(err);
      errorNotify("Something went wrong.");
    });
}

export function postBuy(ctx) {
  getSessionInfo(ctx);

  get("user", `${ctx.userId}`, "Kinvey")
    .then(data => {
      put("user", `${ctx.userId}`, { purchases: data.purchases + 1 }, "Kinvey")
        .then(() => {
          showNotification("success", "You successfully bought the product!");
          setTimeout(() => ctx.redirect("#/all"), 3000);
        })
        .catch(err => {
          console.log(err);
          errorNotify("Something went wrong.");
        });
    })
    .catch(err => {
      console.log(err);
      errorNotify("Something went wrong.");
    });
}
