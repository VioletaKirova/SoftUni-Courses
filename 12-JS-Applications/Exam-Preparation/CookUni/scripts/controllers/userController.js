import { getSessionInfo, partials } from "../common.js";
import { post } from "../requester.js";

export function getRegister(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/user/register.hbs");
}

export function postRegister(ctx) {
  const {
    firstName,
    lastName,
    username,
    password,
    repeatPassword
  } = ctx.params;

  if (password === repeatPassword) {
    post("user", "", { username, password, firstName, lastName }, "Basic")
      .then(data => {
        ctx.redirect("#/login");
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

  post("user", "login", { username, password }, "Basic")
    .then(data => {
      sessionStorage.setItem("userId", data._id);
      sessionStorage.setItem("authtoken", data._kmd.authtoken);
      sessionStorage.setItem("username", data.username);
      sessionStorage.setItem("fullName", `${data.firstName} ${data.lastName}`);

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
