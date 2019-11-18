const rgbToHexColor = require("../index.js");
const assert = require("chai").assert;

describe("rgbToHexColor() tests", function() {
  it("should return correct result if passed correct data", function() {
    let actual = rgbToHexColor(0, 0, 0);
    let expected = "#000000";
    assert.equal(actual, expected);
  });
  it("should return correct result if passed correct data", function() {
    let actual = rgbToHexColor(255, 255, 255);
    let expected = "#FFFFFF";
    assert.equal(actual, expected);
  });
  it("should return undefined if passed incorrect data", function() {
    let expected = undefined;
    assert.equal(rgbToHexColor("a", 0, 0), expected);
    assert.equal(rgbToHexColor(0, "a", 0), expected);
    assert.equal(rgbToHexColor(0, 0, "a"), expected);
    assert.equal(rgbToHexColor(-1, 0, 0), expected);
    assert.equal(rgbToHexColor(0, -1, 0), expected);
    assert.equal(rgbToHexColor(0, 0, -1), expected);
    assert.equal(rgbToHexColor(256, 0, 0), expected);
    assert.equal(rgbToHexColor(0, 256, 0), expected);
    assert.equal(rgbToHexColor(0, 0, 256), expected);
  });
});
