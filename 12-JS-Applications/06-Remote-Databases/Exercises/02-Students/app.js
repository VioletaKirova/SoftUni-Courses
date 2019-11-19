import { get, post } from "./requester.js";

function createElement(tag, content) {
  const element = document.createElement(tag);

  if (content) {
    element.textContent = content;
  }

  return element;
}

function isInputValid(firstName, lastName, facultyNumber, grade) {
  return (
    firstName !== null &&
    lastName !== null &&
    facultyNumber !== null &&
    grade !== null &&
    firstName.value !== "" &&
    lastName.value !== "" &&
    facultyNumber.value !== "" &&
    grade.value !== "" &&
    typeof Number(grade.value) === "number"
  );
}

const actions = {
  "load-students": async function() {
    let students;

    try {
      students = await get("appdata", "students");
    } catch (err) {
      console.log(err.message);
    }

    html.allStudents().innerHTML = "";

    students
      .sort((a, b) => a._id.localeCompare(b._id))
      .forEach((s, i) => {
        const wrapperTr = createElement("tr");

        const id = createElement("td", i + 1);
        const firstNameTd = createElement("td", s.firstName);
        const lastNameTd = createElement("td", s.lastName);
        const facultyNumberTd = createElement("td", s.facultyNumber);
        const gradeTd = createElement("td", s.grade);

        wrapperTr.append(id, firstNameTd, lastNameTd, facultyNumberTd, gradeTd);
        html.allStudents().appendChild(wrapperTr);
      });
  },
  "add-student": async function() {
    html.message().textContent = "";

    const firstName = html.firstName();
    const lastName = html.lastName();
    const facultyNumber = html.facultyNumber();
    const grade = html.grade();

    if (isInputValid(firstName, lastName, facultyNumber, grade)) {
      const data = {
        firstName: firstName.value,
        lastName: lastName.value,
        facultyNumber: facultyNumber.value,
        grade: grade.value
      };

      try {
        await post("appdata", "students", data);
      } catch (err) {
        console.log(err.message);
      }

      firstName.value = "";
      lastName.value = "";
      facultyNumber.value = "";
      grade.value = "";

      this["load-students"]();
    } else {
      html.message().textContent = "Please fill in all fields!";
    }
  }
};

const html = {
  firstName: () => document.getElementById("firstName"),
  lastName: () => document.getElementById("lastName"),
  facultyNumber: () => document.getElementById("facultyNumber"),
  grade: () => document.getElementById("grade"),
  allStudents: () => document.getElementById("allStudents"),
  message: () => document.getElementById("message")
};

function handleEvent(evt) {
  evt.preventDefault();
  
  if (actions[evt.target.id] !== undefined) {
    actions[evt.target.id]();
  }
}

document.addEventListener("click", handleEvent);
