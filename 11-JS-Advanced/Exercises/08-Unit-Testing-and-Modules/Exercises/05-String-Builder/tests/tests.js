const StringBuilder = require("../index.js");
const assert = require("chai").assert;
const expect = require("chai").expect;

describe("StringBuilder class", function() {
  it("Passing a string to StringBuilder constructor should create array", function() {
    let strBuilder = new StringBuilder("abc");
    let actual = strBuilder._stringArray;
    let expected = ["a", "b", "c"];
    actual.forEach((x, i) => {
      assert.equal(x, expected[i]);
    });
  });
  it("Passing undefined to StringBuilder constructor should create empty array", function() {
    let strBuilder = new StringBuilder(undefined);
    assert.equal(strBuilder._stringArray[0], undefined);
  });
  it("Passing a non-string to StringBuilder constructor should throw exception", function() {
    assert.throws(
      () => new StringBuilder(true),
      TypeError,
      "Argument must be string"
    );
  });
  it("Passing a string to append function should add to the end of the existing array", function() {
    let strBuilder = new StringBuilder("abc");
    strBuilder.append("def");
    let actual = strBuilder._stringArray;
    let expected = ["a", "b", "c", "d", "e", "f"];
    actual.forEach((x, i) => {
      assert.equal(x, expected[i]);
    });
  });
  it("Passing a non-string to append function should throw exception", function() {
    let strBuilder = new StringBuilder("abc");
    assert.throws(
      () => strBuilder.append(true),
      TypeError,
      "Argument must be string"
    );
  });
  it("Passing a string to prepend function should add to the beginning of the existing array", function() {
    let strBuilder = new StringBuilder("abc");
    strBuilder.prepend("def");
    let actual = strBuilder._stringArray;
    let expected = ["d", "e", "f", "a", "b", "c"];
    actual.forEach((x, i) => {
      assert.equal(x, expected[i]);
    });
  });
  it("Passing a non-string to prepend function should throw exception", function() {
    let strBuilder = new StringBuilder("abc");
    assert.throws(
      () => strBuilder.prepend(true),
      TypeError,
      "Argument must be string"
    );
  });
  it("Passing a string to insertAt function should add to the existing array at the specified index", function() {
    let strBuilder = new StringBuilder("abc");
    strBuilder.insertAt("def", 1);
    let actual = strBuilder._stringArray;
    let expected = ["a", "d", "e", "f", "b", "c"];
    actual.forEach((x, i) => {
      assert.equal(x, expected[i]);
    });
  });
  it("Passing a non-string to insertAt function should throw exception", function() {
    let strBuilder = new StringBuilder("abc");
    assert.throws(
      () => strBuilder.insertAt(true, 1),
      TypeError,
      "Argument must be string"
    );
  });
  // did not pass Judge test
  it("Remove function should remove stated number of elements from the existing array", function() {
    let strBuilder = new StringBuilder("abc");
    strBuilder.remove(1, 1);
    let actual = strBuilder._stringArray;
    let expected = ["a", "c"];
    actual.forEach((x, i) => {
      assert.equal(x, expected[i]);
    });
  });
  // passed Judge test
  it("Remove function should remove stated number of elements from the existing array", function() {
    let actual = new StringBuilder("abc");
    actual.remove(0, 1);
    assert.equal(actual._stringArray[0], "b");
  });
  it("ToString function should return correct result", function() {
    let strBuilder = new StringBuilder("abc");
    let actual = strBuilder.toString();
    let expected = "abc";
    assert.equal(actual, expected);
  });
  it("Passing a non-string to _vrfyParam function should throw exception", function() {
    expect(() => StringBuilder._vrfyParam(true)).to.throw(TypeError, "Argument must be string");
  });
});
