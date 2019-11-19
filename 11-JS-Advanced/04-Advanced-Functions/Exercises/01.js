function solve(arr, order) {
  let sortMap = {
    asc: (a, b) => a - b,
    desc: (a, b) => b - a
  };

  return [...arr].sort(sortMap[order]);
}

console.log(solve([14, 7, 17, 6, 8], "asc"));
