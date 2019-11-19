const lookupChar = require("../index.js");
const assert = require("chai").assert;

describe("lookupChar function", function() {
  it("Passing (integer, integer) should return undefined", function() {
    assert.equal(lookupChar(1, 1), undefined);
  });
  it("Passing (string, string) should return undefined", function() {
    assert.equal(lookupChar("a", "a"), undefined);
  });
  it("Passing (string, decimal) should return undefined", function() {
    assert.equal(lookupChar("a", 1.1), undefined);
  });
  it("Passing (string, negative index) should return 'Incorrect index'", function() {
    assert.equal(lookupChar("a", -1), "Incorrect index");
  });
  it("Passing (string, index larger than string length) should return 'Incorrect index'", function() {
    assert.equal(lookupChar("a", 2), "Incorrect index");
  });
  it("Passing (string, index in bounds) should return correct element", function() {
    assert.equal(lookupChar("abcd", 1), "b");
  });
});
