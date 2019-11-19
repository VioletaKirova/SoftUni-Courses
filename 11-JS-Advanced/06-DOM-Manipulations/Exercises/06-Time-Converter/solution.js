function attachEventsListeners() {
  function getDays(value, id) {
    return id === "days"
      ? value
      : id === "hours"
      ? value / 24
      : id === "minutes"
      ? value / 1440
      : value / 86400;
  }

  function fill(days) {
    document.querySelector("#days").value = days;
    document.querySelector("#hours").value = days * 24;
    document.querySelector("#minutes").value = days * 1440;
    document.querySelector("#seconds").value = days * 86400;
  }

  function getResult(evt) {
    let input = evt.currentTarget.previousElementSibling;

    if (input.value !== "") {
      fill(getDays(input.value, input.id));
    }
  }

  [...document.querySelectorAll("input")]
    .filter(i => i.type === "button")
    .forEach(b => b.addEventListener("click", getResult));
}
