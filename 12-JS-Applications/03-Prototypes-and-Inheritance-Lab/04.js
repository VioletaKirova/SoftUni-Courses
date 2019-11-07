function solve() {
  class Figure {
    unitsMap = {
      m: 0.01,
      cm: 1,
      mm: 10
    };

    constructor(unit = "cm") {
      this.unit = unit;
    }

    changeUnits(unit) {
      this.unit = unit;
    }

    changeValue(x) {
      return x * this.unitsMap[this.unit];
    }

    get area() {
      return NaN;
    }

    toString() {
      return `Figures units: ${this.unit} Area: ${this.area}`;
    }
  }

  class Circle extends Figure {
    constructor(radius, unit) {
      super(unit);
      this.radius = radius;
    }

    get area() {
      return Math.PI * Math.pow(this.changeValue(this.radius), 2);
    }

    toString() {
      return `${super.toString()} - radius: ${this.changeValue(this.radius)}`;
    }
  }

  class Rectangle extends Figure {
    constructor(width, height, unit) {
      super(unit);
      this.width = width;
      this.height = height;
    }

    get area() {
      return this.changeValue(this.width) * this.changeValue(this.height);
    }

    toString() {
      return `${super.toString()} - width: ${this.changeValue(
        this.width
      )}, height: ${this.changeValue(this.height)}`;
    }
  }

  return {
    Figure,
    Circle,
    Rectangle
  };
}
