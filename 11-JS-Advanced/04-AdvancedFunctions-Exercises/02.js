function solve(...params) {
  let types = params.reduce((acc, curr) => {
    let type = typeof curr;

    console.log(`${type}: ${curr}`);

    if (!acc.hasOwnProperty(type)) {
      acc[type] = 0;
    }

    acc[type]++;

    return acc;
  }, {});

  Object.entries(types)
    .sort((a, b) => b[1] - a[1])
    .forEach(element => {
      console.log(`${element[0]} = ${element[1]}`);
    });
}

solve("cat", 42, function() {
  console.log("Hello world!");
});
