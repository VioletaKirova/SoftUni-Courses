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

  arr = JSON.parse(arr);
  let result = "<table>";
  let headings = Object.keys(arr[0]);

  result += "\n  <tr>";
  for (let i = 0; i < headings.length; i++) {
    result += `<th>${headings[i]}</th>`;
  }
  result += "</tr>";

  for (let i = 0; i < arr.length; i++) {
    let values = Object.values(arr[i]);
    result += "\n  <tr>";
    for (let i = 0; i < values.length; i++) {
      result += `<td>${formatString(values[i].toString())}</td>`;
    }
    result += "</tr>";
  }
  result += "\n</table>";
  console.log(result);
}

solve('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]');
solve(
  '[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]'
);
