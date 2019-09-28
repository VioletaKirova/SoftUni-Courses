function solve(arr){
    let orderedArrays = arr
        .map(x => x.split(/["\[\], ]/gim).filter(y => y !== "").map(z => Number(z)))
        .map(x => x.sort((a, b) => b - a));

    for(let i = 0; i < orderedArrays.length; i++){
        let currentArr = orderedArrays[i];
        for(let j = i + 1; j < orderedArrays.length; j++){
            let arrToCheck = orderedArrays[j];
            if(currentArr.length !== arrToCheck.length){
                continue;
            }
            for(let k = 0; k < currentArr.length; k++){
                if(currentArr[k] !== arrToCheck[k]){
                    continue;
                }
                if(k === currentArr.length - 1){
                    orderedArrays.splice(j, 1);
                    j--;
                }
            }
        }
    }

    let result = orderedArrays
        .sort((a, b) => a.length - b.length)
        .map(x => `[${x.join(", ")}]`)
        .join("\n");

    console.log(result);
}

solve(["[-3, -2, -1, 0, 1, 2, 3, 4]",
"[10, 1, -17, 0, 2, 13]",
"[4, -3, 3, -2, 2, -1, 1, 0]"]
);

solve(["[7.14, 7.180, 7.339, 80.099]",
"[7.339, 80.0990, 7.140000, 7.18]",
"[7.339, 7.180, 7.14, 80.099]"]
)