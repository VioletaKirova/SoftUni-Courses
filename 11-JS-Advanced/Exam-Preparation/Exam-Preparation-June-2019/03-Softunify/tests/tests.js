const SoftUniFy = require("../index.js");
const assert = require("chai").assert;

describe("SoftUniFy class", function() {
  describe("constructor tests", function() {
    it("instance should contain allSongs property", function() {
      let softUniFy = new SoftUniFy();
      assert.deepEqual(softUniFy.allSongs, {});
    });
  });
  describe("downloadSong() tests", function() {
    it("should add songs correctly", function() {
      let softUniFy = new SoftUniFy();
      let result = softUniFy.downloadSong("Eminem", "Fall", "Fall Lyrics");
      assert.equal(softUniFy.allSongs["Eminem"].songs.length, 1);
      assert.deepEqual(softUniFy.allSongs["Eminem"], {
        rate: 0,
        votes: 0,
        songs: ["Fall - Fall Lyrics"]
      });
      assert.deepEqual(result, softUniFy);
    });
    it("should add songs correctly to an existing artist", function() {
      let softUniFy = new SoftUniFy();
      softUniFy.downloadSong("Eminem", "Fall", "Fall Lyrics");
      softUniFy.downloadSong("Eminem", "Killshot", "Killshot Lyrics");
      assert.equal(softUniFy.allSongs["Eminem"].songs.length, 2);
      assert.deepEqual(softUniFy.allSongs["Eminem"], {
        rate: 0,
        votes: 0,
        songs: ["Fall - Fall Lyrics", "Killshot - Killshot Lyrics"]
      });
    });
  });
  describe("playSong() tests", function() {
    it("should return correct result if existing song is passed", function() {
      let softUniFy = new SoftUniFy();
      softUniFy.downloadSong("Eminem", "Fall", "Fall Lyrics");
      let actual = softUniFy.playSong("Fall");
      let expected = "Eminem:\nFall - Fall Lyrics\n";
      assert.equal(actual, expected)
    });
    it("should return correct result if non-existing song is passed", function() {
      let softUniFy = new SoftUniFy();
      let actual = softUniFy.playSong("Non-Existing");
      let expected = "You have not downloaded a Non-Existing song yet. Use SoftUniFy's function downloadSong() to change that!";
      assert.equal(actual, expected)
    });
  });
  describe("songsList tests", function() {
    it("should return correct result if this.allSongs is not empty", function() {
      let softUniFy = new SoftUniFy();
      softUniFy.downloadSong("Eminem", "Fall", "Fall Lyrics");
      softUniFy.downloadSong("Eminem", "Killshot", "Killshot Lyrics");
      let actual = softUniFy.songsList;
      let expected = "Fall - Fall Lyrics\nKillshot - Killshot Lyrics";
      assert.equal(actual, expected)
    });
    it("should return correct result if this.allSongs is empty", function() {
      let softUniFy = new SoftUniFy();
      let actual = softUniFy.songsList;
      let expected = "Your song list is empty";
      assert.equal(actual, expected)
    });
  });
  describe("rateArtist() tests", function() {
    it("should return correct result if 2 args are passed", function() {
      let softUniFy = new SoftUniFy();
      softUniFy.downloadSong("Eminem", "Fall", "Fall Lyrics");
      let actual = softUniFy.rateArtist("Eminem", 5);
      let expected = 5;
      assert.equal(actual, expected)
    });
    it("should return correct result if 1 arg is passed", function() {
      let softUniFy = new SoftUniFy();
      softUniFy.downloadSong("Eminem", "Fall", "Fall Lyrics");
      let actual = softUniFy.rateArtist("Eminem");
      let expected = 0;
      assert.equal(actual, expected)
    });
    it("should return correct result if 1 arg (non-existing artist name) is passed", function() {
      let softUniFy = new SoftUniFy();
      let actual = softUniFy.rateArtist("Non-Existing");
      let expected = "The Non-Existing is not on your artist list.";
      assert.equal(actual, expected)
    });
  });
});
