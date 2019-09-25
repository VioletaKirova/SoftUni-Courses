function solve(arr){
    let result = {};

    for(let i = 0; i < arr.length; i++){
        let args = arr[i].split(" <-> ");
        let town = args[0];
        let population = Number(args[1]);
        if(result[town] === undefined){
            result[town] = 0;
        }
        result[town] += population;
    }

    for(let t in result){
        console.log(`${t} : ${result[t]}`);
    }
}

solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
);