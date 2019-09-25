function solve(input){
    let arr = input.toString().split("");
    let equal = true;
    let sum = Number(arr[0]);
    let firstElement = arr[0];
    for(let i = 1; i < arr.length; i++){
        let current = arr[i];
        if(firstElement !== current){
            equal = false;
        }
        sum += Number(arr[i]);
    }
    console.log(equal);
    console.log(sum);
}

solve(2222222);
solve(1234);