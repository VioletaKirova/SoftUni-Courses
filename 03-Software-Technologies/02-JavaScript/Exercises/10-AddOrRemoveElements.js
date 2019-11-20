function addOrRemoveElements(arr) {
    let newArr = new Array();
    for (let obj of arr) {
        let commandAndValue = obj.split(' ');
        let command = commandAndValue[0];
        let num = Number(commandAndValue[1]);
        if (command === 'add'){
            newArr.push(num);
        }
        else if (command === 'remove'){
            if (num >= newArr.length){
                continue;
            }
            newArr.splice(num, 1);
        }
    }
    for (let obj of newArr) {
        console.log(obj);
    }
}

addOrRemoveElements(['add 3', 'add 5', 'remove 1', 'add 2']);