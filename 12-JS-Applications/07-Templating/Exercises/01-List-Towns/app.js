async function loadTowns() {
  const input = document.getElementById("towns");

  if (input !== null && input.value !== "") {
    const source = await fetch(
      "http://127.0.0.1:5500/01-List-Towns/towns-template.hbs"
    )
      .then(res => res.text())
      .catch(err => console.log(err));

    const template = Handlebars.compile(source);
    const context = {
      towns: input.value.split(", ")
    };
    const html = template(context);

    document.getElementById("root").innerHTML = html;
    input.value = "";
  }
}

document.getElementById("btnLoadTowns").addEventListener("click", loadTowns);
