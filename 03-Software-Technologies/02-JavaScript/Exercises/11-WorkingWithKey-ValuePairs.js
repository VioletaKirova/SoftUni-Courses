function workingWithKVP(arr) {
    let object = {};
    for (let i = 0; i < arr.length - 1; i++) {
        let kvpArr = arr[i].split(' ');
        let key = kvpArr[0];
        let value = kvpArr[1];
        object[key] = value;
    }
    let inputKey = arr[arr.length - 1];
    if (inputKey in object){
        console.log(object[inputKey]);
    }
    else{
        console.log('None');
    }
}

workingWithKVP(['3 test', '3 test1', '4 test2', '4 test3', '4 test5', '4'])