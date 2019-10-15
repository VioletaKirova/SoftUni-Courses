function solve(arr) {
  let delimeter = arr[arr.length - 1];
  let words = arr.slice(0, arr.length - 1);
  let result = words.join(delimeter);
  console.log(result);
}

solve(["One", "Two", "Three", "Four", "Five", "-"]);
solve(["How about no?", "I", "will", "not", "do", "it!", "_"]);
