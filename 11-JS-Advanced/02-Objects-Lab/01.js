function solve(arr){
    function parseNumberStrings(str){
        return !isNaN(str) ? +Number(str).toFixed(2) : str;
    }
    
    function splitStringToArray(str){
        return str
            .split("|")
            .filter(x => x !== "")
            .map(x => x.trim())
            .map(x => parseNumberStrings(x));
    }

    let headings = splitStringToArray(arr[0]);
    
    let rows = arr
        .slice(1)
        .map(x => splitStringToArray(x))
        .map(x => x.reduce((a, b, i) => {
            a[headings[i]] = b
            return a;
        }, 
        {}));

    console.log(JSON.stringify(rows));
}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);