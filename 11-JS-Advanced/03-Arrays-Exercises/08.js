function solve(arr){
    let dashboard = [
        [false, false, false],
        [false, false, false],
        [false, false, false]];

    let player = "X";
    let playerHasWon = false;

    for(let i = 0; i < arr.length; i++){
        let [row, col] = arr[i].split(" ").map(Number);

        if(dashboard[row][col] !== false){
            console.log("This place is already taken. Please choose another!");
            continue;
        }

        dashboard[row][col] = player;

        for(let row = 0; row < dashboard.length; row++){
            checkForWinner(dashboard[row]);
        }

        for(let col = 0; col < dashboard[0].length; col++){
            let currentCol = [dashboard[0][col], dashboard[1][col], dashboard[2][col]];
            checkForWinner(currentCol);
        }

        let firstDigonal = [];
        let secondDigonal = [];

        for(let row = 0; row < dashboard.length; row++){
            firstDigonal.push(dashboard[row][row]);
            secondDigonal.push(dashboard[row][dashboard.length - 1 - row]);
        }

        checkForWinner(firstDigonal);
        checkForWinner(secondDigonal);
        
        if((!dashboard.flat(1).includes(false) || i === arr.length - 1) && !playerHasWon){
            console.log("The game ended! Nobody wins :(");
            printDashboard();
            break;
        }

        if(playerHasWon){
            console.log(`Player ${player} wins!`);
            printDashboard();
            break;
        }

        player = player === "X" ? "O" : "X";
    }

    function checkForWinner(arr) {
        if (!arr.includes(false)) {
            let opositePlayer = player === "X" ? "O" : "X";

            if (!arr.includes(opositePlayer)) {
                playerHasWon = true;
            }
        }
    }

    function printDashboard() {
        for (let row = 0; row < dashboard.length; row++) {
            console.log(dashboard[row].join("\t"));
        }
    }
}

solve(
    ["0 1",
    "0 0",
    "0 2", 
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"]
);

solve(
    ["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]
);

solve(
    ["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]
);