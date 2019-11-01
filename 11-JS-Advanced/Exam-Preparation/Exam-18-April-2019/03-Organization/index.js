class Organization {
  constructor(name, budget) {
    this.name = name;
    this.employees = [];
    this.budget = budget;
    this._departmentsBudget = {
      marketing: this.budget * 0.4,
      finance: this.budget * 0.25,
      production: this.budget * 0.35
    };
  }

  get departmentsBudget() {
    return this._departmentsBudget;
  }

  add(employeeName, department, salary) {
    if (this.departmentsBudget[department] >= salary) {
      this.employees.push({
        employeeName,
        department,
        salary
      });

      this.departmentsBudget[department] -= salary;

      return `Welcome to the ${department} team Mr./Mrs. ${employeeName}.`;
    }

    return `The salary that ${department} department can offer to you Mr./Mrs. ${employeeName} is $${this.departmentsBudget[department]}.`;
  }

  employeeExists(employeeName) {
    let employee = this.employees.find(x => x.employeeName === employeeName);

    if (employee === undefined) {
      return `Mr./Mrs. ${employeeName} is not working in ${this.name}.`;
    }

    return `Mr./Mrs. ${employeeName} is part of the ${employee.department} department.`;
  }

  leaveOrganization(employeeName) {
    let employeeIndex = this.employees.findIndex(
      x => x.employeeName === employeeName
    );

    if (employeeIndex === -1) {
      return `Mr./Mrs. ${employeeName} is not working in ${this.name}.`;
    }

    let employee = this.employees[employeeIndex];
    this.departmentsBudget[employee.department] += employee.salary;
    this.employees.splice(employeeIndex, 1);

    return `It was pleasure for ${this.name} to work with Mr./Mrs. ${employeeName}.`;
  }

  status() {
    let result = `${this.name.toUpperCase()} DEPARTMENTS:`;

    result += `\nMarketing | ${this.getDepartmentInfo("marketing")}`;
    result += `\nFinance | ${this.getDepartmentInfo("finance")}`;
    result += `\nProduction | ${this.getDepartmentInfo("production")}`;

    return result;
  }

  getSortedEmployees(departmentName) {
    return this.employees
      .filter(x => x.department === departmentName)
      .sort((a, b) => b.salary - a.salary)
      .map(x => x.employeeName);
  }

  getDepartmentInfo(departmentName) {
    let employees = this.getSortedEmployees(departmentName);
    return `Employees: ${employees.length}: ${employees.join(
      ", "
    )} | Remaining Budget: ${this.departmentsBudget[departmentName]}`;
  }
}
