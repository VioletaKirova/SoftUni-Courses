(function solve() {
  function validateInput(arr, n) {
    if (n < 0 || n > arr.length - 1) {
      throw new Error("The index is outside the bounds of the array.");
    }
  }

  Array.prototype.last = function() {
    return this[this.length - 1];
  };

  Array.prototype.skip = function(n) {
    validateInput(this, n);

    return this.slice(n, this.length);
  };

  Array.prototype.take = function(n) {
    validateInput(this, n);

    return this.slice(0, n);
  };

  Array.prototype.sum = function() {
    return this.reduce((acc, _, i) => acc + this[i], 0);
  };

  Array.prototype.average = function() {
    return this.sum() / this.length;
  };
})();
