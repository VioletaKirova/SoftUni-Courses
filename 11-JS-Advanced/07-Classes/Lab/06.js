(function solve() {
  let faces = [
    "2",
    "3",
    "4",
    "5",
    "6",
    "7",
    "8",
    "9",
    "10",
    "J",
    "Q",
    "K",
    "A"
  ];

  let Suits = {
    SPADES: "♠",
    HEARTS: "♥",
    DIAMONDS: "♦",
    CLUBS: "♣"
  };

  class Card {
    _face;
    _suit;

    constructor(face, suit) {
      this.face = face;
      this.suit = suit;
    }

    get face() {
      return this._face;
    }

    set face(value) {
      if (!faces.includes(value)) {
        throw new Error("Invalid face.");
      }

      this._face = faces.find(x => x === value);
    }

    get suit() {
      return this._suit;
    }

    set suit(value) {
      if (!Object.values(Suits).includes(value)) {
        throw new Error("Invalid suit.");
      }

      this._suit = value;
    }
  }

  return {
    Suits: Suits,
    Card: Card
  };
}())
