const PizzUni = require("../index.js");
const assert = require("chai").assert;

describe("PizzUni class", function() {
  it("Constructor with no parameters should successfully create an instance", function() {
    let pizzUni = new PizzUni();
    assert.equal(pizzUni.registeredUsers.length, 0);
    assert.equal(pizzUni.orders.length, 0);
    assert.isTrue(pizzUni.availableProducts.hasOwnProperty("pizzas"));
    assert.isTrue(pizzUni.availableProducts.hasOwnProperty("drinks"));
    assert.equal(pizzUni.availableProducts.pizzas.length, 3);
    assert.equal(pizzUni.availableProducts.drinks.length, 3);
    let expectedPizzas = [
      "Italian Style",
      "Barbeque Classic",
      "Classic Margherita"
    ];
    pizzUni.availableProducts.pizzas.forEach((x, i) => {
      assert.equal(x, expectedPizzas[i]);
    });
    let expectedDrinks = ["Coca-Cola", "Fanta", "Water"];
    pizzUni.availableProducts.drinks.forEach((x, i) => {
      assert.equal(x, expectedDrinks[i]);
    });
  });
  it("Passing a non-existing email to registerUser function should return correct result", function() {
    let pizzUni = new PizzUni();
    let result = pizzUni.registerUser("a@a.a");
    assert.typeOf(result, "object");
    assert.equal(result.email, "a@a.a");
    assert.typeOf(result.orderHistory, "array");
    assert.equal(result.orderHistory.length, 0);
    assert.equal(pizzUni.registeredUsers.length, 1);
    assert.equal(result, pizzUni.registeredUsers[0]);
  });
  it("Passing an existing email to registerUser function should throw exception", function() {
    let pizzUni = new PizzUni();
    pizzUni.registerUser("a@a.a");
    assert.throws(
      () => pizzUni.registerUser("a@a.a"),
      Error,
      "This email address (a@a.a) is already being used!"
    );
  });
  it("Passing a non-existing email to makeAnOrder function should throw exception", function() {
    let pizzUni = new PizzUni();
    assert.throws(
      () => pizzUni.makeAnOrder("a@a.a", "Italian Style", "Coca-Cola"),
      Error,
      "You must be registered to make orders!"
    );
  });
  it("Passing an existing email and non-existing pizza to makeAnOrder function should throw exception", function() {
    let pizzUni = new PizzUni();
    pizzUni.registerUser("a@a.a");
    assert.throws(
      () => pizzUni.makeAnOrder("a@a.a", "Non-Existent", "Coca-Cola"),
      Error,
      "You must order at least 1 Pizza to finish the order."
    );
  });
  it("Passing an existing email, pizza and drink to makeAnOrder function should return correct result", function() {
    let pizzUni = new PizzUni();
    let user = pizzUni.registerUser("a@a.a");
    let result = pizzUni.makeAnOrder("a@a.a", "Italian Style", "Coca-Cola");
    assert.equal(result, 0);
    assert.equal(user.orderHistory.length, 1);
    assert.equal(user.orderHistory[0].orderedPizza, "Italian Style");
    assert.equal(user.orderHistory[0].orderedDrink, "Coca-Cola");
    assert.equal(
      pizzUni.orders[0].orderedPizza,
      user.orderHistory[0].orderedPizza
    );
    assert.equal(
      pizzUni.orders[0].orderedDrink,
      user.orderHistory[0].orderedDrink
    );
    assert.equal(pizzUni.orders[0].email, "a@a.a");
    assert.equal(pizzUni.orders[0].status, "pending");
  });
  it("Passing an existing email and pizza and non-existing drink to makeAnOrder function should return correct result", function() {
    let pizzUni = new PizzUni();
    let user = pizzUni.registerUser("a@a.a");
    let result = pizzUni.makeAnOrder("a@a.a", "Italian Style", "Non-Existent");
    assert.equal(result, 0);
    assert.equal(user.orderHistory[0].orderedPizza, "Italian Style");
    assert.isFalse(user.orderHistory[0].hasOwnProperty("orderedDrink"));
    assert.equal(
      pizzUni.orders[0].orderedPizza,
      user.orderHistory[0].orderedPizza
    );
    assert.equal(pizzUni.orders[0].email, "a@a.a");
    assert.equal(pizzUni.orders[0].status, "pending");
  });
  it("CompleteOrder function with this.orders.length > 0 should return correct result", function() {
    let pizzUni = new PizzUni();
    pizzUni.registerUser("a@a.a");
    pizzUni.makeAnOrder("a@a.a", "Italian Style", "Coca-Cola");
    let result = pizzUni.completeOrder();
    assert.equal(result.status, "completed");
    assert.equal(result, pizzUni.orders[0]);
  });
  it("Passing an existing index to detailsAboutMyOrder function should return correct result", function() {
    let pizzUni = new PizzUni();
    pizzUni.registerUser("a@a.a");
    pizzUni.makeAnOrder("a@a.a", "Italian Style", "Coca-Cola");
    let actual = pizzUni.detailsAboutMyOrder(0);
    let expected = "Status of your order: pending";
    assert.equal(actual, expected);
  });
  it("Passing a non-existing index toDetailsAboutMyOrder function should return correct result", function() {
    let pizzUni = new PizzUni();
    pizzUni.registerUser("a@a.a");
    pizzUni.makeAnOrder("a@a.a", "Italian Style", "Coca-Cola");
    let result = pizzUni.detailsAboutMyOrder(1);
    assert.equal(result, undefined);
  });
  it("Passing an existing email to DoesTheUserExist function returns correct result", function() {
    let pizzUni = new PizzUni();
    pizzUni.registerUser("a@a.a");
    let actual = pizzUni.doesTheUserExist("a@a.a");
    let expected = pizzUni.registeredUsers[0];
    assert.equal(actual, expected);
  });
  it("Passing a non-existing email to DoesTheUserExist function returns correct result", function() {
    let pizzUni = new PizzUni();
    pizzUni.registerUser("a@a.a");
    let result = pizzUni.doesTheUserExist("b@b.b");
    assert.equal(result, undefined);
  });
});
