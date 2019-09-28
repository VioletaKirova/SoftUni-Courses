// Score: 90/100

function solve(arr){
    let gladiators = {};

    for(i = 0; i < arr.length; i++){
        if(arr[i] === "Ave Cesar"){
            break;
        }
        
        if(!arr[i].includes("vs")){
            let [gladiator, technique, skill] = arr[i].split(" -> ");

            skill = Number(skill);

            if(!gladiators.hasOwnProperty(gladiator)){
                gladiators[gladiator] = {};
            }

            if(!gladiators[gladiator].hasOwnProperty(technique)){
                gladiators[gladiator][technique] = 0;
            }

            if(gladiators[gladiator][technique] < skill){
                gladiators[gladiator][technique] = skill;
            }

            continue;
        }

        let [firstGladiator, secondGladiator] = arr[i].split(" vs ");

        if(gladiators.hasOwnProperty(firstGladiator) && gladiators.hasOwnProperty(secondGladiator)){
            let firstGladiatorTechniques = Object.keys(gladiators[firstGladiator]);
            let secondGladiatorTechniques = Object.keys(gladiators[secondGladiator]);

            for(let j = 0; j < firstGladiatorTechniques.length; j++){
                let currentTechnique = firstGladiatorTechniques[j];

                if(secondGladiatorTechniques.includes(currentTechnique)){
                    let firstGladiatorSkill = gladiators[firstGladiator][currentTechnique];
                    let secondGladiatorSkill = gladiators[secondGladiator][currentTechnique];

                    if(firstGladiatorSkill === secondGladiatorSkill){
                        continue;
                    }

                    firstGladiatorSkill > secondGladiatorSkill ? delete gladiators[secondGladiator] :  delete gladiators[firstGladiator];
                }
            }
        }
    }

    let gladiatorsTotalSkill = {};

    for(let gladiator in gladiators){
        let totalSkill = Object.values(gladiators[gladiator]).reduce((a, b) => a + b, 0);
        gladiatorsTotalSkill[gladiator] = totalSkill;
    }

    let orderedGladiatorKeys = Object.entries(gladiatorsTotalSkill).sort((a, b) => b[1] - a[1]).map(x => x[0]);

    for(let gladiator of orderedGladiatorKeys){
        console.log(`${gladiator}: ${gladiatorsTotalSkill[gladiator]} skill`);

        let techniqueKeys = Object.keys(gladiators[gladiator]).sort((a, b) => b.localeCompare(a));

        for(let technique of techniqueKeys){
            console.log(`- ${technique} <!> ${gladiators[gladiator][technique]}`);
        }
    }
}

solve([
    'Pesho -> BattleCry -> 400',
    'Gosho -> PowerPunch -> 300',
    'Stamat -> Duck -> 200',
    'Stamat -> Tiger -> 250',
    'Ave Cesar'
  ]);

solve([
    'Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 250',
    'Pesho vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Gosho',
    'Ave Cesar'
  ]);