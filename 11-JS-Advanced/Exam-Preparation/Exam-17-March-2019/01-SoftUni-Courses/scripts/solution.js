function solve() {
  let hasBonus = false;

  function signCourses() {
    const pickedCourses = checkBoxes.filter(x => x.checked === true);
    const pickedCoursesValues = pickedCourses.map(x => x.value);

    const educationForm = radioButtons.filter(x => x.checked === true)[0].value;

    let totalPrice = 0;

    if (
      pickedCoursesValues.indexOf(fundamentals) !== -1 &&
      pickedCoursesValues.indexOf(advanced) !== -1
    ) {
      totalPrice += coursesMap[fundamentals] + coursesMap[advanced] * 0.9;

      if (pickedCoursesValues.indexOf(applications) !== -1) {
        totalPrice += coursesMap[applications];
        totalPrice -= totalPrice * 0.06;
      }

      if (pickedCoursesValues.indexOf(web) !== -1) {
        totalPrice += coursesMap[web];
        hasBonus = true;
      }
    } else {
      pickedCoursesValues.forEach(x => {
        totalPrice += coursesMap[x];
      });
    }

    if (educationForm === "online") {
      totalPrice -= totalPrice * 0.06;
    }

    const ul = document.querySelector("#myCourses > div.courseBody > ul");
    const p = document.querySelector("#myCourses > div.courseFoot > p");

    let courseNames = pickedCourses.map(
      x => coursesNamesMap[x.nextElementSibling.innerHTML.split(" - ")[0]]
    );
    hasBonus ? courseNames.push(bonusCourse) : courseNames;

    courseNames.forEach(x => {
      let li = document.createElement("li");
      li.innerHTML = x;

      ul.appendChild(li);
    });

    p.innerHTML = `Cost: ${Math.trunc(totalPrice).toFixed(2)} BGN`;
  }

  const fundamentals = "js-fundamentals";
  const advanced = "js-advanced";
  const applications = "js-applications";
  const web = "js-web";
  const bonusCourse = "HTML and CSS";

  const coursesMap = {
    "js-fundamentals": 170,
    "js-advanced": 180,
    "js-applications": 190,
    "js-web": 490
  };

  const coursesNamesMap = {
    "JS Fundamentals": "JS-Fundamentals",
    "JS Advanced": "JS-Advanced",
    "JS Applications": "JS-Applications",
    "JS Web": "JS-Web"
  };

  const checkBoxes = Array.from(
    document.querySelectorAll("input[type=checkbox]")
  );
  const radioButtons = Array.from(
    document.querySelectorAll("input[type=radio]")
  );
  const actionButton = document.querySelector("button");

  actionButton.addEventListener("click", signCourses);
}

solve();
