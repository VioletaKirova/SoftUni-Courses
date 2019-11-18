const PaymentPackage = require("../index.js");
const assert = require("chai").assert;

describe("PaymentPackage class", function() {
  it("Passing (string, number) to the constructor should successfully create an instance", function() {
    let paymentPackage = new PaymentPackage("abc", 1);
    assert.equal(paymentPackage.name, "abc");
    assert.equal(paymentPackage.value, 1);
    assert.equal(paymentPackage.VAT, 20);
    assert.equal(paymentPackage.active, true);
  });
  it("Passing (string, floating-point number) to the constructor should successfully create an instance", function() {
    let paymentPackage = new PaymentPackage("abc", 1.1);
    assert.equal(paymentPackage.name, "abc");
    assert.equal(paymentPackage.value, 1.1);
    assert.equal(paymentPackage.VAT, 20);
    assert.equal(paymentPackage.active, true);
  });
  it("Passing (string, 0) to the constructor should successfully create an instance", function() {
    let paymentPackage = new PaymentPackage("abc", 0);
    assert.equal(paymentPackage.name, "abc");
    assert.equal(paymentPackage.value, 0);
    assert.equal(paymentPackage.VAT, 20);
    assert.equal(paymentPackage.active, true);
  });
  it("Passing incorrect data to the constructor should throw exception", function() {
    assert.throws(
      () => new PaymentPackage(1, 1),
      Error,
      "Name must be a non-empty string"
    );
    assert.throws(
      () => new PaymentPackage("", 1),
      Error,
      "Name must be a non-empty string"
    );
    assert.throws(
      () => new PaymentPackage("abc", "abc"),
      Error,
      "Value must be a non-negative number"
    );
    assert.throws(
      () => new PaymentPackage("abc", -1),
      Error,
      "Value must be a non-negative number"
    );
  });
  it("Passing a number as VAT value should successfully set the value", function() {
    let paymentPackage = new PaymentPackage("abc", 1);
    paymentPackage.VAT = 1;
    assert.equal(paymentPackage.VAT, 1);
  });
  it("Passing worng data as VAT value should throw exception", function() {
    let paymentPackage = new PaymentPackage("abc", 1);
    assert.throws(
      () => (paymentPackage.VAT = "abc"),
      Error,
      "VAT must be a non-negative number"
    );
    assert.throws(
      () => (paymentPackage.VAT = -1),
      Error,
      "VAT must be a non-negative number"
    );
  });
  it("Passing a boolean as active value should successfully set the value", function() {
    let paymentPackage = new PaymentPackage("abc", 1);
    paymentPackage.active = false;
    assert.equal(paymentPackage.active, false);
  });
  it("Passing wrong data as active value should throw exception", function() {
    let paymentPackage = new PaymentPackage("abc", 1);
    assert.throws(
      () => (paymentPackage.active = "abc"),
      Error,
      "Active status must be a boolean"
    );
  });
  it("ToString function should return correct result", function() {
    let paymentPackage = new PaymentPackage("abc", 1);
    let actual = paymentPackage.toString();
    let expected =
      "Package: abc\n- Value (excl. VAT): 1\n- Value (VAT 20%): 1.2";
    assert.equal(actual, expected);
  });
  it("ToString function with changed VAT and active properties should return correct result", function() {
    let paymentPackage = new PaymentPackage("abc", 1);
    paymentPackage.VAT = 30;
    paymentPackage.active = false;
    let actual = paymentPackage.toString();
    let expected =
      "Package: abc (inactive)\n- Value (excl. VAT): 1\n- Value (VAT 30%): 1.3";
    assert.equal(actual, expected);
  });
});
