function solve() {
  function getInitialSum(value) {
    return Array.from(value.match(/1/gim)).length;
  }

  function reduceSum(value) {
    return Array.from(value)
      .reduce((acc, curr) => {
        acc += Number(curr);
        return acc;
      }, 0)
      .toString();
  }

  let input = document.getElementById("input");
  let output = document.getElementById("resultOutput");

  let sum = getInitialSum(input.value).toString();

  while (sum.length > 1) {
    sum = reduceSum(sum);
  }

  let reducedInput = input.value.substring(sum, input.value.length - sum);

  let result = "";

  reducedInput.match(/\d{1,8}/gim).forEach(x => {
    let currentChar = String.fromCharCode(parseInt(Number(x), 2));

    if(currentChar.match(/[a-z ]/gi) !== null){
      result += currentChar;
    }
  });

  output.innerHTML = result;
  input.value = "";
}
