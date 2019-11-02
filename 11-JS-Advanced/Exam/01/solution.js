function solve() {
  function filterProducts() {
    let word = document.querySelector("#filter").value;
    let productListItems = Array.from(
      document.querySelector("#products > ul").childNodes
    ).slice(1);

    if (word === "") {
      for (let li of productListItems) {
        li.style.display = "block";
      }
    }

    for (let li of productListItems) {
      if (
        !li.firstElementChild.textContent.toLocaleLowerCase().includes(word)
      ) {
        li.style.display = "none";
      }
    }
  }

  function buyProducts(evt) {
    let clientProductsList = document.querySelector("#myProducts > ul");
    let productListItems = Array.from(clientProductsList.childNodes).splice(1);

    for (let i = 0; i < productListItems.length; i++) {
      clientProductsList.removeChild(productListItems[i]);
    }

    totalPrice = 0;

    let totalPriceH1 = document.querySelector("body > h1:nth-child(4)");
    totalPriceH1.textContent = `Total Price: ${totalPrice.toFixed(2)}`;
  }

  //// addToClientList() outside of addProduct()'s scope

  // function addToClientList(evt) {
  //   let parent = evt.currentTarget.parentNode;
  //   let name = parent.parentNode.firstElementChild;
  //   let price = parent.firstElementChild;
  //   let availableStrong = price.nextElementSibling;
  //   let availableCount = Number(availableStrong.textContent.split(" ")[1]);

  //   let reducedAvailableCount = availableCount - 1;

  //   if (reducedAvailableCount === 0) {
  //     parent.parentNode.parentNode.removeChild(parent.parentNode);
  //   }

  //   availableStrong.textContent = `Available: ${reducedAvailableCount}`;
  //   totalPrice += Number(price.textContent);

  //   let totalPriceH1 = document.querySelector("body > h1:nth-child(4)");
  //   totalPriceH1.textContent = `Total Price: ${totalPrice.toFixed(2)}`;

  //   let currentProductName = name.textContent;
  //   let currentProductPrice = price.textContent;

  //   let clientProductsList = document.querySelector("#myProducts > ul");

  //   let li = document.createElement("li");

  //   let priceStrong = document.createElement("strong");
  //   priceStrong.textContent = currentProductPrice;

  //   li.textContent = currentProductName;
  //   li.appendChild(priceStrong);

  //   clientProductsList.appendChild(li);
  // }

  function addProduct(evt) {
    evt.preventDefault();

    let name = document.querySelector(
      "#add-new > input[type=text]:nth-child(2)"
    ).value;
    let quantity = document.querySelector(
      "#add-new > input[type=text]:nth-child(3)"
    ).value;
    let price = document.querySelector(
      "#add-new > input[type=text]:nth-child(4)"
    ).value;

    let productsList = document.querySelector("#products > ul");

    let li = document.createElement("li");

    let nameSpan = document.createElement("span");
    nameSpan.textContent = name;

    let quantityStrong = document.createElement("strong");
    quantityStrong.textContent = `Available: ${quantity}`;

    let div = document.createElement("div");

    let priceStrong = document.createElement("strong");
    priceStrong.textContent = `${Number(price).toFixed(2)}`;

    let button = document.createElement("button");
    button.textContent = "Add to Client's List";
    button.addEventListener("click", addToClientList);

    div.appendChild(priceStrong);
    div.appendChild(button);

    li.appendChild(nameSpan);
    li.appendChild(quantityStrong);
    li.appendChild(div);

    productsList.appendChild(li);

    function addToClientList() {
      quantity--;

      if (quantity === 0) {
        productsList.removeChild(li);
      }

      quantityStrong.textContent = `Available: ${quantity}`;
      totalPrice += Number(price);

      let totalPriceH1 = document.querySelector("body > h1:nth-child(4)");
      totalPriceH1.textContent = `Total Price: ${totalPrice.toFixed(2)}`;

      let clientProductsList = document.querySelector("#myProducts > ul");

      let newLi = document.createElement("li");

      let newPriceStrong = document.createElement("strong");
      newPriceStrong.textContent = priceStrong.textContent;

      newLi.textContent = name;
      newLi.appendChild(newPriceStrong);

      clientProductsList.appendChild(newLi);
    }
  }

  let totalPrice = 0;

  let addButton = document.querySelector("#add-new > button");
  addButton.addEventListener("click", addProduct);

  let buyButton = document.querySelector("#myProducts > button");
  buyButton.addEventListener("click", buyProducts);

  let filterButton = document.querySelector("#products > div > button");
  filterButton.addEventListener("click", filterProducts);
}
