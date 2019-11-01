class Vacation {
  constructor(organizer, destination, budget) {
    this.organizer = organizer;
    this.destination = destination;
    this.budget = budget;
    this.kids = {};
  }

  registerChild(name, grade, budget) {
    if (Number(budget) < this.budget) {
      return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
    }

    if (this.kids[grade] === undefined) {
      this.kids[grade] = [];
    }

    if (this.kids[grade].find(x => x.startsWith(name)) === undefined) {
      this.kids[grade].push(`${name}-${budget}`);
      return this.kids[grade];
    }

    return `${name} is already in the list for this ${this.destination} vacation.`;
  }

  removeChild(name, grade) {
    if (this.kids[grade] !== undefined) {
      let kidIndex = this.kids[grade].findIndex(x => x.startsWith(name));

      if (kidIndex !== -1) {
        this.kids[grade].splice(kidIndex, 1);

        return this.kids[grade];
      }
    }

    return `We couldn't find ${name} in ${grade} grade.`;
  }

  toString() {
    if (this.numberOfChildren === 0) {
      return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
    }
    
    let result = `${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}\n`;

    let sortedGrades = Object.keys(this.kids).sort((a, b) => a - b);

    for (const grade of sortedGrades) {
      if (this.kids[grade].length > 0) {
        result += `Grade: ${grade}\n`;
        let counter = 1;
        for (let kid of this.kids[grade]) {
          let [name, budget] = kid.split("-");
          result += `${counter++}. ${name}-${budget}\n`;
        }
      }
    }
    return result;
  }

  get numberOfChildren(){
    return Object.values(this.kids).reduce((acc, curr) => {
      acc += curr.length;
      return acc;
    }, 0);
  }
}

let vacation = new Vacation("Miss Elizabeth", "Dubai", 2000);
vacation.registerChild("Gosho", 5, 3000);
vacation.registerChild("Lilly", 6, 1500);
vacation.registerChild("Pesho", 7, 4000);
vacation.registerChild("Tanya", 5, 5000);
vacation.registerChild("Mitko", 10, 5500);
console.log(vacation.toString());
