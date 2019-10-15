function solve(num1) {
  return function add(num2) {
    return num1 + num2;
  };
}

console.log(solve(5)(2));
