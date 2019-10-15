function solve(arr) {
  function formatString(str) {
    str = str
      .replace(/&/g, "&amp;")
      .replace(/>/g, "&gt;")
      .replace(/</g, "&lt;")
      .replace(/"/g, "&quot;")
      .replace(/'/g, "&#39;");
    return str;
  }

  function formatHeadings(arr) {
    return arr.reduce((a, b) => {
      return `${a}<th>${b}</th>`;
    }, "");
  }

  function formatRows(arr) {
    return arr
      .map(x =>
        x.reduce((a, b) => {
          return `${a}<td>${b}</td>`;
        }, "")
      )
      .map(x => `<tr>${x}</tr>`)
      .join("\n  ");
  }

  arr = JSON.parse(arr);
  let headings = Object.keys(arr[0]);
  let rows = arr.map(x =>
    Object.values(x).map(y => (isNaN(y) ? formatString(y.toString()) : y))
  );

  let html = `<table>\n  <tr>${formatHeadings(headings)}</tr>\n  ${formatRows(
    rows
  )}\n</table>`;
  console.log(html);
}

solve('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]');
solve(
  '[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]'
);
