function solve(...params){
    let [name, age, weight, height] = params;

    function getStatus(bmi){
        return bmi < 18.5 
        ? "underweight" 
        : bmi < 25 
        ? "normal"
        : bmi < 30
        ? "overweight"
        : "obese";
    }

    function calcBMI(weight, height){
        return weight / Math.pow(height / 100, 2);
    }

    function getRecommendation(status){
        return status === "obese";
    }

    let chart = {
        name,
        personalInfo:{
            age,
            weight,
            height
        },
        BMI: Math.round(calcBMI(weight, height)),
        status: getStatus(calcBMI(weight, height))
    }

    if(getRecommendation(chart.status)){
        chart.recommendation = "admission required";
    }

    return chart;
}

console.log(solve("Peter", 29, 75, 182));
console.log(solve("Honey Boo Boo", 9, 57, 137));