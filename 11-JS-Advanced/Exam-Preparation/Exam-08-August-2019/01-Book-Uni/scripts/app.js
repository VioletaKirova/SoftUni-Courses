function solve() {
  function matchPrice(text) {
    return text.match(/\d+\.?\d*/g);
  }

  function buyBook(evt) {
    totalProfit += Number(matchPrice(evt.currentTarget.innerHTML)[0]);

    document.getElementsByTagName(
      "h1"
    )[1].innerHTML = `Total Store Profit: ${totalProfit.toFixed(2)} BGN`;

    evt.currentTarget.parentNode.parentNode.removeChild(
      evt.currentTarget.parentNode
    );
  }

  function moveBook(evt) {
    let book = Array.from(evt.currentTarget.parentNode.childNodes).slice(0, 2);

    evt.currentTarget.parentNode.parentNode.removeChild(
      evt.currentTarget.parentNode
    );

    let div = document.createElement("div");
    div.classList.add("book");

    let currentBookPrice = matchPrice(book[1].innerHTML)[0];
    let newBookPrice =
      Number(currentBookPrice) - Number(currentBookPrice) * 0.15;
    book[1].innerHTML = `Buy it only for ${newBookPrice.toFixed(2)} BGN`;

    book.forEach(elem => {
      div.appendChild(elem);
    });

    oldBooksSection.firstElementChild.nextElementSibling.appendChild(div);
  }

  function addNewBook(evt) {
    evt.preventDefault();

    let inputs = document.getElementsByTagName("input");
    let title = inputs[0].value;
    let year = Number(inputs[1].value);
    let price = Number(inputs[2].value);

    let bookValidationConditions = [title !== "", year > 0, price > 0];

    if (bookValidationConditions.indexOf(false) === -1) {
      let div = document.createElement("div");
      div.classList.add("book");

      let p = document.createElement("p");
      p.innerHTML = `${title} [${year}]`;

      let buyButton = document.createElement("button");
      buyButton.innerHTML = `Buy it only for ${(year >= 2000
        ? price
        : price - price * 0.15
      ).toFixed(2)} BGN`;
      buyButton.addEventListener("click", buyBook);

      div.appendChild(p);
      div.appendChild(buyButton);

      if (year >= 2000) {
        let moveButton = document.createElement("button");
        moveButton.innerHTML = "Move to old section";
        moveButton.addEventListener("click", moveBook);

        div.appendChild(moveButton);
        newBooksSection.firstElementChild.nextElementSibling.appendChild(div);
      } else {
        oldBooksSection.firstElementChild.nextElementSibling.appendChild(div);
      }
    }
  }

  let totalProfit = 0;
  let [oldBooksSection, newBooksSection] = document.getElementsByTagName(
    "section"
  );
  let addNewBookButton = document.getElementsByTagName("button")[0];

  addNewBookButton.addEventListener("click", addNewBook);
}
