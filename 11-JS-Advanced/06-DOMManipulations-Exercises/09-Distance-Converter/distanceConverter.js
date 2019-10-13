function attachEventsListeners() {
    const kmConvertionMap = {
        "km" : (x) => x,
        "m" : (x) => x * 1000,
        "cm" : (x) => x * 100000,
        "mm" : (x) => x * 1000000,
        "mi" : (x) => x / 1.609344,
        "yrd" : (x) => x / 0.0009144,
        "ft" : (x) => x / 0.0003048,
        "in" : (x) => x / (2.54 * Math.pow(10, -5))
    };

    function convertToKm(option, value){
        return option === "km" ?
        value :
        option === "m" ?
        value / 1000 :
        option === "cm" ?
        value / 100000 :
        option === "mm" ?
        value / 1000000 :
        option === "mi" ?
        value * 1.609344 :
        option === "yrd" ?
        value * 0.0009144 :
        option === "ft" ?
        value * 0.0003048 :
        value * (2.54 * Math.pow(10, -5));
    }

    function convert(){
        let inputOption = document.querySelector("#inputUnits").value;
        let inputValue = document.querySelector("#inputDistance").value;

        let outputOption = document.querySelector("#outputUnits").value;
        let outputArea = document.querySelector("#outputDistance");

        let km = convertToKm(inputOption, inputValue);
        let outputValue = kmConvertionMap[outputOption](km);
        outputArea.value = outputValue;
    }

    document.querySelector("#convert")
        .addEventListener("click", convert);
}