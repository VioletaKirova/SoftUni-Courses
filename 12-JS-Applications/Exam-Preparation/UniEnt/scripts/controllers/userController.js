import { getSessionInfo, partials } from "../common.js";
import { post, get } from "../requester.js";

function loginUser(ctx, username, password) {
  post("user", "login", { username, password }, "Basic")
    .then(data => {
      sessionStorage.setItem("userId", data._id);
      sessionStorage.setItem("authtoken", data._kmd.authtoken);
      sessionStorage.setItem("username", data.username);

      ctx.redirect("#/");
    })
    .catch(console.error);
}

export function getRegister(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/user/register.hbs");
}

export function postRegister(ctx) {
  const { username, password, rePassword } = ctx.params;

  if (password === rePassword) {
    post("user", "", { username, password }, "Basic")
      .then(() => {
        loginUser(ctx, username, password);
      })
      .catch(console.error);
  } else {
    alert("Password and Repeat Password do not match.");
  }
}

export function getLogin(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/user/login.hbs");
}

export function postLogin(ctx) {
  const { username, password } = ctx.params;

  loginUser(ctx, username, password);
}

export function postLogout(ctx) {
  post("user", "_logout", {}, "Kinvey")
    .then(() => {
      sessionStorage.clear();
      ctx.redirect("#/");
    })
    .catch(console.error);
}

export function getProfile(ctx) {
  getSessionInfo(ctx);

  get("appdata", "events", "Kinvey")
    .then(data => {
      ctx.events = data.filter(e => e._acl.creator == ctx.userId);
      ctx.eventsCount = ctx.events.length;

      this.loadPartials(partials).partial("./templates/user/profile.hbs");
    })
    .catch(console.error);
}
