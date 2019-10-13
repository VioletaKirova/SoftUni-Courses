function attachGradientEvents() {
    function getPercentage(x){
        return Math.floor(x / gradientWidth * 100);
    }

    function getResult(evt){
        output.textContent = `${getPercentage(evt.offsetX)}%`;
    }

    let output = document.getElementById("result");
    let gradient = document.getElementById("gradient-box");
    //let gradientWidth = Number(window.getComputedStyle(gradient).width.replace("px", ""));
    let gradientWidth = 300;

    gradient.addEventListener("mousemove", getResult);
}