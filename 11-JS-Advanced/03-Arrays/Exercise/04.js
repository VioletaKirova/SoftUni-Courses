function solve(arr) {
  let copy = arr.slice(0, arr.length - 1);
  let iterations = Number(arr[arr.length - 1]) % (arr.length - 1);

  for (let i = 0; i < iterations; i++) {
    copy.unshift(copy.pop());
  }

  console.log(copy.join(" "));
}

solve(["1", "2", "3", "4", "2"]);
solve(["Banana", "Orange", "Coconut", "Apple", "15"]);
