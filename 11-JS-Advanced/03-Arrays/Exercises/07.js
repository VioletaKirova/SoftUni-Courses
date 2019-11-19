function solve(arr) {
  let result = true;
  let rowSumSet = new Set(arr.map(row => row.reduce((a, b) => a + b, 0)));

  if (rowSumSet.size !== 1) {
    result = false;
  }

  let colSumSet = new Set();

  for (let col = 0; col < arr[0].length; col++) {
    let colSum = 0;
    for (let row = 0; row < arr.length; row++) {
      colSum += arr[row][col];
    }
    colSumSet.add(colSum);
  }

  if (colSumSet.size !== 1 || [...rowSumSet][0] !== [...colSumSet][0]) {
    result = false;
  }

  console.log(result);
}

solve([[4, 5, 6], [6, 5, 4], [5, 5, 5]]);
solve([[11, 32, 45], [21, 0, 1], [21, 1, 1]]);
solve([[1, 0, 0], [0, 0, 1], [0, 1, 0]]);
