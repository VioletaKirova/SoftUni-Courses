function solve(arr){
    let brands = {};

    for(let i = 0; i < arr.length; i++){
        let [brand, model, producedCars] = arr[i].split(" | ");
        producedCars = Number(producedCars);

        if(brands[brand] === undefined){
            brands[brand] = {};
        }

        if(brands[brand][model] === undefined){
            brands[brand][model] = 0;
        }

        brands[brand][model] += producedCars;
    }

    for(let b in brands){
        console.log(b);
        
        for(let m in brands[b]){
            console.log(`###${m} -> ${brands[b][m]}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);