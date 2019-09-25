function turnObjectIntoJSONString(arr) {
    let object = {};
    for (let obj of arr) {
        let tockens = obj.split(' -> ');
        let key = tockens[0];
        let value = tockens[1];
        if(!isNaN(value)) {
            value = Number(value);
        }
        object[key] = value;
    }
    let jsonString = JSON.stringify(object);
    console.log(jsonString);
}

turnObjectIntoJSONString(['name -> Angel', 'surname -> Georgiev', 'age -> 20', 'grade -> 6.', 'date -> 23/05/1995', 'town -> Sofia']);