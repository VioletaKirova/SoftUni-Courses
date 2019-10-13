function subtract() {
    function subtractNumbers(){
        output.innerHTML = Number(firstNumber.value) - Number(secondNumber.value);
    }
    
    let firstNumber = document.getElementById("firstNumber");
    let secondNumber = document.getElementById("secondNumber");
    let output = document.getElementById("result");

    firstNumber.disabled = false;
    secondNumber.disabled = false;
    
    subtractNumbers();

    [...document.querySelectorAll("input")]
        .forEach(i => i.addEventListener("change", subtractNumbers));
}