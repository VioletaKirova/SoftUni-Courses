function solve() {
    let operatorsMap = [ "+", "-", "*", "/" ];

    function evaluate(evt){
        let value = evt.currentTarget.value;

        let input = document.getElementById("expressionOutput");
        let output = document.getElementById("resultOutput");

        if(value === "Clear"){
            input.innerHTML = "";
            output.innerHTML = "";
        } else if (operatorsMap.includes(value)){
            input.innerHTML += ` ${value} `;
        } else if (value === "="){
            output.innerHTML = input.innerHTML.split(" ")[2] === "" ? 
                "NaN" :
                eval(input.innerHTML);
        } else {
            input.innerHTML += value;
        }
    }

    [...document.querySelectorAll("button")]
        .forEach(b => b.addEventListener("click", evaluate));
}


