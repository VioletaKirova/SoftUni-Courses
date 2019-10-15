function solve(arr) {
  let result = {};
  for (let i = 0; i < arr.length; i += 2) {
    if (result[arr[i]] === undefined) {
      result[arr[i]] = 0;
    }
    result[arr[i]] += Number(arr[i + 1]);
  }
  console.log(JSON.stringify(result));
}

solve(["Sofia", "20", "Varna", "3", "Sofia", "5", "Varna", "4"]);
solve(["Sofia", "20", "Varna", "3", "sofia", "5", "varna", "4"]);
