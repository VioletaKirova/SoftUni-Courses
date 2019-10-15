function solve() {
  let cart = {};
  let output = document.querySelector(".shopping-cart textarea");

  [...document.querySelectorAll(".add-product")].forEach(b =>
    b.addEventListener("click", evt => {
      let productDetails = evt.target.parentNode.previousElementSibling;

      let title = productDetails.querySelector(".product-title").innerHTML;
      let price = evt.target.parentNode.nextElementSibling.innerHTML;

      if (cart[title] === undefined) {
        cart[title] = 0;
      }

      cart[title] += Number(price);

      output.innerHTML += `Added ${title} for ${price} to the cart.\n`;
    })
  );

  document.querySelector(".checkout").addEventListener("click", () => {
    [...document.querySelectorAll(".add-product")].forEach(
      b => (b.disabled = true)
    );

    document.querySelector(".checkout").disabled = true;

    let itemTitles = Object.keys(cart).join(", ");
    let totalPrice = Object.values(cart).reduce((a, b) => a + b, 0);

    output.innerHTML += `You bought ${itemTitles} for ${totalPrice.toFixed(
      2
    )}.`;
  });
}
