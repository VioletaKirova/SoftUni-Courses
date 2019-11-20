function printLines(arr) {
    for (let line of arr) {
        if (line == 'Stop'){
            break;
        }
        console.log(line);
    }
}