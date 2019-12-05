import { getSessionInfo, partials } from "../common.js";
import { get } from "../requester.js";

export function getHome(ctx) {
  getSessionInfo(ctx);

  if(ctx.loggedIn){
    get("appdata", "events", "Kinvey")
    .then(data => {
      ctx.events = data;

      this.loadPartials(partials).partial("./templates/home/home.hbs");
    })
    .catch(console.error);
  } else {
    this.loadPartials(partials).partial("./templates/home/home.hbs");
  }
}
