function solve(n, k) {
  let result = [1];

  for (let i = 0; i < n - 1; i++) {
    let sum = result.slice(-k).reduce((a, b) => a + b, 0);
    result.push(sum);
  }

  console.log(result);
}

solve(6, 3);
solve(8, 2);
