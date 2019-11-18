function solve(arr) {
  const operationsMap = {
    chop: num => {
      return num / 2;
    },
    dice: num => {
      return Math.sqrt(num);
    },
    spice: num => {
      return num + 1;
    },
    bake: num => {
      return num * 3;
    },
    fillet: num => {
      return num - num * 0.2;
    }
  };
  let num = Number(arr[0]);
  for (let i = 1; i <= arr.length - 1; i++) {
    num = operationsMap[arr[i]](num);
    console.log(num);
  }
}

solve(["32", "chop", "chop", "chop", "chop", "chop"]);
solve(["9", "dice", "spice", "chop", "bake", "fillet"]);
