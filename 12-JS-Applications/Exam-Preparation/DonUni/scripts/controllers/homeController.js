import { getSessionInfo, partials } from "../common.js";

export function getHome(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/home/home.hbs");
}
