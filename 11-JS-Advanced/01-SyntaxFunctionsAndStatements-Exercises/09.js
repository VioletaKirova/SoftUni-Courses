function solve(arr){
    const drinkPricesMap = {
        "caffeine" : 0.8,
        "decaf" : 0.9,
        "tea" : 0.8
    }

    let income = 0;

    for(let i = 0; i < arr.length; i++){
        let order = arr[i].split(", ");
        let coins = Number(order[0]);

        let drinkPrice = order[1] === "coffee" ? drinkPricesMap[order[2]] : drinkPricesMap[order[1]];

        let milk = order[order.length - 2] === "milk" ? (drinkPrice * 0.1).toFixed(1) : 0;
        drinkPrice += Number(milk);

        let sugar = order[order.length - 1] === "0" ? 0 : 0.1;        
        drinkPrice += Number(sugar);

        let change = coins - drinkPrice;

        if(change < 0){
            console.log(`Not enough money for ${order[1]}. Need $${(change * (-1)).toFixed(2)} more.`);
        }
        else{
            console.log(`You ordered ${order[1]}. Price: $${drinkPrice.toFixed(2)} Change: $${change.toFixed(2)}`);
            income += Number(drinkPrice);
        }
    }
    
    console.log(`Income Report: $${income.toFixed(2)}`);
}

solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);