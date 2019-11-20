function setValuesToArray(arr) {
    let newArr = [];
    let arrLen = Number(arr[0]);
    //let newArr = new Array(length).fill(0); -> different method
    for (let i = 0; i < arrLen; i++) {
        newArr[i] = 0;
    }
    for (let i = 1; i < arr.length; i++) {
        let currentKPV = arr[i].split(' - ');
        let index = Number(currentKPV[0]);
        let value = Number(currentKPV[1]);
        if(index >= newArr.length){
            continue;
        }
        newArr[index] = value;
    }
    for (let num of newArr) {
        console.log(num);
    }
}

setValuesToArray(['3', '0 - 5', '2 - 8']);