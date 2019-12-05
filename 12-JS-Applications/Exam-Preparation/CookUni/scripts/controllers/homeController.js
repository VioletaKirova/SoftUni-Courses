import { getSessionInfo, partials } from "../common.js";
import { get } from "../requester.js";

export function getHome(ctx) {
  getSessionInfo(ctx);

  partials.all = "./templates/recipe/all.hbs";

  if (ctx.loggedIn) {
    get("appdata", "recipes", "Kinvey")
      .then(data => {
        ctx.recipes = data;

        this.loadPartials(partials).partial("./templates/home/home.hbs");
      })
      .catch(console.error);
  } else {
    this.loadPartials(partials).partial("./templates/home/home.hbs");
  }
}
