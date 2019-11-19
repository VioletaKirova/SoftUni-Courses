function solve() {
  let element1;
  let element2;
  let resultElement;

  return {
    init: function(selector1, selector2, resultSelector) {
      this.element1 = document.querySelector(selector1);
      this.element2 = document.querySelector(selector2);
      this.resultElement = document.querySelector(resultSelector);
    },
    add: function() {
      this.resultElement.value =
        Number(this.element1.value) + Number(this.element2.value);
    },
    subtract: function() {
      this.resultElement.value =
        Number(this.element1.value) - Number(this.element2.value);
    }
  };
}
