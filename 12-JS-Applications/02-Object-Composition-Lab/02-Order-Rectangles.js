function solve(arr) {
  let template = {
    width: 0,
    height: 0,
    area: function() {
      return this.width * this.height;
    },
    compareTo: function(rectangle) {
      return rectangle.area() - this.area()  || rectangle.width - this.width;
    }
  };

  return arr
    .map(([width, height]) =>
      Object.assign(Object.create(template), { width, height })
    )
    .sort((a, b) => a.compareTo(b));
}

console.log(solve([[10, 5], [5, 12]]));
console.log(solve([[10, 5], [3, 20], [5, 12]]));
console.log(solve([[1, 20], [20, 1], [5, 3], [5, 3]]));
