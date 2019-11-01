const mathEnforcer = require("../index.js");
const assert = require("chai").assert;

describe("mathEnforcer object", function() {
  it("Passing a non-number to addFive function should return undefined", function() {
    assert.equal(mathEnforcer.addFive("abc"), undefined);
    assert.equal(mathEnforcer.addFive(false), undefined);
    assert.equal(mathEnforcer.addFive({ key: "value" }), undefined);
  });
  it("Passing a number to addFive function should return correct value", function() {
    assert.equal(mathEnforcer.addFive(1), 6);
    assert.equal(mathEnforcer.addFive(-1), 4);
    assert.equal(mathEnforcer.addFive(1.1), 6.1);
    assert.equal(mathEnforcer.addFive(-1.1), 3.9);
  });
  it("Passing a non-number to subtractTen function should return undefined", function() {
    assert.equal(mathEnforcer.subtractTen("abc"), undefined);
    assert.equal(mathEnforcer.subtractTen(false), undefined);
    assert.equal(mathEnforcer.subtractTen({ key: "value" }), undefined);
  });
  it("Passing a number to addFive function should return correct result", function() {
    assert.equal(mathEnforcer.subtractTen(1), -9);
    assert.equal(mathEnforcer.subtractTen(-1), -11);
    assert.equal(mathEnforcer.subtractTen(1.1), -8.9);
    assert.equal(mathEnforcer.subtractTen(-1.1), -11.1);
  });
  it("Passing a non-number (as first param) to sum function should return undefined", function() {
    assert.equal(mathEnforcer.sum("abc", 1), undefined);
    assert.equal(mathEnforcer.sum(false, 1), undefined);
    assert.equal(mathEnforcer.sum({ key: "value" }, 1), undefined);
  });
  it("Passing a non-number (as second param) to sum function should return undefined", function() {
    assert.equal(mathEnforcer.sum(1, "abc"), undefined);
    assert.equal(mathEnforcer.sum(1, false), undefined);
    assert.equal(mathEnforcer.sum(1, { key: "value" }), undefined);
  });
  it("Passing a non-number (as first and second param) to sum function should return undefined", function() {
    assert.equal(mathEnforcer.sum(true, "abc"), undefined);
    assert.equal(mathEnforcer.sum({ key: "value" }, false), undefined);
    assert.equal(mathEnforcer.sum("abc", { key: "value" }), undefined);
  });
  it("Passing numbers to sum function should return correct result", function() {
    assert.equal(mathEnforcer.sum(1, 2), 3);
    assert.equal(mathEnforcer.sum(1, -2), -1);
    assert.equal(mathEnforcer.sum(-1, -2), -3);
    assert.equal(mathEnforcer.sum(1.1, 2.1), 3.2);
    assert.equal(mathEnforcer.sum(1.1, -2.1), -1);
    assert.equal(mathEnforcer.sum(-1.1, -2.1), -3.2);
  });
});
