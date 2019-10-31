class List {
  constructor() {
    this.list = [];
    this.size = 0;
  }

  sort() {
    return this.list.sort((a, b) => a - b);
  }

  add(element) {
    this.list.push(element);
    this.size = this.list.length;
    this.sort();
  }

  remove(index) {
    if (this.list[index] === "undefined") {
      throw new Error("Index is out of range!");
    }

    this.list = this.list.filter(x => x !== this.list[index]);
    this.size = this.list.length;
  }

  get(index) {
    if (this.list[index] === "undefined") {
      throw new Error("Index is out of range!");
    }

    return this.list[index];
  }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);
