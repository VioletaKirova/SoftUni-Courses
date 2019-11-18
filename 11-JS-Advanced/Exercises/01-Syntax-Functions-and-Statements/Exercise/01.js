function solve(product, weight, price) {
  weight = weight / 1000;
  let cost = (weight * price).toFixed(2);
  console.log(
    `I need $${cost} to buy ${weight.toFixed(2)} kilograms ${product}.`
  );
}

solve("orange", 2500, 1.8);
