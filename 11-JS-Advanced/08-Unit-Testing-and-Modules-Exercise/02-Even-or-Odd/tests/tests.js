const isOddOrEven = require("../index.js");
const assert = require("chai").assert;

describe("isOddOrEven function", function() {
  it("Passing number should return undefined", function() {
    assert.equal(isOddOrEven(1), undefined);
  });
  it("Passing even string should return even", function() {
    assert.equal(isOddOrEven("abcd"), "even");
  });
  it("Passing odd string should return odd", function() {
    assert.equal(isOddOrEven("abc"), "odd");
  });
});
