function solve(input){
    let type = typeof(input);
    if(type === "number"){
        let result = (input ** 2 * Math.PI).toFixed(2);
        console.log(result);
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${type}.`);
    }
}

solve(5);
solve("invalid");