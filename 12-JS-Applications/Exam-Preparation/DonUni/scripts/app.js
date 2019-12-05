import { getHome } from "./controllers/homeController.js";
import {
  getRegister,
  postRegister,
  getLogin,
  postLogin,
  postLogout
} from "./controllers/userController.js";
import {
  getCreate,
  postCreate,
  getAll,
  getDetails,
  postDonate,
  processDelete
} from "./controllers/causeController.js";

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

  this.get("#/all", getAll);

  this.get("#/details/:id", getDetails);

  this.post("#/donate/:id", postDonate);

  this.get("#/delete/:id", processDelete);
});

app.run("#/");
