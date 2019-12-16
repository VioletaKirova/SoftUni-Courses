import {
  getSessionInfo,
  partials,
  errorNotify,
  showNotification
} from "../common.js";
import { post, get } from "../requester.js";

export function getRegister(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/user/register.hbs");
}

export function postRegister(ctx) {
  const { username, password, rePassword } = ctx.params;

  if (
    username &&
    password &&
    rePassword &&
    username.length >= 3 &&
    password.length >= 6
  ) {
    if (password === rePassword) {
      post("user", "", { username, password }, "Basic")
        .then(() => {
          showNotification("success", "Successfully registered user!");
          setTimeout(() => ctx.redirect("#/login"), 2000);
        })
        .catch(console.error);
    } else {
      errorNotify("Password and Re-Password do not match.");
    }
  } else {
    errorNotify(
      "Username must be at least 3 characters long.\nPassword must be at least 6 characters long."
    );
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

        showNotification("success", "Successfully logged user!");
        setTimeout(() => ctx.redirect("#/"), 2000);
      })
      .catch(err => {
        console.log(err);
        const message = JSON.parse(err.message);

        if (message.status == 401) {
          errorNotify("Invalid username or password.");
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

      showNotification("success", "Logout successful!");
      setTimeout(() => ctx.redirect("#/"), 2000);
    })
    .catch(err => {
      console.log(err);

      errorNotify("Something went wrong.");
    });
}

export function getProfile(ctx) {
  getSessionInfo(ctx);

  get("appdata", "treks", "Kinvey")
    .then(data => {
      ctx.treks = data.filter(x => x._acl.creator == ctx.userId);
      ctx.treksCount = ctx.treks.length;

      this.loadPartials(partials).partial("./templates/user/profile.hbs");
    })
    .catch(console.error);
}
