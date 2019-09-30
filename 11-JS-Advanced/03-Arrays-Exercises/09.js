function solve(arr){
    let matrix = arr
        .map(x => x.split(" ")
        .map(y => Number(y)));

    let diagonalIndexes = [];

    let firstDiagonalSum = 0;
    let secondDiagonalSum = 0;

    for(let row = 0; row < matrix.length; row++){
        firstDiagonalSum += matrix[row][row];
        secondDiagonalSum += matrix[row][matrix.length - 1 - row];

        diagonalIndexes.push(`${row} ${row}`);
        diagonalIndexes.push(`${row} ${matrix.length - 1 - row}`);
    }

    if(firstDiagonalSum === secondDiagonalSum){
        for(let row = 0; row < matrix.length; row++){
            matrix[row] = matrix[row]
                .map((x, i) => !diagonalIndexes.includes(`${row} ${i}`) ? firstDiagonalSum : x);
        }
    }

    let result = matrix
        .slice()
        .map(x => x.join(" "))
        .join("\n");

    console.log(result);
}

solve(
    ['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);

solve(
    ['1 1 1',
    '1 1 1',
    '1 1 0']
);