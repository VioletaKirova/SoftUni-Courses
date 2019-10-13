function stopwatch() {
    let startBtn = document.getElementById("startBtn");
    let stopBtn = document.getElementById("stopBtn");
    let time = document.getElementById("time");

    let timer = undefined;
    let seconds = 0;

    function evaluate(){
        seconds++;

        let mm = ('0' + Math.floor(seconds / 60)).slice(-2);
        let ss = ('0' + seconds % 60).slice(-2);

        time.textContent = `${mm}:${ss}`;
    }

    function start(){
        startBtn.disabled = true;
        stopBtn.disabled = false;
        
        timer = setInterval(evaluate, 1000);
    }

    function stop(){
        startBtn.disabled = false;
        stopBtn.disabled = true;

        clearInterval(timer);
        seconds = 0;

        time.textContent = "00:00";
    }

    startBtn.addEventListener("click", start);
    stopBtn.addEventListener("click", stop);
}