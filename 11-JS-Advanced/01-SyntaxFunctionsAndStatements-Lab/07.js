function solve(input){
    const daysMap = {
        "Monday" : 1,
        "Tuesday" : 2,
        "Wednesday" : 3,
        "Thursday" : 4,
        "Friday" : 5,
        "Saturday" : 6,
        "Sunday" : 7
    }
    let result = daysMap[input] ? daysMap[input] : "error";
    console.log(result);
}

solve("Monday");
solve("Invalid");