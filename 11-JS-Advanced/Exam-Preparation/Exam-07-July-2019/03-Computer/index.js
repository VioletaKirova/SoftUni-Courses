class Computer {
  constructor(ramMemory, cpuGHz, hddMemory) {
    this.ramMemory = ramMemory;
    this.cpuGHz = cpuGHz;
    this.hddMemory = hddMemory;
    this.taskManager = [];
    this.installedPrograms = [];
  }

  installAProgram(name, requiredSpace) {
    if (this.hddMemory < requiredSpace) {
      throw new Error("There is not enough space on the hard drive");
    }

    let program = {
      name,
      requiredSpace
    };

    this.installedPrograms.push(program);
    this.hddMemory -= requiredSpace;

    return program;
  }

  uninstallAProgram(name) {
    let program = this.installedPrograms.filter(x => x.name === name)[0];
    let indexOfProgram = this.installedPrograms.indexOf(program);

    if (indexOfProgram === -1) {
      throw new Error("Control panel is not responding");
    }

    this.hddMemory += program.requiredSpace;
    this.installedPrograms.splice(indexOfProgram, 1);

    return this.installedPrograms;
  }

  openAProgram(name) {
    let program = this.installedPrograms.filter(x => x.name === name)[0];
    let indexOfProgram = this.installedPrograms.indexOf(program);

    if (indexOfProgram === -1) {
      throw new Error(`The ${name} is not recognized`);
    }

    if (this.taskManager.filter(x => x.name === name).length > 0) {
      throw new Error(`The ${name} is already open`);
    }

    let neededRam = (program.requiredSpace / this.ramMemory) * 1.5;
    let neededCpu = (program.requiredSpace / this.cpuGHz / 500) * 1.5;

    let totalRam = 100;
    this.taskManager.forEach(x => {
      totalRam -= x.ramUsage;
    });

    let totalCpu = 100;
    this.taskManager.forEach(x => {
      totalCpu -= x.cpuUsage;
    });

    if (totalRam - neededRam <= 0) {
      throw new Error(`${name} caused out of memory exception`);
    }

    if (totalCpu - neededCpu <= 0) {
      throw new Error(`${name} caused out of cpu exception`);
    }

    let openedProgram = {
      name,
      ramUsage: neededRam,
      cpuUsage: neededCpu
    };

    this.taskManager.push(openedProgram);

    return openedProgram;
  }

  taskManagerView() {
    if (this.taskManager.length === 0) {
      return "All running smooth so far";
    }

    let result = [];

    this.taskManager.forEach(x => {
      result.push(
        `Name - ${x.name} | Usage - CPU: ${x.cpuUsage.toFixed(0)}%, RAM: ${x.ramUsage.toFixed(0)}%`
      );
    });

    return result.join("\n");
  }
}

let computer = new Computer(4096, 7.5, 250000);

computer.installAProgram('Word', 7300);
computer.installAProgram('Excel', 10240);
computer.installAProgram('PowerPoint', 12288);
computer.installAProgram('Solitare', 1500);

computer.openAProgram('Word');
computer.openAProgram('Excel');
computer.openAProgram('PowerPoint');
computer.openAProgram('Solitare');

console.log(computer.taskManagerView());

