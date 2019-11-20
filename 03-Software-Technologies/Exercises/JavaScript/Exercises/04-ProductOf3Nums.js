function productOf3Nums(arr) {
    let parsedArr = arr.map(Number);
    let count = 0;
    for (let i = 0; i < parsedArr.length; i++) {
        if(parsedArr[i] < 0){
            count++;
        }
    }
    if (count % 2 != 0){
        return 'Negative';
    }
    else{
        return 'Positive';
    }
}