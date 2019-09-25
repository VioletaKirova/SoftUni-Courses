function multipleValuesForAKey(arr) {
    let objectArr = [];
    for (let i = 0; i < arr.length - 1; i++) {
        let kvp = arr[i].split(' ');
        let key = kvp[0];
        let value = kvp[1];
        let object = {key:key, value:value};
        objectArr.push(object);
    }
    let keyFound = false;
    let inputKey = arr[arr.length - 1];
    for (let obj of objectArr) {
        if(inputKey == obj.key){
            keyFound = true;
            console.log(obj.value);
        }
    }
    if(!keyFound){
        console.log('None');
    }
}

multipleValuesForAKey(['3 test', '3 test1', '4 test2', '4 test3', '4 test5', '4']);