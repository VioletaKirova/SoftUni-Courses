const createCalculator = require("../index.js");
const assert = require("chai").assert;

describe("createCalculator() tests", function() {
  it("should return object with correct properties", function() {
    let actual = createCalculator();
    assert.typeOf(actual.add, "function");
    assert.typeOf(actual.subtract, "function");
    assert.typeOf(actual.get, "function");
  });
  it("should return correct result if a number is passed to .add()", function() {
    let actual = createCalculator();
    actual.add(1);
    assert.equal(actual.get(), 1);
  });
  it("should return correct result if a string containing a number is passed to .add()", function() {
    let actual = createCalculator();
    actual.add("1");
    assert.equal(actual.get(), 1);
  });
  it("should return correct result if a number is passed to .subtract()", function() {
    let actual = createCalculator();
    actual.subtract(1);
    assert.equal(actual.get(), -1);
  });
  it("should return correct result if a string containing a number is passed to .subtract()", function() {
    let actual = createCalculator();
    actual.subtract("1");
    assert.equal(actual.get(), -1);
  });
});
