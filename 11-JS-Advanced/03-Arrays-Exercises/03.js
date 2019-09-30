function solve(arr){
    const actionsMap = {
        "add":"push",
        "remove":"pop"
    };

    let result = [];
    let number = 0;

    for(let action of arr){
        result[actionsMap[action]](++number);
    }

    console.log(result.length === 0 ? "Empty" : result.join("\n"));
}

solve(
    ['add', 
    'add', 
    'add', 
    'add']
);

solve(
    ['add', 
    'add', 
    'remove', 
    'add', 
    'add']
);

solve(
    ['remove', 
    'remove', 
    'remove']
);