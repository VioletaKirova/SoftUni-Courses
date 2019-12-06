import {
  getSessionInfo,
  partials,
  showNotification,
  errorNotify
} from "../common.js";
import { post, get } from "../requester.js";

export function getRegister(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/user/register.hbs");
}

export function postRegister(ctx) {
  const { username, password, rePassword } = ctx.params;

  if (username && password && rePassword) {
    if (password === rePassword) {
      post("user", "", { username, password, purchases: 0 }, "Basic")
        .then(() => {
          showNotification("success", "You registered successfully!");
          setTimeout(() => ctx.redirect("#/login"), 2000);
        })
        .catch(console.error);
    } else {
      errorNotify("Password and Repeat Password do not match.");
    }
  } else {
    errorNotify("Please fill in all fields.");
  }
}

export function getLogin(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/user/login.hbs");
}

export function postLogin(ctx) {
  const { username, password } = ctx.params;

  if (username && password) {
    post("user", "login", { username, password }, "Basic")
      .then(data => {
        sessionStorage.setItem("userId", data._id);
        sessionStorage.setItem("authtoken", data._kmd.authtoken);
        sessionStorage.setItem("username", data.username);

        showNotification("success", "You logged in successfully!");
        setTimeout(() => ctx.redirect("#/"), 2000);
      })
      .catch(err => {
        console.log(err);
        const message = JSON.parse(err.message);

        if (message.status == 401) {
          errorNotify("Username or password is incorrect.");
        } else {
          errorNotify("Something went wrong.");
        }
      });
  } else {
    errorNotify("Please fill in all fields.");
  }
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

  get("user", `${ctx.userId}`, "Kinvey")
    .then(data => {
      ctx.purchases = data.purchases;
      this.loadPartials(partials).partial("./templates/user/profile.hbs");
    })
    .catch(console.error);
}
