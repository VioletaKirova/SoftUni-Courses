function solve(params) {
  let sum = params.reduce((a, b) => a + b, 0);
  let sumInverse = params.reduce((a, b) => a + 1 / b, 0);
  let concat = params.reduce((a, b) => `${a}${b}`, "");
  console.log(sum);
  console.log(sumInverse);
  console.log(concat);
}

solve([1, 2, 3]);
solve([2, 4, 8, 16]);
