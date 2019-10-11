function solve() {
  function createTag(tag){
    return document.createElement(tag);
  }

  document.querySelector("#exercise button")
    .addEventListener("click", () => {
      let input = document.querySelector("#exercise textarea");

      if(input.value !== ""){
        let items = JSON.parse(input.value);

        [...items].forEach(item => {
          let table = document.querySelector(".row tbody");
          let tr = createTag("tr");
          table.appendChild(tr);

          // Image
          let imgTd = createTag("td");
          let img = createTag("img");
          img.src = item.img;
          imgTd.appendChild(img);
          tr.appendChild(imgTd);

          // Name
          let nameTd = createTag("td");
          let nameP = createTag("p");
          nameP.innerHTML = item.name;
          nameTd.appendChild(nameP);
          tr.appendChild(nameTd);

          // Price
          let priceTd = createTag("td");
          let priceP = createTag("p");
          priceP.innerHTML = item.price;
          priceTd.appendChild(priceP);
          tr.appendChild(priceTd);

          // Decoration Factor
          let decFactorTd = createTag("td");
          let decFactoP = createTag("p");
          decFactoP.innerHTML = item.decFactor;
          decFactorTd.appendChild(decFactoP);
          tr.appendChild(decFactorTd);

          // Mark
          let inputTd = createTag("td");
          let input = createTag("input");
          input.type = "checkbox";
          input.disabled = false;
          inputTd.appendChild(input);
          tr.appendChild(inputTd);
        });
      }
    });

    document.querySelectorAll("#container button")[1]
      .addEventListener("click", () => {
        let checkedMarks = [...document.querySelectorAll(".table input")]
          .filter(m => m.checked === true);

        let itemNames = [...checkedMarks].reduce((a, b) => {
          a.push(b.parentNode.parentNode.childNodes[1].firstChild.innerHTML);
          return a;
        }, []);

        let totalPrice = [...checkedMarks].reduce((a, b) => {
          return a + Number(b.parentNode.parentNode.childNodes[2].firstChild.innerHTML);
        }, 0);

        let avgDecFactor = [...checkedMarks].reduce((a, b) => {
          return a + Number(b.parentNode.parentNode.childNodes[3].firstChild.innerHTML);
        }, 0) / checkedMarks.length;

        let output = document.querySelectorAll("#container textarea")[1];
        output.value += `Bought furniture: ${itemNames.join(", ")}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${avgDecFactor}`;
    });
}