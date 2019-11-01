const BookStore = require("../index.js");
const assert = require("chai").assert;

describe("BookStore class", function() {
  it("Passing a string to the constructor should successfully instantiate the class", function() {
    let bookStore = new BookStore("a");
    assert.equal(bookStore.name, "a");
    assert.typeOf(bookStore.books, "array");
    assert.typeOf(bookStore.workers, "array");
    assert.equal(bookStore.books.length, 0);
    assert.equal(bookStore.workers.length, 0);
  });
  it("Passing a string array to stockBooks function should return correct result", function() {
    let bookStore = new BookStore("a");
    let actual = bookStore.books;
    let expected = {
      title: "a",
      author: "b"
    }
    assert.equal(bookStore.books.length, 1);
    assert.deepEqual(actual[0], expected);
  });
  it("Passing a non-existing name to hire function should return correct result", function() {
    let bookStore = new BookStore("a");
    let result = bookStore.hire("a", "b");
    let actual = bookStore.workers[0];
    assert.equal(result, "a started work at a as b");
    assert.equal(bookStore.workers.length, 1);
    assert.equal(actual.name, "a");
    assert.equal(actual.position, "b");
    assert.equal(actual.booksSold, 0);
  });
  it("Passing an existing name to hire function should throw exception", function() {
    let bookStore = new BookStore("a");
    bookStore.hire("a", "b");
    assert.throws(
      () => bookStore.hire("a", "b"),
      Error,
      "This person is our employee"
    );
  });
  it("Passing an existing name to fire function should return correct result", function() {
    let bookStore = new BookStore("a");
    bookStore.hire("a", "b");
    let result = bookStore.fire("a");
    assert.equal(result, "a is fired");
    assert.equal(bookStore.workers.length, 0);
  });
  it("Passing non-existing name to fire function should throw exception", function() {
    let bookStore = new BookStore("a");
    bookStore.hire("a", "b");
    bookStore.hire("c", "d");
    assert.throws(() => bookStore.fire("e"), Error, "e doesn't work here");
  });
  it("Passing an existing bookTitle and workerName to sellBook function should work properly", function() {
    let bookStore = new BookStore("a");
    bookStore.stockBooks(["a-b", "c-d"]);
    bookStore.hire("a", "b");
    bookStore.hire("c", "d");
    bookStore.sellBook("a", "c");
    assert.equal(bookStore.books.length, 1);
    assert.equal(bookStore.workers.filter(w => w.name === "c")[0].booksSold, 1);
  });
  it("Passing an non-existing bookTitle and existing workerName to sellBook function should throw exception", function() {
    let bookStore = new BookStore("a");
    bookStore.stockBooks(["a-b", "c-d"]);
    bookStore.hire("a", "b");
    bookStore.hire("c", "d");
    assert.throws(
      () => bookStore.sellBook("e", "c"),
      Error,
      "This book is out of stock"
    );
  });
  it("Passing an existing bookTitle and non-existing workerName to sellBook function should throw exception", function() {
    let bookStore = new BookStore("a");
    bookStore.stockBooks(["a-b", "c-d"]);
    bookStore.hire("a", "b");
    bookStore.hire("c", "d");
    assert.throws(
      () => bookStore.sellBook("a", "e"),
      Error,
      "e is not working here"
    );
  });
  it("PrintWorkers function should return correct result", function() {
    let bookStore = new BookStore("a");
    bookStore.stockBooks(["a-b", "c-d"]);
    bookStore.hire("a", "b");
    bookStore.hire("c", "d");
    bookStore.sellBook("a", "c");
    let actual = bookStore.printWorkers();
    let expected =
      "Name:a Position:b BooksSold:0\nName:c Position:d BooksSold:1";
    assert.equal(actual, expected);
  });
});
