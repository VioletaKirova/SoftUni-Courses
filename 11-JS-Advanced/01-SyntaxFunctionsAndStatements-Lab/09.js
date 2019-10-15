function solve(str) {
  let result = str
    .match(/\w+/gim)
    .map(x => x.toUpperCase())
    .join(", ");
  console.log(result);
}

solve("Hi, how are you?");
