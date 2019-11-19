function solve() {
  return {
    extend: function(obj) {
      const propertyKeys = Object.keys(obj).filter(
        key => typeof obj[key] !== "function"
      );
      propertyKeys.forEach(key => {
        this[key] = obj[key];
      });

      const functionKeys = Object.keys(obj).filter(
        key => typeof obj[key] === "function"
      );
      functionKeys.forEach(key => {
        Object.getPrototypeOf(this)[key] = obj[key];
      });
    }
  };
}
