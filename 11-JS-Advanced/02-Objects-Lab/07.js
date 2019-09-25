function solve(arr){
    let result = {};

    for(let i = 0; i < arr.length; i++){
        let line = arr[i]
            .split(" -> ")
            .filter(x => x !== "");

        let town = line[0];
        let product = line[1];
        let pricingStr = line[2];
        
        if(result[town] === undefined){
            result[town] = { };
        }

        result[town][product] = pricingStr
            .split(" : ")
            .reduce((a, b) => {return Number(a) * Number(b)}, 1);
    }

    for(let t in result){
        console.log(`Town - ${t}`);

        for(let p in result[t]){
            console.log(`$$$${p} : ${result[t][p]}`);
        }
    }
}

solve(['Sofia -> Laptops HP -> 200 : 2000',
'Sofia -> Raspberry -> 200000 : 1500',
'Sofia -> Audi Q7 -> 200 : 100000',
'Montana -> Portokals -> 200000 : 1',
'Montana -> Qgodas -> 20000 : 0.2',
'Montana -> Chereshas -> 1000 : 0.3']
);