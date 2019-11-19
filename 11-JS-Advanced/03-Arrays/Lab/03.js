function solve(arr) {
  const actionsMap = {
    true: "unshift",
    false: "push"
  };

  let result = arr.reduce((result, x) => {
    result[actionsMap[x < 0]](x);
    return result;
  }, []);

  console.log(result);
}

solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);
