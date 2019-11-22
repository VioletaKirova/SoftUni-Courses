function toggle(element) {
  element.textContent =
    element.textContent === "Show status code"
      ? "Hide status code"
      : "Show status code";

  const status = element.parentNode.querySelector(".status");
  status.style.display = status.style.display === "none" ? "inline" : "none";
}

(() => {
  renderCatTemplate();

  async function renderCatTemplate() {
    const partialSource = await fetch(
      "http://127.0.0.1:5500/02-HTTP-Status-Cats/cat-template.hbs"
    )
      .then(res => res.text())
      .catch(err => console.log(err));

    Handlebars.registerPartial("cat", partialSource);

    const source = await fetch(
      "http://127.0.0.1:5500/02-HTTP-Status-Cats/cats-template.hbs"
    )
      .then(res => res.text())
      .catch(err => console.log(err));

    const template = Handlebars.compile(source);
    const context = { cats: window.cats };
    const html = template(context);

    document.getElementById("allCats").innerHTML = html;
  }
})();
