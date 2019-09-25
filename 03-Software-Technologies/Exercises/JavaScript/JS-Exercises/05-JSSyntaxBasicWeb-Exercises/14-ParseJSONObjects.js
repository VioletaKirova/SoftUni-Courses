function parseJSONObjects(arr) {
    let object = arr.map(JSON.parse);
    for (let obj of object) {
        console.log(`Name: ${obj.name}`);
        console.log(`Age: ${obj.age}`);
        console.log(`Date: ${obj.date}`);
    }
}

parseJSONObjects(['{"name":"Gosho","age":10,"date":"19/06/2005"}', '{"name":"Tosho","age":11,"date":"04/04/2005"}']);