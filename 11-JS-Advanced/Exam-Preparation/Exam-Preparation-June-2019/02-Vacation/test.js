class Vacation {
  constructor(organizer, destination, budget) {
    this.organizer = organizer;
    this.destination = destination;
    this.budget = budget;
    this.kids = {};
  }

  registerChild(kidName, kidGrade, kidBudget) {
    let kid = `${kidName}-${kidBudget}`;
    if (kidBudget >= this.budget) {
      if (!this.kids.hasOwnProperty(kidGrade)) {
        this.kids[kidGrade] = [];
      }
      let isThere = this.kids[kidGrade].find(k => k.startsWith(kidName));
      if (!isThere) {
        this.kids[kidGrade].push(kid);
        return this.kids[kidGrade];
      } else {
        return `${kidName} is already in the list for this ${this.destination} vacation.`;
      }
    } else {
      return `${kidName}'s money is not enough to go on vacation to ${this.destination}.`;
    }
  }

  removeChild(kidName, kidGrade) {
    if (this.kids.hasOwnProperty(kidGrade)) {
      let index = this.kids[kidGrade].findIndex(k => k.startsWith(kidName));
      if (index >= 0) {
        this.kids[kidGrade].splice(index, 1);
        return this.kids[kidGrade];
      }
    }
    return `We couldn't find ${kidName} in ${kidGrade} grade.`;
  }

  toString() {
    if (this.numberOfChildren === 0) {
      return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
    }
    let grades = Object.keys(this.kids).sort((a, b) => a - b);
    let output = `${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}\n`;
    for (const grade of grades) {
      if (this.kids[grade].length > 0) {
        output += `Grade: ${grade}\n`;
        let counter = 1;
        for (let kid of this.kids[grade]) {
          let [name, budget] = kid.split("-");
          output += `${counter++}. ${name}-${budget}\n`;
        }
      }
    }
    return output;
  }

  get numberOfChildren() {
    let counter = 0;
    for (let grade in this.kids) {
      counter += this.kids[grade].length;
    }
    return counter;
  }
}
