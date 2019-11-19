function solve(input) {
  let list = [];

  const commandsMap = {
    add: function(str) {
      list.push(str);
      return list;
    },
    remove: function(str) {
      return list.filter(x => x !== str);
    },
    print: function(_) {
      console.log(list.join(","));
      return list;
    }
  };

  input.forEach(x => {
    let [command, param] = x.split(" ");
    list = commandsMap[command](param);
  });
}

solve(["add hello", "add again", "remove hello", "add again", "print"]);
solve(["add pesho", "add george", "add peter", "remove peter", "print"]);
