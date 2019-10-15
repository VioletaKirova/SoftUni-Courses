function validate() {
  function validateEmail() {
    let match = input.value.match(/^\w+\@\w+\.\w+$/gi);

    if (match) {
      input.classList.remove("error");
    } else {
      input.classList.add("error");
    }
  }

  let input = document.getElementById("email");

  input.addEventListener("change", validateEmail);
}
