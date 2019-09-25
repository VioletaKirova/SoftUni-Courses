function multipleValuesForAKey(arr) {
    let object = {};
    for(let i = 0; i<arr.length-1; i++) {
        let tokens = arr[i].split(' ');
        let key = tokens[0];
        let value = tokens[1];
        if(!key in object) {
            object[key] = new Array();
        }
        object[key].push(value);
    }

    let key = arr[arr.length-1];
    if(key in object) {
        for(let value of object[key]) {
            console.log(value);
        }
    } else {
        console.log("None");
    }
}