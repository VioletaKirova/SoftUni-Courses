import { getSessionInfo, partials } from "../common.js";
import { get } from "../requester.js";

export function getHome(ctx) {
  getSessionInfo(ctx);

  if (ctx.loggedIn) {
    get("appdata", "treks", "Kinvey")
      .then(data => {
        ctx.treks = data.sort((a, b) => b.likes - a.likes);

        this.loadPartials(partials).partial("./templates/home/home.hbs");
      })
      .catch(console.error);
  } else {
    this.loadPartials(partials).partial("./templates/home/home.hbs");
  }
}
