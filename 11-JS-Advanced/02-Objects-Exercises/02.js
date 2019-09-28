function solve(arr){
    let result = arr
        .map(x => JSON.parse(x))
        .map(x => Object.values(x)
            .map(y => `\t\t<td>${y}</td>`)
            .join("\n"))
        .map(x => `\t<tr>\n${x}\n\t</tr>`)
        .join("\n");
        
    console.log(`<table>\n${result}\n</table>`);
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
);
