function solve(arr) {
  let productsByFirstChar = {};
  for (let i = 0; i < arr.length; i++) {
    let firstChar = arr[i].charAt(0);

    if (productsByFirstChar[firstChar] === undefined) {
      productsByFirstChar[firstChar] = [];
    }

    productsByFirstChar[firstChar].push(arr[i]);
  }

  for (let char in productsByFirstChar) {
    productsByFirstChar[char] = productsByFirstChar[char].sort();
  }

  let sortedKeys = Object.keys(productsByFirstChar).sort();

  for (let i = 0; i < sortedKeys.length; i++) {
    let char = sortedKeys[i];
    let products = productsByFirstChar[char]
      .map(x => `  ${x.split(" : ").join(": ")}`)
      .join("\n");
    console.log(`${char}\n${products}`);
  }
}

solve([
  "Appricot : 20.4",
  "Fridge : 1500",
  "TV : 1499",
  "Deodorant : 10",
  "Boiler : 300",
  "Apple : 1.25",
  "Anti-Bug Spray : 15",
  "T-Shirt : 10"
]);
