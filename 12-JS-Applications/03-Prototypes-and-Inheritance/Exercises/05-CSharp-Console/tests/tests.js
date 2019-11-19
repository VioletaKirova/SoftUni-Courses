const Console = require("../index.js");
const assert = require("chai").assert;

describe("Console Tests", function() {
  describe("writeLine() tests", function() {
    it("should return correct result if a single string is passed", function() {
      let actual = Console.writeLine("a");
      let expected = "a";
      assert.equal(actual, expected);
    });
    it("should return correct result if a single object is passed", function() {
      let obj = { a: 1 };
      let actual = Console.writeLine(obj);
      let expected = JSON.stringify(obj);
      assert.equal(actual, expected);
    });
    it("should throw exception if multiple arguments are passed and the first one is not a string", function() {
      assert.throws(
        () => Console.writeLine(true, 1),
        TypeError,
        "No string format given!"
      );
    });
    it("should throw exception if the number of parameters does not match the number of placeholders", function() {
      assert.throws(
        () => Console.writeLine("Test {0} {1}", 1),
        RangeError,
        "Incorrect amount of parameters given!"
      );
    });
    it("should throw exception if a placeholder index does not match the given parameters", function() {
      assert.throws(
        () => Console.writeLine("Test {0} {1} {3}", 1, 2, 3),
        RangeError,
        "Incorrect placeholders given!"
      );
    });
    it("should throw exception if a placeholder index does not match the given parameters", function() {
      assert.throws(
        () => Console.writeLine("Test {10}", 1),
        RangeError,
        "Incorrect placeholders given!"
      );
    });
    it("should return correct result if passed correct data", function() {
      let actual = Console.writeLine("Test {0} {1}", 1, 2);
      let expected = "Test 1 2";
      assert.equal(actual, expected);
    });
  });
});
