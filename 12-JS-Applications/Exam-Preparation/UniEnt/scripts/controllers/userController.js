import {
  getSessionInfo,
  partials,
  showNotification,
  errorNotify
} from "../common.js";
import { post, get } from "../requester.js";

function loginUser(ctx, username, password, isNewUser) {
  post("user", "login", { username, password }, "Basic")
    .then(data => {
      sessionStorage.setItem("userId", data._id);
      sessionStorage.setItem("authtoken", data._kmd.authtoken);
      sessionStorage.setItem("username", data.username);

      if (isNewUser) {
        showNotification("successBox", "You registered successfully!");
      } else {
        showNotification("successBox", "You logged in successfully!");
      }

      setTimeout(() => ctx.redirect("#/"), 3000);
    })
    .catch(err => {
      const message = JSON.parse(err.message);

      if (message.status == 401) {
        errorNotify("Username or password is incorrect!");
      } else {
        console.log(err);
        errorNotify();
      }
    });
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
        loginUser(ctx, username, password, true);
      })
      .catch(err => {
        const message = JSON.parse(err.message);

        if (message.status == 409) {
          errorNotify("The username is already taken!");
        } else {
          console.log(err);
          errorNotify();
        }
      });
  } else {
    errorNotify("Password and Re-Password do not match!");
  }
}

export function getLogin(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/user/login.hbs");
}

export function postLogin(ctx) {
  const { username, password } = ctx.params;

  loginUser(ctx, username, password, false);
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
