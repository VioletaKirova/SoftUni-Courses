const isSymmetric = require("../index.js");
const assert = require("chai").assert;

describe("isSymmetric() tests", function() {
  it("should return correct result if passed a symmetric array", function() {
    let actual = isSymmetric([1, 2, 1]);
    let expected = true;
    assert.equal(actual, expected);
  });
  it("should return correct result if passed a symmetric array", function() {
    let actual = isSymmetric(["a", "b", "a"]);
    let expected = true;
    assert.equal(actual, expected);
  });
  it("should return correct result if passed a symmetric array with length === 1", function() {
    let actual = isSymmetric([1]);
    let expected = true;
    assert.equal(actual, expected);
  });
  it("should return correct result if passed a symmetric array with length === 0", function() {
    let actual = isSymmetric([]);
    let expected = true;
    assert.equal(actual, expected);
  });
  it("should return correct result if passed a non-symmetric array", function() {
    let actual = isSymmetric([1, 2, 3]);
    let expected = false;
    assert.equal(actual, expected);
  });
  it("should return correct result if passed a non-array", function() {
    let actual = isSymmetric(1);
    let expected = false;
    assert.equal(actual, expected);
  });
  it("should return correct result if passed a non-array", function() {
    let actual = isSymmetric("a");
    let expected = false;
    assert.equal(actual, expected);
  });
});
