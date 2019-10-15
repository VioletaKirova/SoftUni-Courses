function solve(x = 5) {
  for (let i = 1; i <= x; i++) {
    let line = Array(x)
      .fill("*")
      .join(" ");
    console.log(line);
  }
}

solve();
