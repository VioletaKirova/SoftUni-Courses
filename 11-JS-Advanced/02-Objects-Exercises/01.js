function solve(arr) {
  let heroes = [];

  for (let i = 0; i < arr.length; i++) {
    let args = arr[i].split(" / ");
    let hero = {
      name: args[0],
      level: Number(args[1]),
      items: args.length > 2 ? args[2].split(", ") : []
    };
    heroes.push(hero);
  }

  console.log(JSON.stringify(heroes));
}

solve([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara"
]);
