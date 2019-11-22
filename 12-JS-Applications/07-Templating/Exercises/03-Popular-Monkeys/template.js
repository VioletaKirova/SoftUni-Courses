function toggleInfo(element) {
  const p = element.nextElementSibling;
  p.style.display = p.style.display === "none" ? "inline-block" : "none";
}

(() => {
  renderMonkeysTemplate();

  async function renderMonkeysTemplate() {
    const source = await fetch(
      "http://127.0.0.1:5500/03-Popular-Monkeys/monkeys-template.hbs"
    )
      .then(res => res.text())
      .catch(err => console.log(err));
    const template = Handlebars.compile(source);
    const context = { monkeys };
    const html = template(context);

    document.querySelector(".monkeys").innerHTML = html;
  }
})();
