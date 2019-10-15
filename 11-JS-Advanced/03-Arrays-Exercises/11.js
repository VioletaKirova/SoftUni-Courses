function solve(length, width) {
  let matrix = [...Array(length)].map(x => Array(width).fill(0));
  let maxRotations = width * length;
  let direction = "right";
  let row = 0;
  let col = 0;

  for (let i = 1; i <= maxRotations; i++) {
    if (direction === "right" && (col === width || matrix[row][col] !== 0)) {
      direction = "down";
      row++;
      col--;
    }
    if (direction === "down" && (row === length || matrix[row][col] !== 0)) {
      direction = "left";
      row--;
      col--;
    }
    if (direction === "left" && (col === -1 || matrix[row][col] !== 0)) {
      direction = "up";
      row--;
      col++;
    }
    if (direction === "up" && (row === -1 || matrix[row][col] !== 0)) {
      direction = "right";
      row++;
      col++;
    }

    matrix[row][col] = i;

    if (direction === "right") {
      col++;
    }
    if (direction === "down") {
      row++;
    }
    if (direction === "left") {
      col--;
    }
    if (direction === "up") {
      row--;
    }
  }

  console.log(matrix.map(x => x.join(" ")).join("\n"));
}

solve(5, 5);
solve(8, 8);
