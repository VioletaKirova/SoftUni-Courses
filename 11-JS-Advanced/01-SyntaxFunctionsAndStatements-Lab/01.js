function solve(...params){
    let sum = params.reduce((a, b) => a + b.length, 0);
    let avg = Math.floor(sum / params.length);
    let result = [sum, avg];
    console.log(result.join("\n"));
}

solve('chocolate', 'ice cream', 'cake');