function solve(arr) {
  let systems = {};

  for (let i = 0; i < arr.length; i++) {
    let [system, component, subComponent] = arr[i].split(" | ");

    if (systems[system] === undefined) {
      systems[system] = {};
    }

    if (systems[system][component] === undefined) {
      systems[system][component] = [];
    }

    systems[system][component].push(subComponent);
  }

  let orderedSystemKeys = Object.keys(systems)
    .sort()
    .sort(
      (a, b) => Object.keys(systems[b]).length - Object.keys(systems[a]).length
    );

  for (let i = 0; i < orderedSystemKeys.length; i++) {
    let currentSystem = orderedSystemKeys[i];
    console.log(currentSystem);

    let orderedComponentKeys = Object.keys(systems[orderedSystemKeys[i]]).sort(
      (a, b) =>
        Object.keys(systems[orderedSystemKeys[i]][b]).length -
        Object.keys(systems[orderedSystemKeys[i]][a]).length
    );

    for (let j = 0; j < orderedComponentKeys.length; j++) {
      let currentComponent = orderedComponentKeys[j];
      console.log(`|||${currentComponent}`);
      for (
        let k = 0;
        k < systems[currentSystem][currentComponent].length;
        k++
      ) {
        console.log(`||||||${systems[currentSystem][currentComponent][k]}`);
      }
    }
  }
}

solve([
  "SULS | Main Site | Home Page",
  "SULS | Main Site | Login Page",
  "SULS | Main Site | Register Page",
  "SULS | Judge Site | Login Page",
  "SULS | Judge Site | Submittion Page",
  "Lambda | CoreA | A23",
  "SULS | Digital Site | Login Page",
  "Lambda | CoreB | B24",
  "Lambda | CoreA | A24",
  "Lambda | CoreA | A25",
  "Lambda | CoreC | C4",
  "Indice | Session | Default Storage",
  "Indice | Session | Default Security"
]);
