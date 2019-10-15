function focus() {
  function addHighlight(evt) {
    evt.currentTarget.parentElement.classList.add("focused");
  }

  function removeHighlight(evt) {
    evt.currentTarget.parentElement.classList.remove("focused");
  }

  [...document.querySelectorAll("input")].forEach(i =>
    i.addEventListener("focus", addHighlight)
  );

  [...document.querySelectorAll("input")].forEach(i =>
    i.addEventListener("blur", removeHighlight)
  );
}
