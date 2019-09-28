function solve(arr){
    let juices = {};
    let bottles = {};

    for(let i = 0; i < arr.length; i++){
        let [fruit, quantity] = arr[i].split(" => ");
        quantity = Number(quantity);
        
        if(juices[fruit] === undefined){
            juices[fruit] = 0;
        }

        juices[fruit] += quantity;

        if(juices[fruit] >= 1000){
            bottles[fruit] = juices[fruit];
        }
    }

    for(let b in bottles){
        bottles[b] /= 1000;
        console.log(`${b} => ${bottles[b].toFixed(0)}`);
    }
}

solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']
);