const AutoService = require("../index.js");
const assert = require("chai").assert;

describe("AutoService class", function() {
  describe("constructor tests", function() {
    it("should successfully create an instance", function() {
      let actual = new AutoService(10);
      let expected = {
        garageCapacity: 10,
        workInProgress: [],
        backlogWork: []
      };
      assert.deepEqual(actual, expected);
    });
  });
  describe("availableSpace getter tests", function() {
    it("should return correct result", function() {
      let autoService = new AutoService(10);
      let actual = autoService.availableSpace;
      let expected = 10;
      assert.deepEqual(actual, expected);
    });
  });
  describe("signUpForReview() tests", function() {
    it("should work properly if threre is available space", function() {
      let autoService = new AutoService(10);
      autoService.signUpForReview("Peter", "CA1234CA", {
        engine: "MFRGG23",
        transmission: "FF4418ZZ",
        doors: "broken"
      });
      assert.equal(autoService.workInProgress.length, 1);
      assert.deepEqual(autoService.workInProgress[0], {
        plateNumber: "CA1234CA",
        clientName: "Peter",
        carInfo: {
          engine: "MFRGG23",
          transmission: "FF4418ZZ",
          doors: "broken"
        }
      });
    });
    it("should work properly if threre is no available space", function() {
      let autoService = new AutoService(1);
      autoService.signUpForReview("Peter", "CA1234CA", {
        engine: "MFRGG23",
        transmission: "FF4418ZZ",
        doors: "broken"
      });
      autoService.signUpForReview("Sam", "CA1234DE", {
        engine: "MFRGG24",
        transmission: "FF4418AA",
        doors: "broken"
      });
      assert.equal(autoService.availableSpace, 0);
      assert.equal(autoService.backlogWork.length, 1);
      assert.deepEqual(autoService.backlogWork[0], {
        plateNumber: "CA1234DE",
        clientName: "Sam",
        carInfo: {
          engine: "MFRGG24",
          transmission: "FF4418AA",
          doors: "broken"
        }
      });
    });
  });
  describe("carInfo() tests", function() {
    it("should return correct result if the car is in the workInProgress array", function() {
      let autoService = new AutoService(10);
      autoService.signUpForReview("Peter", "CA1234CA", {
        engine: "MFRGG23",
        transmission: "FF4418ZZ",
        doors: "broken"
      });
      let actual = autoService.carInfo("CA1234CA", "Peter");
      let expected = {
        plateNumber: "CA1234CA",
        clientName: "Peter",
        carInfo: {
          engine: "MFRGG23",
          transmission: "FF4418ZZ",
          doors: "broken"
        }
      };
      assert.deepEqual(actual, expected);
    });
    it("should return correct result if the car is in the backlogWork array", function() {
      let autoService = new AutoService(1);
      autoService.signUpForReview("Peter", "CA1234CA", {
        engine: "MFRGG23",
        transmission: "FF4418ZZ",
        doors: "broken"
      });
      autoService.signUpForReview("Sam", "CA1234DE", {
        engine: "MFRGG24",
        transmission: "FF4418AA",
        doors: "broken"
      });
      let actual = autoService.carInfo("CA1234DE", "Sam");
      let expected = {
        plateNumber: "CA1234DE",
        clientName: "Sam",
        carInfo: {
          engine: "MFRGG24",
          transmission: "FF4418AA",
          doors: "broken"
        }
      };
      assert.deepEqual(actual, expected);
    });
    it("should return correct result if there is no such car", function() {
      let autoService = new AutoService(10);
      autoService.signUpForReview("Peter", "CA1234CA", {
        engine: "MFRGG23",
        transmission: "FF4418ZZ",
        doors: "broken"
      });
      autoService.signUpForReview("Sam", "CA1234DE", {
        engine: "MFRGG24",
        transmission: "FF4418AA",
        doors: "broken"
      });
      let actual = autoService.carInfo("NON-EXISTING", "Non-Existing");
      let expected = "There is no car with platenumber NON-EXISTING and owner Non-Existing.";
      assert.equal(actual, expected);
    });
  });
  describe("repairCar() tests", function() {
    it("should return correct result if there are no cars in both workInProgress and backlogWork arrays", function() {
      let autoService = new AutoService(10);
      let actual = autoService.repairCar();
      let expected = "No clients, we are just chilling...";
      assert.equal(actual, expected);
    });
    it("should return correct result if there is a car with broken parts in workInProgress array", function() {
      let autoService = new AutoService(10);
      autoService.signUpForReview("Peter", "CA1234CA", {
        engine: "MFRGG23",
        transmission: "FF4418ZZ",
        doors: "broken"
      });
      let actual = autoService.repairCar();
      let expected = "Your doors were repaired.";
      assert.equal(actual, expected);
      assert.equal(autoService.availableSpace, 10);
      assert.equal(autoService.workInProgress.length, 0);
    });
    it("should return correct result if there is a car with broken parts in backlogWork array", function() {
      let autoService = new AutoService(1);
      autoService.signUpForReview("Peter", "CA1234CA", {
        engine: "MFRGG23",
        transmission: "FF4418ZZ",
        doors: "fine"
      });
      autoService.signUpForReview("Sam", "CA1234DE", {
        engine: "MFRGG24",
        transmission: "FF4418AA",
        doors: "broken"
      });
      autoService.repairCar()
      let actual = autoService.repairCar();
      let expected = "Your doors were repaired.";
      assert.equal(actual, expected);
      assert.equal(autoService.availableSpace, 1);
      assert.equal(autoService.workInProgress.length, 0);
      assert.equal(autoService.backlogWork.length, 0);
    });
    it("should return correct result if there is a car with no broken", function() {
      let autoService = new AutoService(10);
      autoService.signUpForReview("Peter", "CA1234CA", {
        engine: "MFRGG23",
        transmission: "FF4418ZZ",
        doors: "fine"
      });
      let actual = autoService.repairCar();
      let expected = "Your car was fine, nothing was repaired.";
      assert.equal(actual, expected);
      assert.equal(autoService.availableSpace, 10);
      assert.equal(autoService.workInProgress.length, 0);
    });
  });
});
