import { getSessionInfo, partials } from "../common.js";
import { post } from "../requester.js";

export function getRegister(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/user/register.hbs");
}

export function postRegister(ctx) {
  const { username, password, rePassword } = ctx.params;

  if (password === rePassword) {
    post("user", "", { username, password }, "Basic")
      .then(() => {
        ctx.redirect("#/login");
      })
      .catch(console.error);
  } else {
    alert("Password and Re-Password do not match.");
  }
}

export function getLogin(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/user/login.hbs");
}

export function postLogin(ctx) {
  const { username, password } = ctx.params;

  post("user", "login", { username, password }, "Basic")
    .then(data => {
      sessionStorage.setItem("userId", data._id);
      sessionStorage.setItem("authtoken", data._kmd.authtoken);
      sessionStorage.setItem("username", data.username);

      ctx.redirect("#/");
    })
    .catch(console.error);
}

export function postLogout(ctx) {
  post("user", "_logout", {}, "Kinvey")
    .then(() => {
      sessionStorage.clear();
      ctx.redirect("#/");
    })
    .catch(console.error);
}
