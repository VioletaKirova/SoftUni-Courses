function mySolution() {
  function reply(evt) {
    let replySection = evt.currentTarget.parentNode;
    let replyInput = replySection.firstElementChild.value;
    let replyOl = replySection.lastElementChild;

    if (replyInput !== "") {
      let li = document.createElement("li");
      li.innerHTML = replyInput;
      replyOl.appendChild(li);

      replySection.firstElementChild.value = "";
    }
  }

  function showReplySection(evt) {
    let button =
      evt.currentTarget.parentNode.parentNode.children[3].firstElementChild;
    let section = evt.currentTarget.parentNode.parentNode.lastElementChild;

    section.style.display = "block";
    button.innerHTML = "Back";

    function show() {
      section.style.display = "none";
      button.innerHTML = "Reply";
    }

    button.addEventListener("click", show);
  }

  function move(evt) {
    let openQuestion = document.createElement("div");
    openQuestion.classList.add("openQuestion");

    let pendingQuestionsSection = evt.currentTarget.parentNode.parentNode.parentNode;
    let pendingQuestion = evt.currentTarget.parentNode.parentNode;
    pendingQuestion.removeChild(pendingQuestion.children[3]);

    let pendingQuestionElements = Array.from(pendingQuestion.children).slice(0, 3);

    let actionsDiv = document.createElement("div");
    actionsDiv.classList.add("actions");

    let actionButton = document.createElement("button");
    actionButton.classList.add("reply");
    actionButton.innerHTML = "Reply";
    actionButton.addEventListener("click", showReplySection);

    let replySection = document.createElement("div");
    replySection.classList.add("replySection");
    replySection.style.display = "none";

    let replyInput = document.createElement("input");
    replyInput.classList.add("replyInput");
    replyInput.type = "text";
    replyInput.placeholder = "Reply to this question here...";

    let replyButton = document.createElement("button");
    replyButton.classList.add("replyButton");
    replyButton.innerHTML = "Send";
    replyButton.addEventListener("click", reply);

    let replyOl = document.createElement("ol");
    replyOl.classList.add("reply");
    replyOl.type = "1";

    replySection.appendChild(replyInput);
    replySection.appendChild(replyButton);
    replySection.appendChild(replyOl);

    pendingQuestionElements.forEach(elem => {
      openQuestion.appendChild(elem);
    });

    actionsDiv.appendChild(actionButton);
    openQuestion.appendChild(actionsDiv);
    openQuestion.appendChild(replySection);

    pendingQuestionsSection.removeChild(pendingQuestion);
    document.querySelector("#openQuestions").appendChild(openQuestion);
  }

  function archive(evt) {
    evt.currentTarget.parentNode.parentNode.parentNode.removeChild(
      evt.currentTarget.parentNode.parentNode
    );
  }

  function receiveQuestion() {
    let question = document.querySelector("#inputSection > textarea").value;
    let username = document.querySelector(
      "#inputSection > div > input[type=username]"
    ).value;

    if (question !== "") {
      let pendingQuestion = document.createElement("div");
      pendingQuestion.classList.add("pendingQuestion");

      let img = document.createElement("img");
      img.src = "./images/user.png";
      img.width = "32";
      img.height = "32";

      let span = document.createElement("span");
      span.innerHTML = username === "" ? "Anonymous" : username;

      let p = document.createElement("p");
      p.innerHTML = question;

      let actionsDiv = document.createElement("div");
      actionsDiv.classList.add("actions");

      let archiveButton = document.createElement("button");
      archiveButton.classList.add("archive");
      archiveButton.innerHTML = "Archive";
      archiveButton.addEventListener("click", archive);

      let openButton = document.createElement("button");
      openButton.classList.add("open");
      openButton.innerHTML = "Open";
      openButton.addEventListener("click", move);

      actionsDiv.appendChild(archiveButton);
      actionsDiv.appendChild(openButton);

      pendingQuestion.appendChild(img);
      pendingQuestion.appendChild(span);
      pendingQuestion.appendChild(p);
      pendingQuestion.appendChild(actionsDiv);

      document.querySelector("#pendingQuestions").appendChild(pendingQuestion);

      document.querySelector("#inputSection > textarea").value = "";
      document.querySelector(
        "#inputSection > div > input[type=username]"
      ).value = "";
    }
  }

  document
    .querySelector("#inputSection > div > button")
    .addEventListener("click", receiveQuestion);
}
