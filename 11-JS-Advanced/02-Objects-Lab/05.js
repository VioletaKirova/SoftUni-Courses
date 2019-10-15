function solve(arr) {
  let words = arr[0].match(/\w+/gim);

  let result = {};

  for (let i = 0; i < words.length; i++) {
    if (result[words[i]] === undefined) {
      result[words[i]] = 0;
    }
    result[words[i]]++;
  }

  console.log(JSON.stringify(result));
}

solve(["Far too slow, you're far too slow."]);
solve(["JS devs use Node.js for server-side JS.-- JS for devs"]);
