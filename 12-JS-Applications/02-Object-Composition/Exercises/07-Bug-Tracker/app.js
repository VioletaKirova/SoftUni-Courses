function solve() {
  const sortMap = {
    author: (a, b) => a.author.localeCompare(b.author),
    severity: (a, b) => a.severity - b.severity,
    ID: (a, b) => a.ID - b.ID
  };

  return {
    bugReports: [],
    id: 0,
    selector: undefined,
    report: function(author, description, reproducible, severity) {
      this.bugReports.push({
        ID: this.id,
        author: author,
        description: description,
        reproducible: reproducible,
        severity: severity,
        status: "Open"
      });

      this.id++;
      this.print();
    },
    setStatus: function(id, newStatus) {
      let report = this.bugReports.find(x => x.ID === id);

      if (report === undefined) {
        throw new Error(`There is no bug report with ID:${id}.`);
      }

      report.status = newStatus;
      this.print();
    },
    remove: function(id) {
      let reportIndex = this.bugReports.findIndex(x => x.ID === id);

      if (reportIndex === -1) {
        throw new Error(`There is no bug report with ID:${id}.`);
      }

      this.bugReports.splice(reportIndex, 1);
      this.print();
    },
    sort: function(method) {
      this.bugReports.sort((a, b) => sortMap[method](a, b));
      this.print();
    },
    output: function(selector) {
      this.selector = selector;
      this.print();
    },
    print: function() {
      let resultElement = document.querySelector(this.selector);
      resultElement.innerHTML = "";

      this.bugReports.forEach(x => {
        let parentDiv = document.createElement("div");
        parentDiv.id = `report_${x.ID}`;
        parentDiv.classList.add("report");

        let childDiv1 = document.createElement("div");
        childDiv1.classList.add("body");

        let p = document.createElement("p");
        p.textContent = x.description;

        let childDiv2 = document.createElement("div");
        childDiv2.classList.add("title");

        let span1 = document.createElement("span");
        span1.classList.add("author");
        span1.textContent = `Submitted by: ${x.author}`;

        let span2 = document.createElement("span");
        span2.classList.add("status");
        span2.textContent = `${x.status} | ${x.severity}`;

        childDiv1.appendChild(p);

        childDiv2.appendChild(span1);
        childDiv2.appendChild(span2);

        parentDiv.appendChild(childDiv1);
        parentDiv.appendChild(childDiv2);

        resultElement.appendChild(parentDiv);
      });
    }
  };
}
