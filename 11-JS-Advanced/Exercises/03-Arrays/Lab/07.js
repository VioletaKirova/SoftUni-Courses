function solve(arr) {
  return arr
    .slice()
    .flat(1)
    .sort((a, b) => b - a)[0];
}

solve([[20, 50, 10], [8, 33, 145]]);

solve([[3, 5, 7, 12], [-1, 4, 33, 2], [8, 3, 0, 4]]);
