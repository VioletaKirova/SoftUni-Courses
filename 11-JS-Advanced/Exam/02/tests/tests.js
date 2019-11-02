const SkiResort = require("../index.js");
const assert = require("chai").assert;

describe("SkiResort tests", function() {
  describe("constructor tests", function() {
    it("should successfully create instance", function() {
      let skiResort = new SkiResort("ResortName");
      assert.equal(skiResort.name, "ResortName");
      assert.equal(skiResort.voters, 0);
      assert.equal(skiResort.hotels.length, 0);
      assert.deepEqual(skiResort.hotels, []);
    });
  });
  describe("getter bestHotel tests", function() {
    it("should return correct result if there are no voters", function() {
      let skiResort = new SkiResort("ResortName");
      let actual = skiResort.bestHotel;
      let expected = "No votes yet";
      assert.equal(actual,expected);
    });
    it("should return correct result if there are voters", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 3);
      skiResort.book("HotelName", 3);
      skiResort.leave("HotelName", 2, 2);
      let actual = skiResort.bestHotel;
      let expected = "Best hotel is HotelName with grade 4. Available beds: 2";
      assert.equal(actual, expected);
    });
  });
  describe("build() tests", function() {
    it("should successfully create a hotel if passed correct data", function() {
      let skiResort = new SkiResort("ResortName");
      let result = skiResort.build("NewHodel", 2);
      assert.equal(result, "Successfully built new hotel - NewHodel");
      assert.equal(skiResort.hotels.length, 1);
      assert.deepEqual(skiResort.hotels[0], {
        beds: 2,
        name: "NewHodel",
        points: 0
      });
    });
    it("should throw exception if empty string is passed", function() {
      let skiResort = new SkiResort("ResortName");
      assert.throws(() => skiResort.build("", 2), Error, "Invalid input");
    });
    it("should throw exception if less than 1 is passed", function() {
      let skiResort = new SkiResort("ResortName");
      assert.throws(() => skiResort.build("NewHotel", 0), Error, "Invalid input");
    });
  });
  describe("book() tests", function() {
    it("should successfully book the hotel if passed correct data", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 2);
      let result = skiResort.book("HotelName", 2);
      assert.equal(result, "Successfully booked");
      assert.equal(skiResort.hotels[0].beds, 0);
    });
    it("should throw exception if empty string is passed", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 2);
      assert.throws(() => skiResort.book("", 2), Error, "Invalid input");
    });
    it("should throw exception if less than 1 is passed", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 2);
      assert.throws(() => skiResort.book("HotelName", 0), Error, "Invalid input");
    });
    it("should throw exception if non-existing hotel name is passed", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 2);
      assert.throws(() => skiResort.book("Non-Existing HotelName", 2), Error, "There is no such hotel");
    });
    it("should throw exception if non-existing hotel name is passed", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 2);
      assert.throws(() => skiResort.book("Non-Existing", 2), Error, "There is no such hotel");
    });
    it("should throw exception if more beds passed", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 2);
      assert.throws(() => skiResort.book("HotelName", 3), Error, "There is no free space");
    });
  });
  describe("leave() tests", function() {
    it("should work properly if passed correct data", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 3);
      skiResort.book("HotelName", 3);
      let result = skiResort.leave("HotelName", 2, 2);
      assert.equal(result, "2 people left HotelName hotel");
      assert.equal(skiResort.hotels[0].points, 4);
      assert.equal(skiResort.hotels[0].beds, 2);
      assert.equal(skiResort.voters, 2);
    });
    it("should throw exception if empty string is passed", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 2);
      assert.throws(() => skiResort.leave("", 2), Error, "Invalid input");
    });
    it("should throw exception if less than 1 is passed", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 2);
      assert.throws(() => skiResort.leave("HotelName", 0), Error, "Invalid input");
    });
    it("should throw exception if non-existing hotel name is passed", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 2);
      assert.throws(() => skiResort.leave("Non-Existing", 2), Error, "There is no such hotel");
    });
  });
  describe("averageGrade() tests", function() {
    it("should return correct result if there are no voters", function() {
      let skiResort = new SkiResort("ResortName");
      let actual = skiResort.averageGrade();
      let expected = "No votes yet";
      assert.equal(actual,expected);
    });
    it("should return correct result if there are voters", function() {
      let skiResort = new SkiResort("ResortName");
      skiResort.build("HotelName", 3);
      skiResort.book("HotelName", 3);
      skiResort.leave("HotelName", 2, 2);
      let actual = skiResort.averageGrade();
      let expected = "Average grade: 2.00";
      assert.equal(actual, expected);
    });
  });
});
