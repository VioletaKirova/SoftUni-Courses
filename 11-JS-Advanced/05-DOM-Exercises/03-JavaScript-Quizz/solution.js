function solve() {
  const rightAnswersMap = ["onclick", "JSON.stringify()", "A programming API for HTML and XML documents"];
  let rightAnswersCount = 0;
  let activeSectionState = 0;

  let sections = document.getElementsByTagName("section");
  let activeSection = sections[activeSectionState];

  function checkAnswer(answer){
    if(rightAnswersMap.includes(answer.currentTarget.firstElementChild.firstElementChild.innerHTML)){
      rightAnswersCount++;
    }

    activeSection.style.display = "none";
    activeSectionState++;

    if(activeSectionState === 3){
      let result = document.getElementsByClassName("results-inner")[0].firstElementChild;

      result.innerHTML = rightAnswersCount === 3 ? 
      "You are recognized as top JavaScript fan!" :
      `You have ${rightAnswersCount} right answers`;

      document.getElementById("results").style.display = "block";
      return;
    }

    activeSection = sections[activeSectionState];
    activeSection.style.display = "block";
  }

  [...document.querySelectorAll(".quiz-answer")]
    .forEach(x => x.addEventListener("click", checkAnswer));
}
