class Company {
  constructor() {
    this.departments = [];
  }

  addEmployee(username, salary, position, department) {
    let employeeValidations = [
      username !== "" && username !== undefined && username !== null,
      salary !== "" && salary !== undefined && salary !== null,
      position !== "" && position !== undefined && position !== null,
      department !== "" && department !== undefined && department !== null,
      Number(salary) > 0
    ];

    if (employeeValidations.indexOf(false) !== -1) {
      throw new Error("Invalid input!");
    }

    let currentDepartment = this.departments.find(x => x.name === department);

    if (currentDepartment === undefined) {
      currentDepartment = {
        name: department,
        employees: [],
        avgSalary: function() {
          return (
            this.employees.reduce((acc, curr) => acc + curr.salary, 0) /
            this.employees.length
          );
        }
      };

      this.departments.push(currentDepartment);
    }

    currentDepartment.employees.push({
      username,
      salary,
      position
    });

    return `New employee is hired. Name: ${username}. Position: ${position}`;
  }

  bestDepartment() {
    let department = [...this.departments].sort(
      (a, b) => b.avgSalary() - a.avgSalary()
    )[0];

    let employees = [...department.employees]
      .sort(
        (a, b) => b.salary - a.salary || a.username.localeCompare(b.username)
      )
      .map(x => `${x.username} ${x.salary} ${x.position}`)
      .join("\n");

    return `Best Department is: ${
      department.name
    }\nAverage salary: ${department.avgSalary().toFixed(2)}\n${employees}`;
  }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
