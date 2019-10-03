function solve() {
    return {
        add: (v1, v2) => {
            return [v1[0] + v2[0], v1[1] + v2[1]];
        },
        multiply: (v, s) => {
            return [v[0] * s, v[1] * s];
        },
        length: (v) => {
            return Math.sqrt(Math.pow(v[0], 2) + Math.pow(v[1], 2));
        },
        dot: (v1, v2) => {
            return v1[0] * v2[0] + v1[1] * v2[1];
        },
        cross: (v1, v2) => {
            return v1[0] * v2[1] - v1[1] * v2[0];
        }
    }
}

let calculator = solve();

console.log(calculator.add([1, 1], [1, 0]));
console.log(calculator.multiply([3.5, -2], 2));
console.log(calculator.length([3, -4]));
console.log(calculator.dot([1, 0], [0, -1]));
console.log(calculator.cross([3, 7], [1, 0]));
