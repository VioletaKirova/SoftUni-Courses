import { getHome } from "./controllers/homeController.js";
import {
  getLogin,
  getRegister,
  postRegister,
  postLogin,
  postLogout
} from "./controllers/userController.js";
import {
  getDetails,
  getCreate,
  postCreate,
  getEdit,
  postEdit,
  processDelete,
  processLike
} from "./controllers/recipeController.js";

const app = Sammy("#rooter", function() {
  this.use("Handlebars", "hbs");

  this.get("#/", getHome);
  this.get("#/home", getHome);

  this.get("#/login", getLogin);
  this.post("#/login", postLogin);

  this.get("#/register", getRegister);
  this.post("#/register", postRegister);

  this.get("#/logout", postLogout);

  this.get("#/details/:id", getDetails);

  this.get("#/create", getCreate);
  this.post("#/create", postCreate);

  this.get("#/edit/:id", getEdit);
  this.post("#/edit/:id", postEdit);

  this.get("#/archive/:id", processDelete);

  this.get("#/like/:id", processLike);
});

app.run("#/");
