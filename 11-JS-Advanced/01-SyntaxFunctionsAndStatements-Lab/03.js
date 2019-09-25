function solve(x, y){
    let min = Number(x);
    let max = Number(y);
    let result = 0;
    for(let i = min; i <= max; i++){
        result += i;
    }
    console.log(result);
}

solve(0, 5);