function solve() {
  function validateInput(arr, index) {
    if (index < 0 || index > arr.length - 1) {
      throw new Error("The index is outside the bounds of the array.");
    }
  }

  return {
    elements: [],
    size: 0,
    add: function(element) {
      this.elements.push(element);
      this.size++;

      this.elements.sort((a, b) => a - b);
    },
    remove: function(index) {
      validateInput(this.elements, index);

      this.elements.splice(index, 1);
      this.size--;
    },
    get: function(index) {
      validateInput(this.elements, index);

      return this.elements[index];
    }
  };
}
