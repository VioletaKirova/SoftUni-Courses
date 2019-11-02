function Spy(target, method) {
  let func = target[method];
  let result = {
    count: 0
  };

  target[method] = function() {
    result.count++;
    return func.apply(this, arguments);
  };

  return result;
}

let obj = {
  method: () => "invoked"
};
let spy = Spy(obj, "method");

obj.method();
obj.method();
obj.method();

console.log(spy); // { count: 3 }
