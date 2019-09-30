function solve(arr){
    let step = Number(arr[arr.length - 1]);
    let result = arr.slice(0, arr.length - 1)
        .filter((_, i) => i % step === 0)
        .join("\n");
    console.log(result);
}

solve(
    ['5', 
    '20', 
    '31', 
    '4', 
    '20', 
    '2']
);

solve(
    ['dsa',
    'asd', 
    'test', 
    'tset', 
    '2']
);