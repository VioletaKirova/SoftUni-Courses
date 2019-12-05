import { getSessionInfo, partials, categoryImagesMap } from "../common.js";
import { get, post, put, del } from "../requester.js";

export function getDetails(ctx) {
  getSessionInfo(ctx);

  get("appdata", `recipes/${ctx.params.id}`, "Kinvey")
    .then(data => {
      ctx.isCreator = data._acl.creator === ctx.userId;
      ctx.recipe = data;

      this.loadPartials(partials).partial("./templates/recipe/details.hbs");
    })
    .catch(console.error);
}

export function getCreate(ctx) {
  getSessionInfo(ctx);

  this.loadPartials(partials).partial("./templates/recipe/create.hbs");
}

export function postCreate(ctx) {
  getSessionInfo(ctx);

  const data = {
    meal: ctx.params.meal,
    ingredients: ctx.params.ingredients.split(","),
    prepMethod: ctx.params.prepMethod,
    description: ctx.params.description,
    category: ctx.params.category,
    foodImageURL: ctx.params.foodImageURL,
    categoryImageURL: categoryImagesMap[ctx.params.category],
    likesCounter: 0
  };

  post("appdata", "recipes", data, "Kinvey")
    .then(() => {
      ctx.redirect("#/");
    })
    .catch(console.error);
}

export function getEdit(ctx) {
  getSessionInfo(ctx);

  get("appdata", `recipes/${ctx.params.id}`, "Kinvey").then(data => {
    ctx.recipe = data;

    this.loadPartials(partials).partial("./templates/recipe/edit.hbs");
  });
}

export function postEdit(ctx) {
  getSessionInfo(ctx);

  const data = {
    meal: ctx.params.meal,
    ingredients: ctx.params.ingredients.split(","),
    prepMethod: ctx.params.prepMethod,
    description: ctx.params.description,
    category: ctx.params.category,
    foodImageURL: ctx.params.foodImageURL,
    categoryImageURL: categoryImagesMap[ctx.params.category],
    likesCounter: ctx.params.likesCounter
  };

  put("appdata", `recipes/${ctx.params._id}`, data, "Kinvey")
    .then(() => {
      ctx.redirect(`#/details/${ctx.params._id}`);
    })
    .catch(console.error);
}

export function processDelete(ctx) {
  del("appdata", `recipes/${ctx.params.id}`, "Kinvey")
    .then(() => {
      ctx.redirect("#/");
    })
    .catch(console.error);
}

export function processLike(ctx) {
  const recipeId = ctx.params.id;

  get("appdata", `recipes/${recipeId}`, "Kinvey")
    .then(data => {
      data.likesCounter++;

      put("appdata", `recipes/${recipeId}`, data, "Kinvey")
        .then(() => {
          ctx.redirect(`#/details/${recipeId}`);
        })
        .catch(console.error);
    })
    .catch(console.error);
}
