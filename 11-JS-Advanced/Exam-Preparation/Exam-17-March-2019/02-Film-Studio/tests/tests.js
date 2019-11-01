const FilmStudio = require("../index.js");
const assert = require("chai").assert;

describe("FilmStudio tests", function() {
  describe("constructor tests", function() {
    it("should successfully create an instance with passed string", function() {
      let actual = new FilmStudio("abc");
      let expected = { name: "abc", films: [] };
      assert.deepEqual(actual, expected);
    });
  });
  describe("makeMovie() tests", function() {
    it("should return correct result with passed string and array", function() {
      let filmStudio = new FilmStudio("abc");
      let actual = filmStudio.makeMovie("Film", ["First Role", "Second Role"]);
      let expected = {
        filmName: "Film",
        filmRoles: [
          {
            actor: false,
            role: "First Role"
          },
          {
            actor: false,
            role: "Second Role"
          }
        ]
      };
      assert.deepEqual(actual, expected);
      assert.equal(filmStudio.films.length, 1);
    });
    it("should return correct result with passed string and array and existing film with the same name", function() {
      let filmStudio = new FilmStudio("abc");
      filmStudio.makeMovie("Film", ["First Role", "Second Role"]);
      let actual = filmStudio.makeMovie("Film", ["First Role", "Second Role"]);
      let expected = {
        filmName: "Film 2",
        filmRoles: [
          {
            actor: false,
            role: "First Role"
          },
          {
            actor: false,
            role: "Second Role"
          }
        ]
      };
      assert.deepEqual(actual, expected);
      assert.equal(filmStudio.films.length, 2);
    });
    it("should throw exception if less arguments are passed", function() {
      let filmStudio = new FilmStudio("abc");
      assert.throws(
        () => filmStudio.makeMovie("Film"),
        "Invalid arguments count"
      );
    });
    it("should throw exception if arguments are with wrong type", function() {
      let filmStudio = new FilmStudio("abc");
      assert.throws(
        () => filmStudio.makeMovie(true, true),
        "Invalid arguments"
      );
    });
  });
  describe("casting() tests", function() {
    it("should return correct result with passed exiting role", function() {
      let filmStudio = new FilmStudio("abc");
      filmStudio.makeMovie("Film", ["First Role", "Second Role"]);
      let actual = filmStudio.casting("Actor", "First Role");
      let expected =
        "You got the job! Mr. Actor you are next First Role in the Film. Congratz!";
      assert.equal(actual, expected);
      assert.deepEqual(filmStudio.films[0].filmRoles[0].actor, "Actor");
    });
    it("should return correct result with passed non-exiting role", function() {
      let filmStudio = new FilmStudio("abc");
      filmStudio.makeMovie("Film", ["First Role", "Second Role"]);
      let actual = filmStudio.casting("Actor", "Non-Exiting Role");
      let expected = "Actor, we cannot find a Non-Exiting Role role...";
      assert.equal(actual, expected);
    });
    it("should return correct result if there are no films", function() {
      let filmStudio = new FilmStudio("abc");
      let actual = filmStudio.casting("Actor", "First Role");
      let expected = "There are no films yet in abc.";
      assert.equal(actual, expected);
    });
  });
  describe("lookForProducer() tests", function() {
    it("should return correct result if existing film is passed", function() {
      let filmStudio = new FilmStudio("abc");
      filmStudio.makeMovie("Film", ["First Role", "Second Role"]);
      let actual = filmStudio.lookForProducer("Film");
      let expected = "Film name: Film\nCast:\nfalse as First Role\nfalse as Second Role\n";
      assert.equal(actual, expected);
    });
    it("should throw exception if non-existing film is passed", function() {
      let filmStudio = new FilmStudio("abc");
      filmStudio.makeMovie("Film", ["First Role", "Second Role"]);
      assert.throws(() => filmStudio.lookForProducer("Non-Existing Film"), Error, "Non-Existing Film do not exist yet, but we need the money...")
    });
  });
});
