import { getHome } from "./controllers/homeController.js";
import {
  getRegister,
  postRegister,
  getLogin,
  postLogin,
  postLogout,
  getProfile
} from "./controllers/userController.js";
import {
  getCreate,
  postCreate,
  getAll,
  getEdit,
  postEdit,
  getDetails,
  getDelete,
  postDelete,
  postBuy
} from "./controllers/offerController.js";

const app = Sammy("body", function() {
  this.use("Handlebars", "hbs");

  this.get("#/", getHome);

  this.get("#/home", getHome);

  this.get("#/register", getRegister);
  this.post("#/register", postRegister);

  this.get("#/login", getLogin);
  this.post("#/login", postLogin);

  this.get("#/logout", postLogout);

  this.get("#/profile", getProfile);

  this.get("#/create", getCreate);
  this.post("#/create", postCreate);

  this.get("#/all", getAll);

  this.get("#/details/:id", getDetails);

  this.get("#/edit/:id", getEdit);
  this.post("#/edit/:id", postEdit);

  this.get("#/delete/:id", getDelete);
  this.post("#/delete/:id", postDelete);

  this.get("#/buy", postBuy);
});

app.run("#/");
