function solve(){
    let microelements = {
        protein : 0, carbohydrate : 0, fat : 0, flavour : 0
    };

    let meals = {
        apple : {
            protein : 0, carbohydrate : 1, fat : 0, flavour : 2
        },
        lemonade : {
            protein : 0, carbohydrate : 10, fat : 0, flavour : 20
        },
        burger : {
            protein : 0, carbohydrate : 5, fat : 7, flavour : 3
        },
        eggs : {
            protein : 5, carbohydrate : 0, fat : 1, flavour : 1
        },
        turkey : {
            protein : 10, carbohydrate : 10, fat : 10, flavour : 10
        }
    };

    function executeCommand(){
        return {
            restock: (microelement, quantity) => {
                microelements[microelement] += Number(quantity);
                return "Success";
            },
            prepare: (meal, quantity) => {
                for(let key of Object.keys(meals[meal])){
                    if(microelements[key] < meals[meal][key] * quantity){
                        return `Error: not enough ${key} in stock`;
                    }
                }

                for(let key of Object.keys(meals[meal])){
                    microelements[key] -= meals[meal][key] * quantity;
                }

                return "Success";
            },
            report: () => {
                return Object.entries(microelements)
                    .map(x => `${x[0]}=${x[1]}`)
                    .join(" ");
            }
        }
    }

    return function manager(input){
        let [command, key, value] = input.split(" ");

        return executeCommand()[command](key, value);
    }
}

let manager = solve();

console.log(manager("restock carbohydrate 10"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare apple 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare burger 1"));
console.log(manager("report"));