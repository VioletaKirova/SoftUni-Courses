function solve(arr) {
  function getProperties(obj) {
    var properties = [];
    properties.push(obj);

    while ((obj = Object.getPrototypeOf(obj)) !== null) {
      if (Object.keys(obj).length > 0) {
        properties.push(obj);
      }
    }

    return properties;
  }

  let objects = {};

  const commandsMap = {
    create: function(name, _, _) {
      objects[name] = {};
    },
    inherit: function(name, parentName, _) {
      objects[name] = Object.create(objects[parentName]);
    },
    set: function(name, key, value) {
      objects[name][key] = value;
    },
    print: function(name, _, _) {
      let result = getProperties(objects[name])
        .reduce((acc, curr) => {
          Object.entries(curr).forEach(([key, value]) => {
            acc.push(`${key}:${value}`);
          });

          return acc;
        }, [])
        .join(", ");

      console.log(result);
    }
  };

  arr.forEach(command => {
    let [a, b, c, d] = command.split(" ");

    if (c === "inherit") {
      commandsMap.inherit(b, d);
    } else if (a === "set") {
      commandsMap.set(b, c, d);
    } else {
      commandsMap[a](b);
    }
  });
}

solve([
  "create c1",
  "create c2 inherit c1",
  "set c1 color red",
  "set c2 model new",
  "print c1",
  "print c2"
]);
