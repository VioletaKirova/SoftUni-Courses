function findLargest3Nums(arr) {
    let sortedNums = arr.sort((a,b) => b - a);
    let numsCount = Math.min(3, sortedNums.length);
    for (var i = 0; i < numsCount; i++) {
        console.log(sortedNums[i]);
    }
}

findLargest3Nums([1, 2, 3, 4]);