function acceptance() {
  function removeProduct(evt) {
    evt.currentTarget.parentNode.parentNode.removeChild(
      evt.currentTarget.parentNode
    );
  }

  function addProduct() {
    let [companyInput, nameInput, quantityInput, scrapeInput] = Array.from(
      document.querySelectorAll("input")
    );

    let company = companyInput.value;
    let name = nameInput.value;
    let quantity = Number(quantityInput.value);
    let scrape = Number(scrapeInput.value);

    let validationContitions = [
      company !== "",
      name !== "",
      !isNaN(quantity),
      !isNaN(scrape),
      quantity - scrape > 0
    ];

    if (validationContitions.indexOf(false) === -1) {
      let warehouse = document.querySelector("#warehouse");

      let div = document.createElement("div");

      let p = document.createElement("p");
      p.textContent = `[${company}] ${name} - ${quantity - scrape} pieces`;

      let button = document.createElement("button");
      button.textContent = "Out of stock";
      button.type = "button";
      button.addEventListener("click", removeProduct);

      div.appendChild(p);
      div.appendChild(button);

      warehouse.appendChild(div);

      companyInput.value = "";
      nameInput.value = "";
      quantityInput.value = "";
      scrapeInput.value = "";
    }
  }

  document.querySelector("#acceptance").addEventListener("click", addProduct);
}
