function solve(arr){
    const areaMap = {
        "motorway" : 130,
        "interstate" : 90,
        "city" : 50,
        "residential" : 20
    }
    let speed = arr[0];
    let area = arr[1];
    let areaLimit = areaMap[area];
    if(speed <= areaLimit){
        return;
    }
    else if(speed > areaLimit && speed <= areaLimit + 20){
        console.log("speeding");
    }
    else if(speed > areaLimit + 20 && speed <= areaLimit + 40){
        console.log("excessive speeding");
    }
    else{
        console.log("reckless driving");
    }
}

solve([40, 'city']);
solve([21, 'residential']);
solve([120, 'interstate']);
solve([200, 'motorway']);