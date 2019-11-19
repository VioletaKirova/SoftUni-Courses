function solve() {
  class Base {
    constructor(manufacturer) {
      if (new.target === Base) {
        throw Error("Cannot instantiate directly.");
      }

      this.manufacturer = manufacturer;
    }
  }

  class Keyboard extends Base {
    constructor(manufacturer, responseTime) {
      super(manufacturer);
      this.responseTime = responseTime;
    }
  }

  class Monitor extends Base {
    constructor(manufacturer, width, height) {
      super(manufacturer);
      this.width = width;
      this.height = height;
    }
  }

  class Battery extends Base {
    constructor(manufacturer, expectedLife) {
      super(manufacturer);
      this.expectedLife = expectedLife;
    }
  }

  class Computer extends Base {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
      super(manufacturer);
      if (new.target === Computer) {
        throw Error("Cannot instantiate directly.");
      }

      this.processorSpeed = processorSpeed;
      this.ram = ram;
      this.hardDiskSpace = hardDiskSpace;
    }
  }

  class Laptop extends Computer {
    _battery;

    constructor(
      manufacturer,
      processorSpeed,
      ram,
      hardDiskSpace,
      weight,
      color,
      battery
    ) {
      super(manufacturer, processorSpeed, ram, hardDiskSpace);
      this.weight = weight;
      this.color = color;
      this.battery = battery;
    }

    get battery() {
      return this._battery;
    }

    set battery(value) {
      if (value instanceof Battery === false) {
        throw new TypeError("Invalid battery input.");
      }

      this._battery = value;
    }
  }

  class Desktop extends Computer {
    _keyboard;
    _monitor;

    constructor(
      manufacturer,
      processorSpeed,
      ram,
      hardDiskSpace,
      keyboard,
      monitor
    ) {
      super(manufacturer, processorSpeed, ram, hardDiskSpace);
      this.keyboard = keyboard;
      this.monitor = monitor;
    }

    get keyboard() {
      return this._keyboard;
    }

    set keyboard(value) {
      if (value instanceof Keyboard === false) {
        throw new TypeError("Invalid keyboard input.");
      }

      this._keyboard = value;
    }

    get monitor() {
      return this._monitor;
    }

    set monitor(value) {
      if (value instanceof Monitor === false) {
        throw new TypeError("Invalid monitor input.");
      }

      this._monitor = value;
    }
  }

  return {
    Base,
    Keyboard,
    Monitor,
    Battery,
    Computer,
    Laptop,
    Desktop
  };
}
