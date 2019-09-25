function solve(arr){
    let result = {};

    for(let i = 0; i < arr.length; i++){
        let line = arr[i]
            .split(" | ");

        let product = line[1];
        let town = line[0];
        let price = Number([line[2]]);

        if(result[product] === undefined){
            result[product] = {};
        }

        result[product][town] = price;
    }

    for(let p in result){
        let lowestPrice = Number.MAX_SAFE_INTEGER;
        let townWithLowestPrice = "";

        for(let t in result[p]){
            if(result[p][t] < lowestPrice){
                lowestPrice = result[p][t];
                townWithLowestPrice = t;
            }        
        }

        console.log(`${p} -> ${lowestPrice} (${townWithLowestPrice})`);
    }
}

solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
);