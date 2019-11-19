function solve() {
  const getState = function(name, stamina, mana) {
    return {
      name,
      health: 100,
      stamina: stamina || 0,
      mana: mana || 0
    };
  };

  function fight() {
    this.stamina--;
    console.log(`${this.name} slashes at the foe!`);
  }

  function cast(spell) {
    this.mana--;
    console.log(`${this.name} cast ${spell}`);
  }

  function fighter(name) {
    return Object.assign(getState(name, 100, 0), { fight });
  }

  function mage(name) {
    return Object.assign(getState(name, 0, 100), { cast });
  }

  return {
    fighter,
    mage
  };
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball");
scorcher.cast("thunder");
scorcher.cast("light");

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight();

console.log(scorcher2.stamina);
console.log(scorcher.mana);
