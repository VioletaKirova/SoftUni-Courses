function solve(arr) {
  let firstDiagonalSum = 0;
  let secondDiagonalSum = 0;

  for (let row = 0; row < arr.length; row++) {
    firstDiagonalSum += arr[row][row];
    secondDiagonalSum += arr[row][arr[0].length - 1 - row];
  }

  console.log(`${firstDiagonalSum} ${secondDiagonalSum}`);
}

solve([[20, 40], [10, 60]]);

solve([[3, 5, 17], [-1, 7, 14], [1, -8, 89]]);
