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
  getDetails,
  getEdit,
  postEdit,
  processDelete,
  processLike
} from "./controllers/trekController.js";

const app = Sammy("body", function() {
  this.use("Handlebars", "hbs");

  this.get("#/", getHome);

  this.get("#/home", getHome);

  this.get("#/register", getRegister);
  this.post("#/register", postRegister);

  this.get("#/login", getLogin);
  this.post("#/login", postLogin);

  this.get("#/logout", postLogout);

  this.get("#/create", getCreate);
  this.post("#/create", postCreate);

  this.get("#/details/:id", getDetails);

  this.get("#/edit/:id", getEdit);
  this.post("#/edit/:id", postEdit);

  this.get("#/delete/:id", processDelete);

  this.get("#/like/:id", processLike);

  this.get("#/profile", getProfile);
});

app.run("#/");
