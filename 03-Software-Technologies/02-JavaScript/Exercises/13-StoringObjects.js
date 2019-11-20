function storingObjects(arr) {
    let allStudents = new Array();
    for (let obj of arr) {
        let tokens = obj.split(' -> ');
        let name = tokens[0];
        let age = tokens[1];
        let grade = tokens[2];
        let student = {Name:name, Age:age, Grade:grade};
        allStudents.push(student);
    }
    for (let student of allStudents) {
        console.log(`Name: ${student.Name}`);
        console.log(`Age: ${student.Age}`);
        console.log(`Grade: ${student.Grade}`);
    }
}

storingObjects(['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90']);