function solve(...params){
    let result = params.sort((a, b) => a - b).pop();
    console.log(`The largest number is ${result}.`);
}

solve(1, 2, 3, -4, 5);