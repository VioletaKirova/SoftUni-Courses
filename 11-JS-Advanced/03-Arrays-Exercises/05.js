function solve(arr){
    let largestNum = 0;
    let result = [];

    for(let i = 0; i < arr.length; i++){
        if(arr[i] >= largestNum){
            largestNum = arr[i];
            result.push(largestNum);
        }
    }

    console.log(result.join("\n"));
}

solve(
    [1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
);