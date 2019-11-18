// Score: 90/100

const Warehouse = require("../index.js");
const assert = require("chai").assert;

describe("Warehouse instance", function() {
  it("Passing a number (> 0) to the constructor should successfully set the capacity", function() {
    let warehouse = new Warehouse(1);
    assert.equal(warehouse.capacity, 1);
  });
  it("Passing a floating-point number (> 0) to the constructor should successfully set the capacity", function() {
    let warehouse = new Warehouse(1.1);
    assert.equal(warehouse.capacity, 1.1);
  });
  it("Passing a non-number to the constructor should throw exception", function() {
    assert.throws(() => new Warehouse("a"), "Invalid given warehouse space");
  });
  it("Passing negative number to the constructor should throw exception", function() {
    assert.throws(() => new Warehouse(-1), "Invalid given warehouse space");
  });
  it("Passing 0 to the constructor should throw exception", function() {
    assert.throws(() => new Warehouse(0), "Invalid given warehouse space");
  });

  // addProduct() tests

  it("AddProduct function with correct data should return correct result", function() {
    let warehouse = new Warehouse(1);
    let actual = warehouse.addProduct("Food", "apple", 1);
    let expected = { apple: 1 };
    assert.equal(JSON.stringify(actual), JSON.stringify(expected));
  });
  it("AddProduct function with incorrect data should throw exception", function() {
    let warehouse = new Warehouse(1);
    assert.throws(
      () => warehouse.addProduct("Food", "apple", 2),
      "There is not enough space or the warehouse is already full"
    );
  });

  // orderProducts() tests

  it("OrderProducts function with correct data should return correct result", function() {
    let warehouse = new Warehouse(3);
    warehouse.addProduct("Food", "apple", 1);
    warehouse.addProduct("Food", "orange", 2);
    let actual = warehouse.orderProducts("Food");
    let expected = { orange: 2, apple: 1 };
    assert.equal(JSON.stringify(actual), JSON.stringify(expected));
  });
  it("OrderProducts function with correct data and 0 available products should return correct result", function() {
    let warehouse = new Warehouse(1);
    let actual = warehouse.orderProducts("Food");
    let expected = {};
    assert.equal(JSON.stringify(actual), JSON.stringify(expected));
  });

  // occupiedCapacity() tests

  it("OccupiedCapacity function with available products should return correct result", function() {
    let warehouse = new Warehouse(3);
    warehouse.addProduct("Food", "apple", 1);
    warehouse.addProduct("Food", "orange", 1);
    let actual = warehouse.occupiedCapacity();
    let expected = 2;
    assert.equal(actual, expected);
  });
  it("OccupiedCapacity function with no available products should return correct result", function() {
    let warehouse = new Warehouse(1);
    let actual = warehouse.occupiedCapacity();
    let expected = 0;
    assert.equal(actual, expected);
  });

  // revision() tests

  it("Revision function with available products should return correct result", function() {
    let warehouse = new Warehouse(10);
    warehouse.addProduct("Food", "apple", 1);
    warehouse.addProduct("Food", "orange", 2);
    warehouse.addProduct("Drink", "juice", 1);
    warehouse.addProduct("Drink", "coffee", 2);
    let actual = warehouse.revision();
    let expected =
      "Product type - [Food]\n- apple 1\n- orange 2\nProduct type - [Drink]\n- juice 1\n- coffee 2";
    assert.equal(actual, expected);
  });
  it("Revision function with no available products should return correct result", function() {
    let warehouse = new Warehouse(1);
    let actual = warehouse.revision();
    let expected = "The warehouse is empty";
    assert.equal(actual, expected);
  });

  // scrapeAProduct() tests

  it("ScrapeAProduct function with existent product and quantity should return correct result", function() {
    let warehouse = new Warehouse(10);
    warehouse.addProduct("Food", "apple", 10);
    let actual = warehouse.scrapeAProduct("apple", 1);
    let expected = { apple: 9 };
    assert.equal(JSON.stringify(actual), JSON.stringify(expected));
  });
  it("ScrapeAProduct function with existent product and not enough quantity should reduce quantity to 0", function() {
    let warehouse = new Warehouse(1);
    warehouse.addProduct("Food", "apple", 1);
    warehouse.scrapeAProduct("apple", 2);
    let actual = warehouse.availableProducts["Food"]["apple"];
    let expected = 0;
    assert.equal(actual, expected);
  });
  it("ScrapeAProduct function with non-existent product and quantity should return correct result", function() {
    let warehouse = new Warehouse(1);
    assert.throws(
      () => warehouse.scrapeAProduct("apple", 1),
      "apple do not exists"
    );
  });
});
