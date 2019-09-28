function solve(kingdomsArr, fightsArr){
    let kingdoms = {};

    let data = kingdomsArr
        .forEach(line => {
            let kingdom = line.kingdom;
            let general = line.general;
            let army = Number(line.army);

            if(!kingdoms.hasOwnProperty(kingdom)){
                kingdoms[kingdom] = {};
            }

            if(!kingdoms[kingdom].hasOwnProperty(general)){
                kingdoms[kingdom][general] = {
                    army: 0,
                    wins: 0,
                    losses: 0,
                };
            }

            kingdoms[kingdom][general].army += army;
        });
    
    for(let i = 0; i < fightsArr.length; i++){
        let [firstKingdom, firstGeneral, secondKingdom, secondGeneral] = fightsArr[i];

        let attackingGeneral = kingdoms[firstKingdom][firstGeneral];
        let defendingGeneral = kingdoms[secondKingdom][secondGeneral];

        if(firstKingdom === secondKingdom || 
            attackingGeneral.army === defendingGeneral.army){
            continue;
        }

        if(attackingGeneral.army > defendingGeneral.army){
            attackingGeneral.army  = Math.floor(attackingGeneral.army * 1.1);
            defendingGeneral.army = Math.floor(defendingGeneral.army * 0.9);

            attackingGeneral.wins++;
            defendingGeneral.losses++;
        }
        else{  
            defendingGeneral.army = Math.floor(defendingGeneral.army * 1.1);
            attackingGeneral.army = Math.floor(attackingGeneral.army * 0.9);

            defendingGeneral.wins++;
            attackingGeneral.losses++;
        }
    }

    let orderedKingdoms = [];

    for(let key in kingdoms){
        let values = Object.values(kingdoms[key]);
        let wins = values
            .map(x => x.wins)
            .reduce((a, b) => a + b, 0);
        let losses = values
            .map(x => x.losses)
            .reduce((a, b) => a + b, 0);

        let kingdom = {};
        kingdom = {name:key, wins, losses};

        orderedKingdoms.push(kingdom);
    }

    orderedKingdoms = orderedKingdoms
        .sort((a, b) => b.wins - a.wins || a.losses - b.losses || a.name.localeCompare(b.name));

    let winnerKingdomKey = orderedKingdoms[0].name;
    console.log(`Winner: ${winnerKingdomKey}`);

    let winnerKingdomEntries = Object.entries(kingdoms[winnerKingdomKey])
        .sort((a, b) => b[1].army  - a[1].army);

    for(let entry of winnerKingdomEntries){
        console.log(`/\\general: ${entry[0]}`);
        console.log(`---army: ${entry[1].army}`);
        console.log(`---wins: ${entry[1].wins}`);
        console.log(`---losses: ${entry[1].losses}`);
    }
}

solve([ { kingdom: "Maiden Way", general: "Merek", army: 5000 },
{ kingdom: "Stonegate", general: "Ulric", army: 4900 },
{ kingdom: "Stonegate", general: "Doran", army: 70000 },
{ kingdom: "YorkenShire", general: "Quinn", army: 0 },
{ kingdom: "YorkenShire", general: "Quinn", army: 2000 },
{ kingdom: "Maiden Way", general: "Berinon", army: 100000 } ],
[ ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
["Stonegate", "Ulric", "Stonegate", "Doran"],
["Stonegate", "Doran", "Maiden Way", "Merek"],
["Stonegate", "Ulric", "Maiden Way", "Merek"],
["Maiden Way", "Berinon", "Stonegate", "Ulric"] ]
);