function solve() {
  function changeColor() {
    if (this.hasAttribute("style")) {
      this.removeAttribute("style");
    } else {
      Array.from(this.parentNode.children).forEach(x =>
        x.removeAttribute("style")
      );

      this.style.backgroundColor = "#413f5e";
    }
  }

  Array.from(document.querySelectorAll("tr"))
    .slice(1)
    .forEach(x => {
      x.addEventListener("click", changeColor);
    });
}
