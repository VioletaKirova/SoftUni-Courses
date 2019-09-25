function solve(arr){
    const operationsMap = {
        chop : "num / 2",
        dice : "Math.sqrt(num)", 
        spice : "num + 1",
        bake : "num * 3",
        fillet : "num - num * 0.2"
    }
    let num = Number(arr[0]);
    for(let i = 1; i <= arr.length - 1; i++){
        num = eval(operationsMap[arr[i]]);
        console.log(num);
    }
}

solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);