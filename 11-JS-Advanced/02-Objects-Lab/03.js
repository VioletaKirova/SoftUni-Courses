function solve(arr){
    function formatString(str){
        str = str
                .replace(/&/g, "&amp;")
                .replace(/>/g, "&gt;")
                .replace(/</g, "&lt;")
                .replace(/"/g, "&quot;")
                .replace(/'/g, "&#39;");
        return str;
    }
     
    function formatHeadings(arr){
        return arr
            .reduce((a, b) => { return `${a}<th>${b}</th>` }, "");
    }
     
    function formatRows(arr){
        return arr
            .map(x => x.reduce((a, b) => { return `${a}<td>${b}</td>` }, ""))
            .map(x => `<tr>${x}</tr>`)
            .join("\n  ");
    }

    arr = JSON.parse(arr);
    let headings = Object.keys(arr[0]);
    let rows = arr
        .map(x => Object.values(x).map(y => isNaN(y) ? formatString(y.toString()) : y));

    let html = `<table>\n  <tr>${formatHeadings(headings)}</tr>\n  ${formatRows(rows)}\n</table>`;
    console.log(html);
}

solve('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');
solve('[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]');