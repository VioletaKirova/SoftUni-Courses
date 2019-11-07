function solve() {
  class Person {
    constructor(name, email) {
      this.name = name;
      this.email = email;
    }

    baseInfo() {
      return `name: ${this.name}, email: ${this.email}`;
    }

    toString() {
      return `Person (${this.baseInfo()})`;
    }
  }

  class Teacher extends Person {
    constructor(name, email, subject) {
      super(name, email);
      this.subject = subject;
    }

    toString() {
      return `Teacher (${this.baseInfo()}, subject: ${this.subject})`;
    }
  }

  class Student extends Person {
    constructor(name, email, course) {
      super(name, email);
      this.course = course;
    }

    toString() {
      return `Student (${this.baseInfo()}, course: ${this.course})`;
    }
  }

  return {
    Person,
    Teacher,
    Student
  };
}
