let add = (function solve(){
    let sum = 0;

    return function add(num){
        sum += num;

        add.toString = () => sum;       

        return add;
    }
}());

console.log(add(1)(6)(-3).toString());